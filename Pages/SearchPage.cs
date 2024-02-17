using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAddToCartProject.Pages
{
    internal class SearchPage
    {
        private IWebDriver driver;
        private string searchResultPrice;
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string SelectItemAndGetPrice(string key)
        {
            Thread.Sleep(5000);
            // Find all the search results
            var searchResults = driver.FindElements(By.XPath("//div[@data-component-type='s-search-result']"));

            // Iterate through each search result
            foreach (var result in searchResults)
            {
                var titleElement = result.FindElement(By.XPath(".//h2[@class='a-size-mini a-spacing-none a-color-base s-line-clamp-2']//a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']"));

                // Check if the title contains the specified key
                if (titleElement.Text.Contains(key))
                {
                    Console.WriteLine($"Found the item on the page: {titleElement.Text}");

                    // Get the price of the item
                    var priceElement = result.FindElement(By.XPath(".//span[@class='a-price']"));
                    searchResultPrice = priceElement.Text;

                    var actions = new Actions(driver);

                    // Scroll to the element
                    actions.MoveToElement(result).Perform();

                    By title = By.LinkText(titleElement.Text);

                    driver.FindElement(title).Click();
                    break; // Exit the loop once found
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }
            }
            return searchResultPrice;
        }
    }
}
