using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Drawing;

namespace EShop.pages
{
    public abstract class BaseClass
    {
        protected IWebDriver driver;
        protected Actions actions;

        public BaseClass(IWebDriver driver, Actions actions) 
        { 
            this.driver = driver;
            this.actions = actions;
        }
            
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

        protected string getColor(By locator, string property)
        {
            IWebElement element = driver.FindElement(locator);
            string cssValue = element.GetCssValue(property);

            // Check if the cssValue is in rgb format
            if (cssValue.StartsWith("rgb"))
            {
                // Remove the "rgb(" or "rgba(" and the closing ")"
                cssValue = cssValue.Replace("rgb(", "").Replace("rgba(", "").Replace(")", "");

                // Split the string into R, G, B (and optionally A) components
                var colors = cssValue.Split(',');

                // Parse the R, G, B values
                int r = int.Parse(colors[0]);
                int g = int.Parse(colors[1]);
                int b = int.Parse(colors[2]);

                // Convert to Color object
                Color color = Color.FromArgb(r, g, b);

                // Return as hex string
                return ColorTranslator.ToHtml(color);
            }
            else
            {
                // Handle case for hex format color
                Color color = ColorTranslator.FromHtml(cssValue);
                return ColorTranslator.ToHtml(color);
            }
        }

        protected string getPseudoElementStyle(By locator, string pseudoElement, string property)
        {
            IWebElement element = driver.FindElement(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = $@" var elem = arguments[0];var pseudoElem = '{pseudoElement}'; 
                                var style = window.getComputedStyle(elem, pseudoElem).getPropertyValue('{property}');
                                return style;";
            string value = (string)js.ExecuteScript(script, element);
            return value;
        }

        protected void clearField(By locator)
        {
            driver.FindElement(locator).Clear();
        }

        protected void pressEnterKey(By locator) 
        {
            IWebElement element = driver.FindElement(locator);
            element.SendKeys(Keys.Enter);      
        }

        
    }
}


