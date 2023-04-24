using BARAZAIS.Data.Mappers;
using BARAZAIS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BARAZAIS.Pages.LoginPage;

public class LoginModel : PageModel
{
    private readonly SignInManager<UserModel> SignInManager;

    public LoginModel(SignInManager<UserModel> signInManager)
    {
        SignInManager = signInManager;
    }

    [BindProperty]
    public UserMapper Input { get; set; }

    private string ReturnUrl { get; set; }

    public void OnGet()
    {
        ReturnUrl = Url.Content("~/");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ReturnUrl = Url.Content("~/");

        var Result = await SignInManager.PasswordSignInAsync(Input?.Email, Input.Password, false, false);
        if (Result.Succeeded)
        {
            return LocalRedirect(ReturnUrl);
        }

        return Page();
    }
}
