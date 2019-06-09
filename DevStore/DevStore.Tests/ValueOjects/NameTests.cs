
using DevStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevStore.Tests
{

    [TestClass]
    public class NameTests
    {

        [TestMethod]
        public void ShoulReturnNotificationWhenNameIsValid()
        {
            var name = new Name("Marcos", "Lima");
            Assert.AreEqual(true, name.IsValid);
        }

        [TestMethod]
        public void ShoulReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "lima");
            Assert.AreEqual(false, name.IsValid);
        }
    }
}