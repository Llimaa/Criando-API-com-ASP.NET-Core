
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevStore.Domain.StoreContext.ValueObjects;
using Document = DevStore.Domain.StoreContext.ValueObjects.Document;

[TestClass]
public class DocumentTests
{
    private Document _documentValid;
    private Document _documentInvalid;

    public DocumentTests()
    {
        _documentValid = new Document("56605261011");
        _documentInvalid = new Document("12345678910");
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsNotValid()
    {
        Assert.AreEqual(false, _documentInvalid.IsValid);
        Assert.AreEqual(1, _documentInvalid.Notifications.Count);
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsValid()
    {
        Assert.AreEqual(true, _documentValid.IsValid);
    }
}