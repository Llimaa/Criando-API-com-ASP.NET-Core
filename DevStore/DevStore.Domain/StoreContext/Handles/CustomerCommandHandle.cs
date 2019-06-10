using DevStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DevStore.Domain.StoreContext.Commands.CustomerCommands.Output;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.ValueObjects;
using DevStore.Shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Domain.StoreContext.Handles
{
    public class CustomerCommandHandle : Notifiable, ICommandHandle<CreateCustomerCommand>,
        ICommandHandle<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se CPF ja existe na base.

            //Verificar se E-mail ja existe na base.

            //Criar VOs
            var name = new Name(command.FistName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar a entidade.
            var customer = new Customer(name, document, email, command.Phone);

            //Validar entidades e VOs.
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            //Persistir o criente.

            //Enviar um E-mail de boas vindas.

            //Retornar o resultado para a tela.
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
