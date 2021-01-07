using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Domain.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerService(ISellerRepository sellerRepository) 
        {
            _sellerRepository = sellerRepository;
        }

        public List<Seller> FindSellers()
        {
            return _sellerRepository.FindAll();
        }

        public Seller GetByUserId(int userId)
        {
            return _sellerRepository.GetByUserId(userId);
        }
    }
}
