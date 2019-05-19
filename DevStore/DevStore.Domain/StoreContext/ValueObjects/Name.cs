using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string fistName, string lastName)
        {
            FistName = fistName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FistName, 3, "firstName", "O nome deve ter no minimo 3 caracteres!")
                .HasMinLen(LastName, 3, "lastname", "O nome deve ter no minimo 3 caracteres!")

                .HasMaxLen(LastName, 30, "firstName", "O nome deve ter no maximo 30 caracteres!")
                .HasMaxLen(LastName, 30, "lastname", "O nome deve ter no maximo 30 caracteres!")
            );
        }

        public string FistName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FistName} {LastName}";
        }
    }
}
