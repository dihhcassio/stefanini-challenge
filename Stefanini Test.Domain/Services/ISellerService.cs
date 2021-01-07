using Stefanini_Test.Domain.Entities;
using System.Collections.Generic;

namespace Stefanini_Test.Domain.Services
{
    public interface ISellerService
    {
        List<Seller> FindSellers();

        Seller GetByUserId(int userId);
    }
}
