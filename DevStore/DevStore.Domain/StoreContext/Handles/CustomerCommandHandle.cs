using DevStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DevStore.Domain.StoreContext.Commands.CustomerCommands.Output;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Repositoties;
using DevStore.Domain.StoreContext.Services;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandle(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se CPF ja existe na base.
            if(_customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "O CPF ja esta em uso!");

            //Verificar se E-mail ja existe na base.
            if(_customerRepository.CHeckEmail(command.Email))
                AddNotification("Email","Este e-mail ja esta em uso!");

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

            if (Invalid)
                return null;
            //Persistir o criente.
            _customerRepository.Save(customer);
            //Enviar um E-mail de boas vindas.
            _emailService.send(command.Email, "lima@gmail.com","Bem vindo", "Seja bem vindo ao Dev Store!");

            //Retornar o resultado para a tela.
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
