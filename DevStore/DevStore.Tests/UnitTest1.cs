using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Macos", "Lima");
            var document = new Document("00000000000");
            var email = new Email("teste@gmail.com");
            var customer = new Customer(name, document, email, "1111-0000");

            var mouse = new Product("Mouse", "Rato", "mouse.img", 59.90M, 10);
            var teclado = new Product("teclado", "teclado", "teclado.img", 59.90M, 10);
            var cadeira = new Product("cadeira", "cadeira", "cadeira.img", 500.30M, 10);
            var fone = new Product("fone", "fone", "fone.img", 350, 10);

            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(cadeira, 5));
            order.AddItem(new OrderItem(fone, 5));

            //simular compra do pedido.
            order.Place();

            //Verificar se o pedido é valido.
            var valid = order.IsValid;

            //Simular Pagamento.
            order.Pay();

            // Simular o envio
            order.Ship();

            // Simular o cancelamento
            order.Cancel();
        }
    }
}