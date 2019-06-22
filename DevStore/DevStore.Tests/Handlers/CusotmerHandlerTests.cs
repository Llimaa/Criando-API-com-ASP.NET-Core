using DevStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DevStore.Domain.StoreContext.Handles;
using DevStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DevStore.Tests.Handlers
{
    [TestClass]
    public class CusotmerHandlerTests
    {

        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FistName = "marcos";
            command.LastName = "Lima";
            command.Document = "232323233345643";
            command.Email = "limaa@gmail.com";
            command.Phone = "23234";

            Assert.AreEqual(true, command);

            var handler = new CustomerCommandHandle(new FakeCustomerRepository(), new FakeEmailService());
        }
    }
}
