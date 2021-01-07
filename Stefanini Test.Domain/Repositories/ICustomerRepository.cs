using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Domain.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> FindAll();
        List<Customer> Filter(string name, ECustumerGender? gender, string city, string region, ECustomerClassification? classification, int seller, DateTime? datetimeStart = null, DateTime? datetimeEnd= null);
    }
}
