using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp_Gr3.Models;
using LibApp_Gr3.ViewModels;
using LibApp_Gr3.Services;

namespace LibApp_Gr3.Controllers
{
    public class CustomersController : Controller
    {
        protected CustomerService CustomerService { get; }
        protected MembershipTypeService MembershipTypeService { get; }
        public CustomersController(CustomerService customerService, MembershipTypeService membershipTypeService)
        {
            CustomerService = customerService;
            MembershipTypeService = membershipTypeService;
        }
        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var _entity = CustomerService.GetItem(id);

            return View(_entity);
        }

        public IActionResult Form(int? id)
        {
            if (id.HasValue)
            {
                var _entity = CustomerService.GetItem(id.Value);
                return View(new CustomerFormViewModel(_entity)
                {
                    MembershipTypes = MembershipTypeService.GetList()
                });
            }
            else
            {
                return View(new CustomerFormViewModel()
                {
                    MembershipTypes = MembershipTypeService.GetList()
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = MembershipTypeService.GetList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                CustomerService.Insert(customer);
            }
            else
            {
                CustomerService.Update(customer.Id, customer);
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}