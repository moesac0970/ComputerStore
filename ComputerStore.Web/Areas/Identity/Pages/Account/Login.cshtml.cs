using ComputerStore.Lib.Models;
using ComputerStore.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;
        private ClientBearerService bearerService;
        private IConfiguration Configuration { get; }
        private string BaseUri { get; set; }

        public LoginModel(
           SignInManager<User> signInManager,
           ILogger<LoginModel> logger,
           UserManager<User> userManager,
           IEmailSender emailSender,
           IConfiguration configuration,
           ClientBearerService _bearerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            Configuration = configuration;
            bearerService = _bearerService;
            BaseUri = Configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {


            returnUrl = Url.Content("~/");
            var uri = BaseUri;

            if (ModelState.IsValid)
            {
                //var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                // try signin with the signinmanager
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);

                // if can signin user 
                if (result.Succeeded)
                {

                    var bearerToken = await bearerService.SendBearerRequest(uri, Input.Email);

                    if (bearerToken != "not valid user")
                    {
                        // set cookieoptions, and save cookie on client, and signin user with the signinmanager
                        // todo domain date on cookie from the beaertoken
                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTimeOffset.Now.AddDays(1).AddMinutes(-5),
                            HttpOnly = false,
                            Secure = true
                        };
                        HttpContext.Response.Cookies.Append("bearerToken", bearerToken, cookieOptions);

                        _logger.LogInformation("User logged in.");
                    }
                    else
                    {
                        // exception handling when request from the bearer token endpoint isn't handled correct
                        _logger.LogInformation("something went wrong with the authentication service");
                        await _signInManager.SignOutAsync();
                        return LocalRedirect(returnUrl);
                    }

                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

            }
            return Page();
        }
    }
}
