using Account.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shared.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Implementations
{
    public class AccountManager : IAccountManager
    {
        readonly ITokenGenerator _tokenGenerator;
        readonly UserManager<IdentityUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly SignInManager<IdentityUser> _signInManager;

        public AccountManager(
            ITokenGenerator tokenGenerator,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
        }

        public void CreateUser(string userName, string email, string password, string role)
        {

            if (_userManager.FindByNameAsync(userName).Result != null ||
                !string.IsNullOrEmpty(email) && _userManager.FindByEmailAsync(userName).Result != null)
                throw new Exception("User already exists");

            var user = new IdentityUser { UserName = userName, Email = email };
            var userResult = _userManager.CreateAsync(user, password).Result;

            if (userResult.Succeeded)
            {
                ValidateRole(role);
                user = _userManager.FindByNameAsync(userName).Result;
                var roleResult = _userManager.AddToRoleAsync(user, role).Result;
            }
        }

        private void ValidateRole(string roleName)
        {
            var role = _roleManager.FindByNameAsync(roleName).Result;

            if (role == null)
            {
                role = new IdentityRole { Name = roleName };
                var roleResult = _roleManager.CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                    throw new Exception(string.Join("\n", roleResult.Errors.Select(e => e.Description)));
            }
        }

        public string Authenticate(string userName, string email, string password)
        {
            var user = _userManager.FindByNameAsync(userName).Result;

            if (user == null && !string.IsNullOrEmpty(email))
                user = _userManager.FindByEmailAsync(userName).Result;

            if (user == null)
                throw new Exception("Invalid username or password");

            var signinResult = _signInManager.CheckPasswordSignInAsync(user, password, true).Result;

            if (signinResult.IsLockedOut)
                throw new Exception("Blocked user");

            return _tokenGenerator.Generate(user);

        }

    }
}
