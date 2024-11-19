using EShop.ObjectPages.utils;
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
        private readonly By topPicksList = By.CssSelector(".top-picks .top-pick-card");
        private readonly By topPicksTitle = By.Id("top-picks");
        private readonly By nextPageCategoryButton = By.XPath("//*[@id=\"topPicks\"]/div[1]/span[2]");
        private readonly By eShopLogo = By.XPath("/html/body/div[1]/a/img");
        private readonly By categoriesTitle = By.ClassName("categories-title");
        private readonly By bikesCaregoryImage = By.XPath("/html/body/main/div/div[3]/div[2]/div[2]/a[1]/img");
        private readonly By categoriyNameTItle = By.XPath("/html/body/main/div/div[1]");
        private readonly By downloadProductCatalogButton = By.Id("download-catalog");
        private readonly By productCatalog = By.ClassName("trv-page-container");
        private readonly By categoriesDropdown = By.XPath("//span[contains(text(), 'Categories')]");
        private readonly By accessoriesDropdownButton = By.LinkText("Accessories");
        private readonly By bikesDropdownButton = By.LinkText("Bikes");
        private readonly By clothesDropdownButton = By.LinkText("Clothes");
        private readonly By componentsDropdownButton = By.LinkText("Components");
        private readonly By favouritesButton = By.XPath("//a[@href='/kendo-ui/eshop/Account/Favorites']");
        private readonly By favouritesTitle = By.ClassName("favorites-title");
        private readonly By contactsButton = By.XPath("//a[@href='/kendo-ui/eshop/Contacts']");
        private readonly By contactTitle = By.ClassName("header-title");
        private readonly By profileIcon = By.Id("profile-btn");
        private readonly By profileDropdownButton = By.XPath("//a[@href='/kendo-ui/eshop/Account/Profile']");
        private readonly By accountTitle = By.ClassName("header-title");



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
            waitUntilVisible(searchResultCount, 20);
            return isElementDisplayed(searchResultCount);
        }

        public void pressEnterKey()
        {
            pressEnterKey(searchBar);
        }

        public string getSearchResultNumber()
        {
            return getTextCharacterAsString(searchResultCount, 0);
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

        public void clickNextImageButton()
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

        public void scrollDownToTopPicks()
        {
            scrollDown(500);
        }

        public void clickTopPicksCategory(int index)
        {
            clickElementFromList(topPicksList, index);
        }

        public void clickNextPageCategoryButton()
        {
            clickOnElement(nextPageCategoryButton);
        }

        public bool isOnTheTopPicksCategoryPage()
        {
            return isElementDisplayed(categoriyNameTItle);
        }

        public bool isTopPicksCategoryDisplayed()
        {
            return isElementDisplayed(topPicksTitle);
        }

        public void scrollDownToCategories()
        {
            scrollDown(1000);
        }

        public bool areCategoriesDisplayed()
        {
            return isElementDisplayed(categoriesTitle);
        }

        public void clickBikeCategoryImage() 
        {
            clickOnElement(bikesCaregoryImage);
        }

        public bool isOnTheBikeCategoryPage()
        {
            return isElementDisplayed(categoriyNameTItle);
        }

        public void clickDownloadProductCatalogButton()
        {
            clickOnElement(downloadProductCatalogButton);
        }

        public bool isOnTheProductCatalogPage()
        {
            waitUntilVisible(productCatalog, 5);
            return isElementDisplayed(productCatalog);
        }
        public void clickCategoriesButton()
        {
            waitUntilVisible(categoriesDropdown, 5);
            clickOnElement(categoriesDropdown);
        }

        public void clickAccessoriesButton()
        {   
            waitUntilVisible(accessoriesDropdownButton, 5);
            clickOnElement(accessoriesDropdownButton);
        }

        public bool isOnTheAccessoriesPage()
        {
            return isElementDisplayed(categoriyNameTItle);
        }

        public string getAccessoriesTitleText()
        {
            return getElementText(categoriyNameTItle);
        }

        public void clicBikesButton()
        {
            waitUntilVisible(bikesDropdownButton, 5);
            clickOnElement(bikesDropdownButton);
        }

        public bool isOnTheBikesPage()
        {
            return isElementDisplayed(categoriyNameTItle);
        }


        public string getBikesTitleText()
        {
            return getElementText(categoriyNameTItle);
        }

        public void clickClothesButton()
        {
            waitUntilVisible(clothesDropdownButton, 5);
            clickOnElement(clothesDropdownButton);
        }

        public string getClothesTitleText()
        {
            return getElementText(categoriyNameTItle);
        }

        public bool isOnTheClothesPage()
        {
            return isElementDisplayed(categoriyNameTItle);
        }

        public void clickComponentsButton()
        {
            waitUntilVisible(componentsDropdownButton, 5);
            clickOnElement(componentsDropdownButton);
        }

        public string getComponentsTitleText()
        {
            return getElementText(categoriyNameTItle);
        }

        public bool isOnTheComponentsPage()
        {
            return isElementDisplayed(categoriyNameTItle);
        }

        public void clickFavouritesButton()
        {
            clickOnElement(favouritesButton);
        }

        public bool isOnTheFavouritesPage()
        {   
            waitUntilVisible(favouritesButton, 5);
            return isElementDisplayed(favouritesTitle);
        }

        public string getFavouritesTitleText()
        {
            return getElementText(favouritesTitle);
        }

        public void clickContactsButton()
        {
            clickOnElement(contactsButton);
        }

        public bool isOnTheContactsPage()
        {
            waitUntilVisible(contactTitle, 5);
            return isElementDisplayed(contactTitle);
        }

        public string getContactTitleText()
        {
            return getElementText(contactTitle);
        }

        public void clickProfileButton()
        {
            clickOnElement(profileIcon);
        }

        public void clickProfileDropdownButton() 
        {
            waitUntilClickable(profileDropdownButton, 5);
            clickOnElement(profileDropdownButton);
        }

        public bool isOnTheProfilesPage()
        {
            waitUntilVisible(accountTitle, 5);
            return isElementDisplayed(accountTitle);
        }

        public string getProfileTitleText()
        {
            waitUntilVisible(accountTitle, 5);
            return getElementText(accountTitle);
        }
    }
}
