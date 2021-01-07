using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stefanini_Test.Models
{
    public class CustomerListModel
    {
        public CustomerListSearchModel Search { get; set; }
        public CustomerListDataModel Data { get; set; }

        public List<CustomerItemDataModel> TableData { get; set; }

        public CustomerListModel()
        {
            Search = new CustomerListSearchModel();
            Data = new CustomerListDataModel();
            TableData = new List<CustomerItemDataModel>();
        }

        public bool IsAdmin { get; set; }
    }

    public class CustomerListSearchModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public ECustomerClassification? Classification { get; set; }
        public ECustumerGender? Gender { get; set; }
        public int Seller { get; set; }

    }

    public class CustomerListDataModel
    {
        public List<SelectListItem> Sellers { get; set; }

        public CustomerListDataModel()
        {
            Sellers = new List<SelectListItem>();
        }
    }

    public class CustomerItemDataModel
    {
        public ECustomerClassification Classification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ECustumerGender Gender { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string LastPurchase { get; set; }
        public string Seller { get; set; }
    }
}