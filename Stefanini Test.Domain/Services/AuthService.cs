using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Extensions;
using Stefanini_Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public User GetUserAutenticated(string email, string password)
        {
            var user = _userRepository.FindByEmail(email.Trim());

            if (user == null)
                throw new Exception("User not found");

            if (!user.Password.Equals(password.EncryptMD5()))
                throw new Exception("Wrong password");

            return user;
        }
      }
}
