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
        private string url = "http://www.demoqa.com";

        private By mainColumnLocator = By.Id("main");
        private By entryHeaderLocator = By.ClassName("entry-title");

        //Columns
        private By columnsLocator = By.ClassName("col-md-4");
        private By columnHeaderLocator = By.TagName("h5");
        private By columnTextLocator = By.TagName("p");
        private By columnImageLinkLocator = By.TagName("a");
        private By columnImageLocator = By.TagName("img");

		// Tabbed Content
        private By tab1Locator = By.Id("ui-id-1");
        private By tab2Locator = By.Id("ui-id-2");
        private By tab3Locator = By.Id("ui-id-3");
        private By tab4Locator = By.Id("ui-id-4");
        private By tab5Locator = By.Id("ui-id-5");

        private By tab1Content = By.Id("tabs-1");
        private By tab2Content = By.Id("tabs-2");
        private By tab3Content = By.Id("tabs-3");
        private By tab4Content = By.Id("tabs-4");
        private By tab5Content = By.Id("tabs-5");

        private By tabContentTitleLocator = By.TagName("b");
        private By tabContentBodyLocator = By.TagName("p");
    }
}
