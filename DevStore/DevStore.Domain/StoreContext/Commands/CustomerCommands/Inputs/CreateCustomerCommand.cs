using FluentValidator;
using FluentValidator.Validation;
using System;

namespace DevStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FistName, 3, "firstName", "O nome deve ter no minimo 3 caracteres!")
                .HasMinLen(LastName, 3, "lastname", "O nome deve ter no minimo 3 caracteres!")
                .HasMaxLen(LastName, 30, "firstName", "O nome deve ter no maximo 30 caracteres!")
                .HasMaxLen(LastName, 30, "lastname", "O nome deve ter no maximo 30 caracteres!")
                .IsEmail(Email, "Email", "O E-mail é invalido")
                .HasMaxLen(Document, 11, "Document", "Documento Inválido")
                .HasMinLen(Document, 11, "Document", "Documento Inválido")
            );
            return Valid();
        }
    }
}