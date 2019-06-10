using DevStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.LastName = "Marcos";
            command.FistName = "Lima";
            command.Document = "56605261011";
            command.Email = "marcosLima@gmail.com";
            command.Phone = "11999999999";

            Assert.AreEqual(true, command.Valid());
        }

        public void ShouldValidateWhenCommandIsNotValid()
        {
            var command = new CreateCustomerCommand();
            command.LastName = "Marcos";
            command.FistName = "Lima";
            command.Document = "";
            command.Email = "marcosLima@gmail.com";
            command.Phone = "";

            Assert.AreEqual(false, command.Valid());
        }
    }
}
