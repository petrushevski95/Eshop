using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.pages;

namespace EShop.tests
{
    [TestFixture]
    internal class RegisterPageTests
    {
        private IWebDriver driver;
        private RegisterPage registerPage;

        [SetUp]
        public void SetUp()
        {
          
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            registerPage = new RegisterPage(driver);
            registerPage.goToRegisterPage();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void successfulRegisterTest()
        {
            registerPage.enterFirstAndLastName("Test Test");
            registerPage.enterEmail("test123@mail.com");
            registerPage.enterPassword("Password123");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.isOnTheLoginPage(), Is.True);
        }

        [Test]
        public void unsuccessfulRegisterEmptyFirstNameAndLastNameField()
        {
            registerPage.enterEmail("test123@mail.com");
            registerPage.enterPassword("Password123");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getEnterFirstNameAndLastNameErrorMessage(), Is.EqualTo("Please enter First and Last name"));
        }
        
        [Test]
        public void unsuccessfulRegisterEmptyEmailField()
        {
            registerPage.enterFirstAndLastName("Test Test");
            registerPage.enterPassword("Password123");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getEmailErrorMessage(), Is.EqualTo("Email is required"));
        }

        [Test]
        public void unsuccessfulRegisterEmptyPaswordField()
        {
            registerPage.enterFirstAndLastName("Test Test");
            registerPage.enterEmail("test123@mail.com"); 
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getPasswordErrorMessage(), Is.EqualTo("Please enter password"));
        }

        [Test]
        public void unsuccessfulRegisterInvalidFirstNameAndLastNameField()
        {
            registerPage.enterFirstAndLastName("TestTest");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getEnterFirstNameAndLastNameErrorMessage(), Is.EqualTo("Please enter First and Last name separated by a space"));
        }

        [Test]
        public void unsuccessfulRegisterInvalidEmailField()
        {
            registerPage.enterEmail("test123.mail.com");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getEmailErrorMessage(), Is.EqualTo("Email is not valid email"));
        }

        [Test]
        public void unsuccessfulRegisterInvalidPasswordField()
        {
            registerPage.enterPassword("test");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getPasswordErrorMessage(), Is.EqualTo("Email is not valid email"));
        }

        [Test]
        public void unsuccessfulRegisterUserAlreadyExistsTest()
        {
            registerPage.enterFirstAndLastName("Test Test");
            registerPage.enterEmail("test123@mail.com");
            registerPage.enterPassword("Password123");
            registerPage.clickOnRegisterButton();
            Assert.That(registerPage.getValidationErrorMessage(), Is.EqualTo("User already exists"));
        }


    }
    

}

