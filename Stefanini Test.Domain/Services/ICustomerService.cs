using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Domain.Services
{
    public interface ICustomerService
    {
        List<Customer> FindAllCustomers();
        List<Customer> FilterCustomers(string name, ECustumerGender? gender, string city, string region, ECustomerClassification? classification, int seller, DateTime? dateStart = null, DateTime? dateEnd = null);
    }
}
