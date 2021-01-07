using Stefanini_Test.Data.Abstractions.Repositories;
using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Data.Repository
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        public SellerRepository(StefaniniDataContext context) : base(context) { }
        public List<Seller> FindAll()
        {
            return _dbSet.Where(s => !s.Removed).ToList();
        }

        public Seller GetByUserId(int userId) 
        {
            return _dbSet.Where(s => !s.Removed && s.UserId == userId).FirstOrDefault();
        }
    }
}
