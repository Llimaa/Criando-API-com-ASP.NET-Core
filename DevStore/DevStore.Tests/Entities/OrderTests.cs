
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Enums;
using DevStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevStore.Tests
{

    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keybord;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Marcos", "Lima");
            var document = new Document("69475408010");
            var email = new Email("lima@gmail.com");
            _customer = new Customer(name, document, email, "991285912");
            _order = new Order(_customer);

            _mouse = new Product("Mouse", "Mouse Game", "mouse.png", 100M, 10);
            _chair = new Product("Chair", "Chair Game", "chair.png", 100M, 10);
            _keybord = new Product("Keybord", "Keybord Game", "Keybord.png", 100M, 10);
            _monitor = new Product("Monitor", "Monitor Game", "monitor.png", 100M, 10);
        }
        // Consigo criar um novo pedido.
        [TestMethod]
        public void ShouldCreatedOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser created.
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adiconar um novo item, a quantidade de items deve mudar.
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrar a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItems()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // Ao confirmar pedido, deve gerar um numero.
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao apagar um pedido o status deve ser PAGO.
        [TestMethod]
        public void ShouldReturnPaiWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados 10 produtos, deve haver 2 entegas.
        [TestMethod]
        public void ShouldWhenPurChasedTenProductos()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado.
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // AO cancelar o pedido, deve cancelar as entregas.
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCancel()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Cancel();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }

        }
    }
}