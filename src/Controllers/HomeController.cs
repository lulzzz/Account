﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aiursoft.Pylon.Attributes;
using Aiursoft.Pylon;
using Aiursoft.Account.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Aiursoft.Pylon.Models;

namespace Aiursoft.Account.Controllers
{
    public class HomeController : Controller
    {
        public readonly SignInManager<AccountUser> _signInManager;
        public readonly ILogger _logger;

        public HomeController(
            SignInManager<AccountUser> signInManager,
            ILoggerFactory loggerFactory)
        {
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        [AiurForceAuth(preferController: "Account", preferAction: "Index", justTry: true)]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return this.SignoutRootServer(new AiurUrl(string.Empty, "Home", nameof(HomeController.Index), new { }));
        }
    }
}
