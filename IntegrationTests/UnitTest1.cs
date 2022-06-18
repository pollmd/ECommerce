using MagazinCore.Models.ViewModels;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expected = 120;
            var r = new ProdusPlus();
            r.Cost = 100;
            r.Tva = 10;
            r.Reducere = 5;
            r.Acciz = 10;

            var result = r.CalculPret();

            Assert.Equal(result, expected);
        }

        [Fact]
        public void CheckIfCreatePageExists()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://pyapp4.herokuapp.com/");
        }
    }
}
