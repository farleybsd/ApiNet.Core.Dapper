using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document inValidDocument;
        public DocumentTests()
        {
            validDocument= new Document("11405263679");
            inValidDocument = new Document("12345678910");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentisNotValid()
        {
            
            Assert.AreEqual(1, inValidDocument.Notifications.Count);
            Assert.AreEqual(false, inValidDocument.IsValid);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentisValid()
        {
            
            Assert.AreEqual(0, validDocument.Notifications.Count);
            Assert.AreEqual(true, validDocument.IsValid);
        }
    }
}