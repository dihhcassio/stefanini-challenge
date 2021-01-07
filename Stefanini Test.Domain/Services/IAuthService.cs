using Stefanini_Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Domain.Services
{
    public interface IAuthService
    {
        User GetUserAutenticated(string email, string password);
    }
}
