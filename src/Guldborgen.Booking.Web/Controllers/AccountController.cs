using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Guldborgen.Booking.Common.Models;
using Guldborgen.Booking.Domain;
using Guldborgen.Booking.Web.Attributes;
using Guldborgen.Booking.Web.ViewModels;

namespace Guldborgen.Booking.Web.Controllers
{
    public class AccountController : AsyncController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("account/login")]
        public ActionResult Login()
        {
            if (HttpContext.User != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [Route("account/login", Name = "Login")]
        public async Task<ActionResult> Login(LoginViewModel user)
        {

            if (!ModelState.IsValid)
                return View();

            var userId = await _accountService.LoginAsync(user.Email, user.Password);
            if (userId != 0)
            {
                var sessionId = Guid.NewGuid();
                UserSession userSession = new UserSession
                {
                    Id = sessionId,
                    UserId = userId,
                    ExpirationDate = DateTime.Now.AddHours(3)
                };

                await _accountService.AddSessionAsync(userSession);

                HttpCookie authCookie = new HttpCookie("SESSION_ID", sessionId.ToString());

                Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Inloggning är felaktig!");

            return View();
        }

      
        [Route("account/logout")]
        [CustomAuthorizeUser]
        public async Task<ActionResult> Logout()
        {
            //todo: Remove user session
            return RedirectToAction("Index", "Home");
        }
    }
}