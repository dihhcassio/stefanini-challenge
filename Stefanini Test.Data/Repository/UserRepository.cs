using Stefanini_Test.Data.Abstractions.Repositories;
using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Extensions;
using Stefanini_Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(StefaniniDataContext context) : base(context) { }

        public User FindByEmail(string email)
        {
            return _dbSet.Where(u => u.Email.Trim().Equals(email.Trim()) && !u.Removed).FirstOrDefault();
        }

    }
}
