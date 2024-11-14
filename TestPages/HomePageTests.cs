using EShop.pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.ObjectPages;

namespace EShop.TestPages
{
    public class HomePageTests
    {
        private LoginPage loginPage;
        private IWebDriver driver;
        private RegisterPage registerPage;
        private HomePage homePage;
        private Actions actions;


        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            registerPage = new RegisterPage(driver, actions);
            loginPage = new LoginPage(driver, actions);
            homePage = new HomePage(driver, actions);

            loginPage.goToLoginPage();
            loginPage.clearEmailField();
            loginPage.enterEmail("jaxons.danniels@company.com");
            loginPage.clearPasswordField();
            loginPage.enterPassword("User1234");
            loginPage.clickEmailField();
            loginPage.pressEneterEmailField();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void searchBarTest()
        {
            homePage.enterTextInSearchBar("lights");
            homePage.pressEnterKey();
            Assert.That(homePage.isSearchResultCountDisplayed(), Is.True);
            Assert.That(homePage.getSearchResultNumber(), Is.EqualTo("3"));
            Assert.That(homePage.isCategoriesNameDisplayed(), Is.True);
            Assert.That(homePage.isItemListEmpty(), Is.False);

        }

        [Test]
        public void imageContentTest() 
        {
            homePage.clickNextImageButton();
            Assert.That(homePage.isHomeImageDisplayed(1), Is.True);
        }

        [Test]
        public void topPicksTest()
        {
            homePage.scrollDownToTopPicks();
            Assert.That(homePage.isTopPicksCategoryDisplayed(), Is.True);
            homePage.clickNextPageCategoryButton();
            homePage.clickTopPicksCategory(2);
            Assert.That(homePage.isOnTheTopPicksCategoryPage(), Is.True);
            
        }

        [Test]
        public void categoriesTest()
        {
            homePage.scrollDownToCategories();
            Assert.That(homePage.areCategoriesDisplayed(), Is.True);
            homePage.clickBikeCategoryImage();
            Assert.That(homePage.isOnTheBikeCategoryPage(), Is.True);
        }   

        [Test] 
        public void downloadProductCatalogButton()
        {
            homePage.scrollDownToCategories();
            homePage.clickDownloadProductCatalogButton();
            Assert.That(homePage.isOnTheProductCatalogPage(), Is.True);
        }
    }
}
