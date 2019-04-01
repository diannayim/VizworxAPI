using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VizworxAPI.Tests.Controllers
{
    [TestClass]
    public class HelperFunctionTests
    {
        /// <summary>
        /// Check if the normal numbers of meals are added correctly.
        /// </summary>
        [TestMethod]
        public void TestGetNumberOfNormalMeals()
        {
            int actual = HelperFunctions.GetNumberOfNormalMeals(40, new Dictionary<string, int> { { "vegetarian", 4 } });
            Assert.AreEqual(36, actual);
        }
    }
}
