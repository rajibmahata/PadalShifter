using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedalShifter.Data.Entities;
using System.Security.Claims;
using PedalShifter.Data.ViewModels;
using PedalShifter.Domain.Interfaces;

namespace PedalShifter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostService hostService;
        private readonly IRenterService renterService;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IHostService hostService, IRenterService renterService)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.hostService = hostService;
            this.renterService = renterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLogin model = new UserLogin();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    if(userManager.IsInRoleAsync(user, "Host").GetAwaiter().GetResult())
                    {
                        return RedirectToAction("Dashboard", "Host");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Listings");
                    }
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            RenterRegistrationViewModel model = new RenterRegistrationViewModel();
            return View(model);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult RegisterHost()
        {
            HostRegistrationViewModel model = new HostRegistrationViewModel();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RenterRegistrationViewModel request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };

                    var renter = new Renter
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        IdentityId = user.Id
                    };

                    var userResult = await userManager.CreateAsync(user, request.Password);
                    var roleResult = await userManager.AddToRoleAsync(user, "Renter");
                    var renterResult = await renterService.CreateAsync(renter);
                    if (userResult.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (userResult.Errors.Count() > 0)
                        {
                            foreach (var error in userResult.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        if (roleResult.Errors.Count() > 0)
                        {
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        if (!renterResult)
                        {
                            ModelState.AddModelError("message", "Could not create a new Host entity.");
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(request);
                }
            }
            return View(request);

        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> RegisterHost(HostRegistrationViewModel request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    await CreateRolesandUsers();
                    var user = new IdentityUser
                    {
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };
                    var host = new Host
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        IdentityId = user.Id
                    };
                    var userResult = await userManager.CreateAsync(user, request.Password);
                    var roleResult = await userManager.AddToRoleAsync(user, "Host");
                    var hostResult = await hostService.CreateAsync(host);
                    if (userResult.Succeeded && roleResult.Succeeded && hostResult)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (userResult.Errors.Count() > 0)
                        {
                            foreach (var error in userResult.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        if (roleResult.Errors.Count() > 0)
                        {
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        if (!hostResult)
                        {
                            ModelState.AddModelError("message", "Could not create a new Host entity.");
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(request);
                }
            }
            return View(request);

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task CreateRolesandUsers()
        {             
            // creating Creating Manager role     
            bool x = await roleManager.RoleExistsAsync("Host");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Host";
                await roleManager.CreateAsync(role);
            }

            // creating Creating Employee role     
            x = await roleManager.RoleExistsAsync("Renter");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Renter";
                await roleManager.CreateAsync(role);
            }
        }
    }
}
