using Stefanini_Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Domain.Repositories
{
    public interface IUserRepository
    {
        User FindByEmail(string email);

    }
}
