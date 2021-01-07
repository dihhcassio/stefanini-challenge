using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Enums;
using Stefanini_Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }
        public List<Customer> FilterCustomers(string name, ECustumerGender? gender, string city, string region, ECustomerClassification? classification, int seller, DateTime? dateStart =null, DateTime? dateEnd= null)
        {
            return _customerRepository.Filter(name, gender, city, region, classification, seller, dateStart, dateEnd);
        }

        public List<Customer> FindAllCustomers()
        {
            return _customerRepository.FindAll();
        }
    }
}
