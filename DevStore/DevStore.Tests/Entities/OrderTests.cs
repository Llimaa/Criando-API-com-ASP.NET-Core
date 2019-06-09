
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevStore.Tests
{

    [TestClass]
    public class OrderTests
    {
        // Consigo criar um novo pedido.
        [TestMethod]
        public void ShouldCreatedOrderWhenValid()
        {
            Assert.Fail();
        }

        // Ao criar o pedido, o status deve ser created.
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.Fail();
        }

        // Ao adiconar um novo item, a quantidade de items deve mudar.
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            Assert.Fail();
        }

        // Ao adicionar um novo item, deve subtrar a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItems()
        {
            Assert.Fail();
        }

        // Ao confirmar pedido, deve gerar um numero.
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            Assert.Fail();
        }

        // Ao apagar um pedido o status deve ser PAGO.
        [TestMethod]
        public void ShouldReturnPaiWhenOrderPaid()
        {
            Assert.Fail();
        }

        // Dados 10 produtos, deve haver 2 entegas.
        [TestMethod]
        public void ShouldWhenPurChasedTenProductos()
        {
            Assert.Fail();
        }

        // Ao cancelar o pedido, o status deve ser cancelado.
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            Assert.Fail();
        }

        // AO cancelar o pedido, deve cancelar as entregas.
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCancel()
        {
            Assert.Fail();
        }
    }
}