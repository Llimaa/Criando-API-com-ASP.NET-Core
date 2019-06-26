using System;
using System.Collections.Generic;
using DevStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DevStore.Domain.StoreContext.Commands.CustomerCommands.Output;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Handles;
using DevStore.Domain.StoreContext.Queries;
using DevStore.Domain.StoreContext.Repositoties;
using DevStore.Domain.StoreContext.ValueObjects;
using DevStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Api.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerCommandHandle _handle;
        public CustomerController(ICustomerRepository customerRepository, CustomerCommandHandle handle)
        {
            _customerRepository = customerRepository;
            _handle = handle;
        }

        [HttpGet]
        [Route("customers")]
        [ResponseCache(Duration =60)]//em minutos.
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _customerRepository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryRepository GetById(Guid id)
        {
            return _customerRepository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrderResult> GetOrders(Guid id)
        {
            return _customerRepository.GetOrdes(id);
        }

        [HttpPost]
        [Route("customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handle.Handle(command);
            return result;
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