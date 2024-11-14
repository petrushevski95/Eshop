using EShop.ObjectPages.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.pages
{
    public class LoginPage : BasePage
    {
        private readonly By emailField = By.Id("Email");
        private readonly By passwordField = By.Id("Password");
        private readonly By loginButton = By.XPath("//button[contains(text(), 'Login')]");
        private readonly By emailErrorMessage = By.Id("Email-form-error");
        private readonly By passwordErrorMessage = By.Id("Password-form-error");
        public LoginPage(IWebDriver driver, Actions actions) : base(driver, actions) { }

        public void goToLoginPage()
        {
            navigateTo(PageUrls.Login_Page_Url);
        }

        public void clearEmailField()
        {
            clearField(emailField);
        }

        public void clearPasswordField()
        {
            clearField(passwordField);
        }

        public void enterEmail(string email)
        {
            sendTextToField(emailField, email);
        }

        public void enterPassword(string password)
        {
            sendTextToField(passwordField, password);
        }

        public void clickLoginButton()
        {
            clickOnElement(loginButton);
            
        }

        public bool isOntheHomePage()
        {
            return isOnThePage(PageUrls.Home_Page_Url);
        }

        public void clickEmailField()
        {
            clickOnElement(emailField);
        }

        public void pressEneterEmailField()
        {
            pressEnterKey(emailField);
        }

        public string getEmailErrorMessage()
        {
            return getElementText(emailErrorMessage);
        }

        public string getPasswordErrorMessage()
        {
            return getElementText(passwordErrorMessage);
        }

        public void clickPasswordField()
        {
            clickOnElement(passwordField);
        }

        public string getEmailFieldBorderColor()
        {
            return getPseudoElementStyle(emailField, "::after", "--INTERNAL--kendo-input-border");
        }
    }
}
