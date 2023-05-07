
using BARAZAIS.Data.Database;
using BARAZAIS.Data.Mappers;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Repos;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;


namespace BARAZAIS.Pages.LoginPage;

public class RegisterModel : PageModel
{
    private readonly SignInManager<UserModel> SignInManager;
    private readonly UserManager<UserModel> UserManager;
    private readonly RoleManager<IdentityRole<int>> RoleManager;
    private readonly IDbContextFactory<BarazaContext> MyFactory;
    public RegisterModel(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager, RoleManager<IdentityRole<int>> roleManager,IDbContextFactory<BarazaContext> myFactoy)
    {
        this.SignInManager = signInManager;
        this.UserManager = userManager;
        this.RoleManager = roleManager;
        this.MyFactory = myFactoy;
    }

    [BindProperty]
    public RegistrationMapper? Input { get; set; }
    public string? ReturnUrl { get; set; }

    public void OnGet()
    {
        ViewData["DError"] = "d-none";
        ReturnUrl = Url.Content("~/");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ReturnUrl = Url.Content("~/");
        if (ModelState.IsValid)
        {
            var ThisUserBusiness = new CompanyModel
            {
                CompanyName = Input?.BussinesName,
                DateCreated = DateTime.Now,
                LogoUrl = "",
                Email = "",
                Phone = "",
                Address = Input?.Location,
                TIN = "",
            };

            var ThisUserRole = new IdentityRole<int> {
                Name = "Owner",
                NormalizedName = "OWNER",
            };

            var ThisUser = new UserModel {
                UserName = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                PhoneNumber = Input.PhoneNumber,
                Email = Input.Email,
                Password = Input.Password,
                DateCreated = DateTime.Now,
                Address = "",
                NIDA = "",
                ImageUrl = "",
                Company = ThisUserBusiness,

            };


            async Task<string?> CreateRoleAsync()
            {
                bool Checked = await RoleManager.RoleExistsAsync(ThisUserRole.Name);
                if (!Checked)
                {
                    var Done = await RoleManager.CreateAsync(ThisUserRole);

                    await RoleManager.CreateAsync(new IdentityRole<int> { Name = "Admin", NormalizedName = "ADMIN" });
                    await RoleManager.CreateAsync(new IdentityRole<int> { Name = "Manager", NormalizedName = "MANAGER" });
                    await RoleManager.CreateAsync(new IdentityRole<int> { Name = "Supervisor", NormalizedName = "SUPERVISOR" });
                    await RoleManager.CreateAsync(new IdentityRole<int> { Name = "Cashier", NormalizedName = "CASHIER" });

                    if (Done.Succeeded)
                    {
                        return ThisUserRole.Name;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return ThisUserRole.Name;
                }
            }

            async Task SendEmailVerificationAsync(UserModel NewUser)
            {
                var user = NewUser;
                var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Pages/LoginPage/Login",
                    pageHandler: null,
                    values: new { userId = user.Id, token = token },
                    protocol: Request.Scheme);

                //Mail preparations, and Sms Sending
                MailAddress From = new MailAddress("razackdotnet@gmail.com");
                MailAddress To = new MailAddress(user.Email);

                MailMessage Sms = new MailMessage(From,To);
                Sms.Subject = "Email Address verification";
                Sms.Body = callbackUrl;

                SmtpClient Client = new SmtpClient("127.0.0.1");

                Client.Send(Sms);
            }


            //INITIAL : 

            var UserAvailable = await UserManager.FindByEmailAsync(Input.Email);
            if(UserAvailable == null)
            {
                //Created Role
                var CreatedRole = await CreateRoleAsync();
                if (CreatedRole != null)
                {
                    //Create User
                    var UserResult = await UserManager.CreateAsync(ThisUser, Input.Password);

                    if (UserResult.Succeeded)
                    {
                        // Assign Role Created User
                        var AssignRole = await UserManager.AddToRoleAsync(ThisUser, CreatedRole);

                        if (AssignRole.Succeeded)
                        {
                            await SendEmailVerificationAsync(ThisUser);
                            //return LocalRedirect(ReturnUrl);
                        }
                    }
                }
            }
            else
            {
                ViewData["DError"] = "d-block";
                ViewData["UserAvailable"] = "User with this Email exist, please Login";
            }
        }
        return Page();
    }
}