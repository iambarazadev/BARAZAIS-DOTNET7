
using BARAZAIS.Data.Mappers;
using BARAZAIS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace BARAZAIS.Pages.LoginPage;

public class RegisterModel : PageModel
{
    private readonly SignInManager<UserModel> SignInManager;
    private readonly UserManager<UserModel> UserManager;
    public RegisterModel(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager)
    {
        SignInManager = signInManager;
        UserManager = userManager;
    }

    [BindProperty]
    public UserMapper Input { get; set; }
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
            var ThisUser = new UserModel {
                UserName = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Email = Input.Email,
                Password = Input.Password,
                DateCreated = DateTime.Now,
                Address = "",
            };

            var Result = await UserManager.CreateAsync(ThisUser, ThisUser.Password);

            if(Result.Succeeded)
            {
                await SignInManager.SignInAsync(ThisUser, false);
                return LocalRedirect(ReturnUrl);
            }
        }

        return Page();
    }
}
