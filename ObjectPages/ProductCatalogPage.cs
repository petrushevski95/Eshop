//using EShop.pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EShop.ObjectPages
//{
//    public class ProductCatalogPage : BasePage // locators for buttons does not work needed to be fixed
//    {
//        private readonly By refreshButton = By.XPath("//ul[@aria-label='Main menu']//li[@aria-label='Refresh']//a[@title='Refresh']");
//        private readonly By productCatalog = By.ClassName("trv-page-container");
//        private readonly By loadedPagesMessage = By.ClassName("trv-error-message");
//        private readonly By lastPageButton = By.XPath("//a[@data-command='telerik_ReportViewer_goToLastPage']");
//        public ProductCatalogPage(IWebDriver driver, Actions actions) : base(driver, actions) { }

//        public void clickRefreshButton()
//        {
//            waitUntilClickable(refreshButton, 10);
//            clickOnElement(refreshButton);
//        }

//        public void clickLastPageButton()
//        {
//            scrollDown(100);
//            waitUntilVisible(productCatalog, 10);
//            waitUntilClickable(lastPageButton, 10);
//            clickOnElement(lastPageButton);
//        }

//        public bool isProductCatalogDisplayed()
//        {
//            waitUntilVisible(loadedPagesMessage, 5);
//            return isElementDisplayed(loadedPagesMessage);          
//        }

      

       

        
//    }
//}
