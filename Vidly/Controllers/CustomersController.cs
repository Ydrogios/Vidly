﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            
            var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
        
        public ActionResult Insert()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            return View();
        }

    }
}