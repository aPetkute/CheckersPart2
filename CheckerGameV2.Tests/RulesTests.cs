using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerGameV2.Tests
{
    [TestClass]
    public class RulesTests
    {
        [TestMethod]
        public void IsInBoard_ShouldReturnTrue()
        {
            var rules = new Rules(8);
        }
    }
}
