using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Aiursoft.Account.Models;
using Aiursoft.Account.Data;
using Aiursoft.Pylon.Attributes;
using System;
using Aiursoft.Pylon.Models.ForApps.AddressModels;
using Aiursoft.Pylon;

namespace Aiursoft.Account.Controllers
{
    public class AuthController : Controller
    {
        public readonly UserManager<AccountUser> _userManager;
        public readonly SignInManager<AccountUser> _signInManager;
        public readonly AccountDbContext _dbContext;

        public AuthController(
            UserManager<AccountUser> userManager,
            SignInManager<AccountUser> signInManager,
            AccountDbContext _context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = _context;
        }

        [AiurForceAuth(preferController: "", preferAction: "", justTry: false)]
        public IActionResult GoAuth()
        {
            throw new NotImplementedException();
        }

        [AiurForceAuth(preferController: "", preferAction: "", justTry: false, register: true)]
        public IActionResult GoRegister()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> AuthResult(AuthResultAddressModel model)
        {
            await AuthProcess.AuthApp(this, model, _userManager, _signInManager);
            return Redirect(model.state);
        }
    }
}