
using BARAZAIS.Data.Database;
using BARAZAIS.Data.Mappers;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Repos;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;


namespace BARAZAIS.Pages.LoginPage;

public class RegisterModel : PageModel
{
    private readonly SignInManager<UserModel> SignInManager;
    private readonly UserManager<UserModel> UserManager;
    private readonly RoleManager<AccessLevelModel> RoleManager;
    private readonly IDbContextFactory<BarazaContext> MyFactory;
    public RegisterModel(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager, RoleManager<AccessLevelModel> roleManager,IDbContextFactory<BarazaContext> myFactoy)
    {
        SignInManager = signInManager;
        UserManager = userManager;
        RoleManager = roleManager;
        MyFactory = myFactoy;
    }

    [BindProperty]
    public RegistrationMapper Input { get; set; }
    public string? ReturnUrl { get; set; }

    public void OnGet()
    {
        ReturnUrl = Url.Content("~/");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ReturnUrl = Url.Content("~/");
        if(ModelState.IsValid)
        {
            var ThisUserBusiness = new CompanyModel
            {
                CompanyName = Input.BussinesName,
                DateCreated = DateTime.Now,
                LogoUrl = "",
                Email = Input.Email,
                Phone = "",
                Address = Input.Location,
                TIN = "",
            };

            var ThisUserRole = new AccessLevelModel
            {
                Name = "Owner",
                NormalizedName = "OWNER",
                DateCreated = DateTime.Now,
                Description = "Main Business Owner",
            };

            var ThisUser = new UserModel {
                UserName = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Email = Input.Email,
                Password = Input.Password,
                DateCreated = DateTime.Now,
                Address = "",
                Phone = "",
            };

            
            async Task CreateRoleAsync()
            {
                List<AccessLevelModel> TheseRoles = new();

                TheseRoles = await RoleManager.Roles.ToListAsync();

                if(TheseRoles.Any() && TheseRoles.Count > 0)
                {
                    foreach(var ARole in TheseRoles)
                    {
                        if(ARole.Name == ThisUserRole.Name)
                        {
                            ThisUser.AccessLevel = ARole;
                        }
                    }
                }
                else
                {
                    var RoleCreateResult = await RoleManager.CreateAsync(ThisUserRole);
                    if (RoleCreateResult.Succeeded)
                    {
                        var Fetched = await RoleManager.FindByNameAsync(ThisUserRole.Name);
                        ThisUser.AccessLevel = Fetched;
                    }
                }
            }

            async Task CreateCompanyAsync()
            {
                using (var repo = new UnitOfWorkRepo(MyFactory.CreateDbContext()))
                {
                    await repo.Companies.AddAsync(ThisUserBusiness);
                    ThisUser.Company = ThisUserBusiness;

                    await repo.CompleteAsync();
                    repo.Dispose();
                }
            }

            // Log user in if successfully created
            var UserResult = await UserManager.CreateAsync(ThisUser, Input.Password);

            if (UserResult.Succeeded)
            {
                await CreateCompanyAsync();
                await CreateRoleAsync();
                var UserUpdateResult = await UserManager.UpdateAsync(ThisUser);

                if (UserUpdateResult.Succeeded)
                {
                    await SignInManager.SignInAsync(ThisUser, false);
                    return LocalRedirect(ReturnUrl);
                } 
            }
            
        }

        return Page();
    }
}