using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
    public class AuthenticateService : IAuthenticate
    {
        Guardian guardian = new Guardian();
        private readonly UserManager<Guardian> _userManager;
        private readonly SignInManager<Guardian> _signInManager;

        public AuthenticateService(UserManager<Guardian> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Authenticate(string providedToken)
        {
            var user = await _userManager.FindByEmailAsync(guardian.Email);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<Guardian>(); 
                var result = passwordHasher.VerifyHashedPassword(user, guardian.GuardianId, providedToken);

                return result == PasswordVerificationResult.Success ? true : false;
            }return true;
        }
        public async Task<bool> RegisterUser(string token)
        {
            //verificar se um usuário com este email já foi cadastrado
            var user = await _userManager.FindByEmailAsync(guardian.Email);
            //criar um novo usuário com base no token inserido
            var result = await _userManager.CreateAsync(user,token);
            //token = guardian_id
            if(result.Succeeded)
            {
                // faz o login automático desse usuário, ele não vai precisar 
                //inserir suas credenciais novamente após o registro.
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result.Succeeded;
        }
        public Task Logout()
        {
            throw new NotImplementedException();
        }

    }
}
