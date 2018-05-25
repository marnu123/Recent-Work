using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using BusinessLayer.Classes;
using BusinessLayer.Validators;

namespace SHSTests
{
    [TestClass]
    public class PersonValidatorTest
    {
        [TestMethod]
        public void ValidateTest()
        {
            Person p = new Person(1, "", "", "Shaun", "123");
            IEnumerable<string> broken;
            bool result = p.Validate(out broken);
            Assert.AreEqual(false, result);
            Assert.AreEqual(false, broken.Count() == 0);
        }
    }

    [TestClass]
    public class ProductSelectTest
    {
        [TestMethod]
        public void SelectProductsTest()
        {
            List<Product> list = Product.Select();
            Assert.AreEqual(true, list.Count > 0);
        }
    }

    [TestClass]
    public class ComponentSelectTest
    {
        [TestMethod]
        public void SelectComponentTest()
        {
            List<Component> comps = Component.Select();
            Assert.AreEqual(true, comps.Count > 0);

            if (comps.Count > 0)
            {
                Component c = comps[0];
                Assert.AreEqual(true, c.Configurations.Count > 0);
            }
        }
    }
}
