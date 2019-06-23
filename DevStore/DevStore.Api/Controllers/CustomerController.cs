using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace DevStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Marcos", "Lima");
            var document = new Document("69475408010");
            var email = new Email("lima@gmail.com");
            var customer = new Customer(name, document, email, "991285912");
            var customers = new List<Customer>();
            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Marcos", "Lima");
            var document = new Document("69475408010");
            var email = new Email("lima@gmail.com");
            var customer = new Customer(name, document, email, "991285912");

            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Marcos", "Lima");
            var document = new Document("69475408010");
            var email = new Email("lima@gmail.com");
            var customer = new Customer(name, document, email, "991285912");
            var order = new Order(customer);
            var mouse = new Product("Mouse", "Mouse Game", "mouse.png", 100M, 10);
            var monitor = new Product("Monitor", "Monitor Game", "monitor.png", 100M, 10);
            order.AddItem(monitor, 5);
            order.AddItem(mouse, 5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FistName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FistName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!" };
        }
    }
}