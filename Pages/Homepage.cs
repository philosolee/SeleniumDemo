using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumDemo.Pages
{
    public partial class Homepage
    {
        private IWebDriver driver;
        public Homepage(IWebDriver browser)
        {
            driver = browser;
            driver.WaitForElementToBeVisible(entryHeaderLocator);
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }


        public bool ColumnWithHeaderExists(string expectedColumnHeader)
        {
            var columns = driver.FindElements(columnsLocator);

            foreach (IWebElement column in columns)
            {
                if (column.FindElement(columnHeaderLocator).Text == expectedColumnHeader)
                {
                    return true;
                }
            }

            return false;
        }

        private IWebElement FindColumnUsingHeaderText(string columnHeader)
        {
            if (!ColumnWithHeaderExists(columnHeader))
            {
                throw new NoSuchElementException($"Column Header {columnHeader} doesn't exist on the page");
            }

            var columns = driver.FindElements(columnsLocator);

            return columns.Where(x => x.FindElement(columnHeaderLocator).Text == columnHeader).FirstOrDefault();
        }


        #region Read Element Details

        public string ReadColumnImagePath(string columnHeader)
        {
            IWebElement column = FindColumnUsingHeaderText(columnHeader);

            return column.FindElement(columnImageLocator).GetAttribute("src");
        }

        public string ReadColumnContentText(string columnHeader)
        {
            IWebElement column = FindColumnUsingHeaderText(columnHeader);

            var pTagsInColumn = column.FindElements(columnTextLocator);

            // Gets P Tag where no children and returns it's text
            return pTagsInColumn.Where(x => x.FindElements(By.CssSelector("*")).Count == 0).FirstOrDefault().Text;

        }

        public string ReadTabThreeContentTitle()
        {
            if (!driver.ElementIsDisplayed(tab3Content))
            {
                throw new ElementNotVisibleException("Tab 3 isn't visible, have you clicked to display it first?");
            }

            var tabParagraphs = driver.FindElement(tab3Content).FindElements(tabContentTitleLocator);

            foreach (IWebElement p in tabParagraphs)
            {
                if (!string.IsNullOrEmpty(p.Text))
                {
                    return p.Text;
                }
            }

            return "";
        }
        #endregion

        #region Clicking Elements
        public void ClickTab1()
        {
            driver.FindElement(tab1Locator).Click();
        }

        public void ClickTab2()
        {
            driver.FindElement(tab2Locator).Click();
        }

        public void ClickTab3()
        {
            driver.FindElement(tab3Locator).Click();
        }

        public void ClickTab4()
        {
            driver.FindElement(tab4Locator).Click();
        }

        public void ClickTab5()
        {
            driver.FindElement(tab5Locator).Click();
        }
        #endregion
    }
}
