//using EShop.ObjectPages;
//using EShop.pages;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EShop.TestPages
//{

//    public class ProductCatalogPageTests 
//    {
//        private LoginPage loginPage;
//    private IWebDriver driver;
//    private RegisterPage registerPage;
//    private HomePage homePage;
//    private ProductCatalogPage productCatalogPage;
//    private Actions actions;

//    [SetUp]
//    public void setUp()
//    {
//        driver = new ChromeDriver();
//        driver.Manage().Window.Maximize();

//        registerPage = new RegisterPage(driver, actions);
//        loginPage = new LoginPage(driver, actions);
//        homePage = new HomePage(driver, actions);
//        productCatalogPage = new ProductCatalogPage(driver, actions);

//        loginPage.goToLoginPage();
//        loginPage.clearEmailField();
//        loginPage.enterEmail("jaxons.danniels@company.com");
//        loginPage.clearPasswordField();
//        loginPage.enterPassword("User1234");
//        loginPage.clickEmailField();
//        loginPage.pressEneterEmailField();
//        homePage.scrollDownToCategories();
//        homePage.clickDownloadProductCatalogButton();
//    }

//    [TearDown]
//    public void TearDown()
//    {
//        driver.Quit();
//    }

//    [Test]
//    public void refreshButtonTest()
//    {
//        productCatalogPage.clickRefreshButton();
//        Assert.That(productCatalogPage.isProductCatalogDisplayed(), Is.True);
//    }

//    [Test]
//    public void lastPageButton()
//    {

//        productCatalogPage.clickLastPageButton();


//    }
//}
//}
