using DevStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Marcos","Lima","00000000000,","teste@gmail.com","99128592","endereco");

            var order = new Order(c);
        }
    }
}