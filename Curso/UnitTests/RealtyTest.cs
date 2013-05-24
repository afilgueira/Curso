namespace UnitTests
{
    using Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for Realty domain object
    /// </summary>
    [TestClass]
    public class RealtyTest
    {
        /// <summary>
        /// Gets or sets the Test context
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// The Manager
        /// </summary>
        private Manager manager;

        /// <summary>
        /// The Realty
        /// </summary>
        private Realty realty;

        #region Additional test attributes

        /// <summary>
        /// Runs before each test
        /// </summary>
        [TestInitialize]
        public void OnSetup()
        {
            this.manager = new Manager("name", 50);
            this.realty = new Realty("address", "details", this.manager);

            // TIP: consider using a test helper to avoid repeating code
        }

        /// <summary>
        /// Runs after each test
        /// </summary>
        [TestCleanup]
        public void OnTearDown()
        {
        }

        #endregion

        /// <summary>
        /// Tests the constructor
        /// </summary>
        [TestMethod]
        public void TestCreate()
        {
            // Este test anda bien
            Assert.AreEqual("address", this.realty.Address);
            Assert.AreEqual("details", this.realty.Details);
            Assert.AreEqual(this.manager, this.realty.Manager);
            Assert.IsTrue(this.manager.Realties.Contains(this.realty));
            Assert.IsTrue(this.realty.Homes.Count == 0);
        }

        /// <summary>
        /// Tests the update method
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            // Este test anda mal... ¿porqué?
            var newManager = new Manager("name2", 25);
            this.realty.Update("address2", "details2", newManager);

            Assert.AreEqual("address2", this.realty.Address);
            Assert.AreEqual("details2", this.realty.Details);
            Assert.AreEqual(newManager, this.realty.Manager);
            Assert.IsFalse(this.manager.Realties.Contains(this.realty));
            
            // Además falta verificar algo...
        }

        /// <summary>
        /// Tests the delete method
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            this.realty.Delete();
            Assert.IsFalse(this.manager.Realties.Contains(this.realty));
        }
    }
}
