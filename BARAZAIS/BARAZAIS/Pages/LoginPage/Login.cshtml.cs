
using BARAZAIS.Data.Mappers;
using BARAZAIS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BARAZAIS.Pages.LoginPage;

public class LoginModel : PageModel
{
    private readonly SignInManager<UserModel> SignInManager;

    public LoginModel(SignInManager<UserModel> signInManager)
    {
        SignInManager = signInManager;
    }

    [BindProperty]
    public RegistrationMapper Input { get; set; }
    private string ReturnUrl { get; set; }
    private string? ReturnFailed = "Either yor UserName(s) or Password(s) are not correct!.";
    private string? DisplayError = "d-none";

    public void OnGet()
    {
        ReturnUrl = Url.Content("~/");
        DisplayError = "d-none";
        ViewData["DError"] = DisplayError;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ReturnUrl = Url.Content("~/");

        var Result = await SignInManager.PasswordSignInAsync(Input.Email, Input.Password, false, false);
        if (Result.Succeeded)
        {
            DisplayError = "d-none";
            return LocalRedirect(ReturnUrl);
        }
        else
        {
            DisplayError = "d-block";

            ViewData["Failed"] = ReturnFailed;
            ViewData["DError"] = DisplayError ;
        }

        return Page();
    }
}