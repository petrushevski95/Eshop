using EShop.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ObjectPages
{
    public class HomePage : BasePage
    {
        private readonly By searchBar = By.Id("searchBar");
        private readonly By searchResultCount = By.Id("searchResultCount");
        private readonly By categoriesName = By.ClassName("k-group-title");
        private readonly By itemsList = By.ClassName("sub-category-cards");
        private readonly By nextImageButton = By.XPath("//*[@id=\"scrollView\"]/div[2]/span[2]");
        private readonly By imageList = By.CssSelector("#scrollView .k-scrollview-view img");
        public HomePage(IWebDriver driver, Actions actions) : base(driver, actions) { }
        
        public void enterTextInSearchBar(string text) 
        {
            sendTextToField(searchBar, text);
        }

        public void clickSearchBar()
        {
            clickOnElement(searchBar);
        }

        public bool isSearchResultCountDisplayed() 
        {
            waitUntilVisible(searchResultCount, 10);
            return isElementDisplayed(searchResultCount);
        }

        public void pressEnterKey()
        {
            pressEnterKey(searchBar);
        }

        public string getSearchResultNumber(int index) 
        {
            return getTextCharacterAsString(searchResultCount, index);
        }

        public bool isCategoriesNameDisplayed()
        {
            waitUntilVisible(categoriesName, 10);
            return isElementDisplayed(categoriesName);
        }

        public bool isItemListEmpty()
        {
            return isElementsListEmpty(itemsList);
        }

        public void clickNextButton()
        {
            clickOnElement(nextImageButton); 
        }

        public bool isHomeImageDisplayed(int ImageIndex)
        {
            IWebElement element = getElementFromList(imageList, ImageIndex);
            if (element != null && element.Displayed)
            {
                return true;
            }
            return false;
                             
        }



    }
}
