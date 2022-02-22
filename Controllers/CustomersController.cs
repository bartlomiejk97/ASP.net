using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp_Gr3.Models;
using LibApp_Gr3.ViewModels;
using LibApp_Gr3.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "StoreManager")]
        public ViewResult Index()
        {
            return View();
        }

        [Authorize(Roles = "StoreManager")]
        public IActionResult Details(int id)
        {
            bool canEdit = User.IsInRole("StoreManager") || User.IsInRole("Owner");
            var _entity = CustomerService.GetItem(id);

            return View(new CustomerDetailsViewModel()
            {
                Customer = _entity,
                CanEdit = canEdit
            });
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