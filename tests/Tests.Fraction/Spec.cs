using System;
using NUnit.Framework;

namespace Tests.Fractions
{

    public class Spec
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp() {
            SetUp();
            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown() {
            TearDown();
        }

        public virtual void SetUp() {}

        public virtual void TearDown() {}

        public virtual void Arrange() {}

        public virtual void Act() {}

        protected Action Invoking(Action func) {
            return func;
        }
    }
}
