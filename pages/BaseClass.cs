using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoQaFrontEnd.pages
{
    public abstract class BaseClass
    {
        protected IWebDriver driver;
        public BaseClass(IWebDriver driver) { this.driver = driver; }

        protected void navigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        protected void clickOnElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        protected bool isOnThePage(string url)
        {
            return driver.Url.Equals(url, StringComparison.OrdinalIgnoreCase);
        }

        protected string getElementText(By locator)
        {
            return driver.FindElement(locator).Text;
        }

        protected bool isElementDisplayed(By locator)
        {
            return driver.FindElement(locator).Displayed;
        }

        protected void sendTextToField(By locator, string value)
        {
            driver.FindElement(locator).SendKeys(value);
        }

        protected void waitUntilVisible(By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected void waitUntilClicable(By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

       
    }
}
