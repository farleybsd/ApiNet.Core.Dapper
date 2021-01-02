using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private Name invalidName;
        private Name validaName;
        public NameTests()
        {
            invalidName = new Name("", "Rufino");
            validaName = new Name("Farley", "Rufino");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            Assert.AreEqual(1, invalidName.Notifications.Count);
            Assert.AreEqual(false, invalidName.IsValid);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsValid()
        {
            Assert.AreEqual(0, validaName.Notifications.Count);
            Assert.AreEqual(true, validaName.IsValid);
        }
    }
}
