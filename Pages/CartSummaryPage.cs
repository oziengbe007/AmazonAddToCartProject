using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAddToCartProject.Pages
{
    internal class CartSummaryPage
    {
        private IWebDriver driver;

        public CartSummaryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CartPage ClickGoToCartButton()
        {
            // Wait for the "Add to Cart" button to be clickable
            var goToCart = driver.FindElement(By.XPath("//*[@id=\"sw-gtc\"]/span/a"));
            goToCart.Click();
            return new CartPage(driver);
        }

    }
}
