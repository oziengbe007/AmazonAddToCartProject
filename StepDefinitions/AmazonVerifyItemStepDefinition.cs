using AmazonAddToCartProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using Tesseract;

namespace AmazonAddToCartProject.StepDefinitions
{
    [Binding]
    public class AmazonVerifyItemSteps
    {
        IWebDriver driver;
        string searchResultPrice;
        HomePage homepage;
        SearchPage searchpage;
        CartPage cartpage;
        CartSummaryPage cartsummaryPage;
        ProductPage productpage;

        [Given(@"I am on amazon")]
        public void GivenIAmOnAmazon()
        {
            //Initialize, launch, and maximize the browser.
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.amazon.com/";
            Thread.Sleep(20000);
        }

        [When(@"I search for (.*)")]
        public void WhenISearchFor(string searchKey)
        {
            //Search for the item by writing the search term in the search box in the HomePage 
            Thread.Sleep(5000);
            homepage = new HomePage(driver);
            homepage.searchItem(searchKey);
        }

        [When(@"I select item")]
        public void WhenISelectItem()
        {
            //Scroll to the Item with TL-WR940N and Select the item.
            Thread.Sleep(4000);
            searchpage = new SearchPage(driver);
            searchResultPrice = searchpage.SelectItemAndGetPrice("TL-WR940N");
        }

        [When(@"I add item to cart")]
        public void WhenIAddItemToCart()
        {
            //Click on the Add to Cart button
            Thread.Sleep(4000);
            productpage = new ProductPage(driver);
            productpage.ClickAddToCartButton();

            //Click on the gotocart button
            Thread.Sleep(4000);
            cartsummaryPage = new CartSummaryPage(driver);
            cartsummaryPage.ClickGoToCartButton();
        }

        [Then(@"I verify the item name and price")]
        public void ThenIVerifyTheItemNameAndPrice()
        {
            Thread.Sleep(4000);
            //get the price of the product in the product page
            cartpage = new CartPage(driver);
            var price = cartpage.GetProductPrice();
        
            //format the price gotten from the search price
            string formattedSearchResultPrice = searchResultPrice.Replace("\r\n", ".");

            Console.WriteLine($"Price in Search Page: {formattedSearchResultPrice}");
            Console.WriteLine($"Price in Shopping Cart: {price}");

            //verify that the price is consistent across the search page and cart page
            Assert.That(formattedSearchResultPrice.Trim(), Is.EqualTo(price.Trim())); 

            Console.WriteLine("Assertion passed: Prices are equal.");
            driver.Quit();
        }
    }
}
