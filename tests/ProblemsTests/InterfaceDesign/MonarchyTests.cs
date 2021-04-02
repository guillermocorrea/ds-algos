using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Problems.InterfaceDesign;
using Xunit;

namespace ProblemsTests.InterfaceDesign
{
    public class MonarchyTests
    {
        [Fact]
        public void CanAddChildCorrectly()
        {
            // Given
            var monarchy = new Monarchy("Jake");

            // When
            monarchy.Birth("Catherine", "Jake");
            monarchy.Birth("Jane", "Catherine");
            monarchy.Birth("Farah", "Jane");
            monarchy.Birth("Tom", "Jake");
            monarchy.Birth("Celine", "Jake");
            monarchy.Birth("Mark", "Catherine");
            monarchy.Birth("Peter", "Celine");

            // Then
            var orderOfSuccession = monarchy.GetOrderOfSuccession();
            Assert.Equal(new List<string> { "Jake", "Catherine", "Jane", "Farah", "Mark", "Tom", "Celine", "Peter" }, orderOfSuccession);

            monarchy.Death("Jake");
            monarchy.Death("Jane");
            Assert.Equal(new List<string> { "Catherine", "Farah", "Mark", "Tom", "Celine", "Peter" },
                monarchy.GetOrderOfSuccession());
        }
    }
}