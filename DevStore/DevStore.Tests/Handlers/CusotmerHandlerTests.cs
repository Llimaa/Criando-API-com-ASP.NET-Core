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
            command.Document = "70858024055";
            command.Email = "limaa@gmail.com";
            command.Phone = "9924343443";

            var handler = new CustomerCommandHandle(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}
