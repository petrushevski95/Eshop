﻿using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Drawing;

namespace EShop.pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected Actions actions;

        public BasePage(IWebDriver driver, Actions actions)
        {
            this.driver = driver;
            this.actions = actions;
        }

        protected void navigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        protected void moveAndClickOnTheElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            actions.MoveToElement(element).Click().Perform();
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
            try
            {
                IWebElement element = driver.FindElement(locator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
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

        protected void waitUntilClickable(By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        protected bool IsElementEnabled(By locator)
        {     
                IWebElement element = driver.FindElement(locator);
                return element.Enabled;       
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

        protected string getTextCharacterAsString(By locator, int index)
        {
            string stringElement = driver.FindElement(locator).Text;
            return stringElement[index].ToString();
        }

        protected List<IWebElement> getElementsList(By locator)
        {
            return driver.FindElements(locator).ToList();
        }

        protected IWebElement getElementFromList(By locator, int index)
        {
            List<IWebElement> elements = driver.FindElements(locator).ToList();
            if (index >= 0 && index < elements.Count)
            {
                return elements[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of range.");
            }
        }

        protected void clickElementFromList(By locator, int index)
        {
            try
            {
                List<IWebElement> elements = driver.FindElements(locator).ToList();
                if (index >= 0 && index < elements.Count)
                {
                    IWebElement elementToClick = elements[index];
                    elementToClick.Click();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of range.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Type: {ex.GetType().Name}");
            }
        }

        protected bool isElementsListEmpty(By locator)
        {
            try
            {
                List<IWebElement> webElements = driver.FindElements(locator).ToList();
                return webElements.Count == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Type: {ex.GetType().Name}");
                return false;
            }
        }

        protected void scrollDown(int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, arguments[0])", pixels);
        }

        // Combined dropdown and hover methods
        protected List<IWebElement> getDropdownOptions(By locator) 
        {
            IWebElement dropdownElement = driver.FindElement(locator);
            SelectElement select = new SelectElement(dropdownElement);
            return select.Options.ToList();
        }

        protected void selectDropdownOption(By dropdownLocator, int optionIndex)
        {
            IWebElement dropdownElement = driver.FindElement(dropdownLocator); 
            SelectElement select = new SelectElement(dropdownElement);
            select.SelectByIndex(optionIndex);
        }

        protected string getDropdownOptionText(By dropdownLocator, int optionIndex)
        {
            IWebElement dropdownElement = driver.FindElement(dropdownLocator);
            SelectElement select = new SelectElement(dropdownElement);
            select.SelectByIndex(optionIndex);
            IWebElement selectedOption = select.Options[optionIndex];
            return selectedOption.Text;  
        }

        protected void HoverOverButton(By locator)
        {
            IWebElement buttonElement = driver.FindElement(locator);
            actions.MoveToElement(buttonElement).Perform();
        }
    }
}
