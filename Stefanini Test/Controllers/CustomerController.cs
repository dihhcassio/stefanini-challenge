using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Enums;
using Stefanini_Test.Domain.Services;
using Stefanini_Test.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stefanini_Test.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ISellerService _sellerService;
        public CustomerController(ICustomerService customerService, ISellerService sellerService)
        {
            _customerService = customerService;
            _sellerService = sellerService;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (Session["UserID"] == null)
            {
                filterContext.Result = RedirectToAction("Index", "Login");
                return;
            }

        }
        public ActionResult Index()
        {
            var model = new CustomerListModel();

            model.IsAdmin = (EUserRole)Session["UserRole"] == EUserRole.Administrator;

            var listSellers = _sellerService.FindSellers();
            model.Data.Sellers = listSellers.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }).ToList();

            List<Customer> listCustomer = null;
            if (model.IsAdmin)
                listCustomer = _customerService.FindAllCustomers();
            else
            {
                var seller = _sellerService.GetByUserId((int)Session["UserID"]);
                listCustomer = _customerService.FilterCustomers(null, null, null, null, null, seller.Id);
            }

            model.TableData = listCustomer.Select(c =>
            {
                var lastPurchase = c.Purchases.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
                return new CustomerItemDataModel()
                {
                    City = c.City,
                    Classification = c.Classification,
                    Gender = c.Gender,
                    LastPurchase = $"{lastPurchase.Id } - {lastPurchase.Date.ToShortDateString()} - {lastPurchase.Value}",
                    Name = c.Name,
                    Phone = c.Name,
                    Region = c.Region,
                    Seller = c.Seller.Name
                };
            }).ToList();

            return View("CustomerList", model);
        }

        public ActionResult Search(CustomerListModel model)
        {
            model.IsAdmin = (EUserRole)Session["UserRole"] == EUserRole.Administrator;

            var listSellers = _sellerService.FindSellers();
            model.Data.Sellers = listSellers.Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }).ToList();

            if (!model.IsAdmin)
            {
                var seller = _sellerService.GetByUserId((int)Session["UserID"]);
                model.Search.Seller = seller.Id;
            }

            DateTime? dateEnd = null;
            DateTime? dateStart = null;

            if (!string.IsNullOrEmpty(model.Search.DateStart) && !string.IsNullOrEmpty(model.Search.DateEnd))
            {
                DateTime datetimeEnd;
                DateTime datetimeStart;


                if (DateTime.TryParseExact(model.Search.DateStart, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetimeStart)
                    && DateTime.TryParseExact(model.Search.DateEnd, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetimeEnd)) 
                {
                    dateEnd = datetimeEnd;
                    dateStart = datetimeStart;
                }
            }


            var listCustomer = _customerService.FilterCustomers(model.Search.Name, model.Search.Gender, model.Search.City, model.Search.Region,
                model.Search.Classification, model.Search.Seller, dateStart, dateEnd);

            model.TableData = listCustomer.Select(c =>
            {
                var lastPurchase = c.Purchases.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
                return new CustomerItemDataModel()
                {
                    City = c.City,
                    Classification = c.Classification,
                    Gender = c.Gender,
                    LastPurchase = $"{lastPurchase.Id } - {lastPurchase.Date.ToShortDateString()} - {lastPurchase.Value}",
                    Name = c.Name,
                    Phone = c.Name,
                    Region = c.Region,
                    Seller = c.Seller.Name
                };
            }).ToList();

            model.IsAdmin = (EUserRole)Session["UserRole"] == EUserRole.Administrator;


            model.Search = new CustomerListSearchModel();

            return View("CustomerList", model);
        }

    }
}