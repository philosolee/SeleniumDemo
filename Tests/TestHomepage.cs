using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    public class TestHomepage
    {
        private IWebDriver browser;
        private Homepage homepage;

        [OneTimeSetUp]
        public void SetupWebDriver()
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("http://www.demoqa.com");
            homepage = new Homepage(browser);            
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            browser.Quit();
        }

        [Test]
        public void ColumnName_UniqueAndClean_Exists()
        {
            Assert.IsTrue(homepage.ColumnWithHeaderExists("Unique & Clean"));
        }

        [Test]
        public void ColumnUniqueAndClean_ContainsCorrectText()
        {
            var expectedText = "Aliquam hendrit rutrum iaculis nullam ondimentum maluada velit beum donec sit amet";
            var actualText = homepage.ReadColumnContentText("Unique & Clean");

            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void ColumnCustomerSupport_ContainsCorrectImagePath()
        {
            var expectedImagePath = "http://demoqa.com/wp-content/uploads/2014/08/pattern-14-300x237.png";
            var actualImagePath = homepage.ReadColumnImagePath("Customer Support");

            Assert.AreEqual(expectedImagePath, actualImagePath);
        }

        [Test]
        public void Tab3_ContainsCorrectHeader()
        {
            var expectedHeaderText = "Content 3 Title";

            homepage.ClickTab3();
            var actualHeaderText = homepage.ReadTabThreeContentTitle();

            Assert.AreEqual(expectedHeaderText, actualHeaderText);
        }
    }
}
