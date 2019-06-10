using DevStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Domain.StoreContext.Commands.CustomerCommands.Output
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult()
        {

        }
        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
