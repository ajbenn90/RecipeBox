/**
 * Scrapes ingredients from https://food.ndtv.com/ingredient and saves the data to a txt.
 * There's a high likelihood that the website will update, and the scraping will need to be rewritten.
 * Author: Alex Bennett
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Keys = OpenQA.Selenium.Keys;

namespace IngredientScraper
{
    public partial class IngredientScraperForm : Form
    {
        private readonly IWebDriver driver;
        private readonly List<string> ingredients;

        public IngredientScraperForm()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            if (driver == null)
            {
                logTextBox.Text = "Starting Chrome driver";
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
                driver.Manage().Window.Maximize();
                PrintLine("Driver up");
            }

            ingredients = new();
        }

        private void OnApplicationExit(object? sender, EventArgs e) {
            if (driver != null)
            {
                PrintDashedLine();
                PrintLine("Closing driver");
                try
                {
                    driver.Quit();
                }
                catch
                { }
            }
        }

        private void scrapeButton_Click(object sender, EventArgs e)
        {
            PrintDashedLine();
            ScrapeIngredients();
        }

        private void ScrapeIngredients()
        {
            ingredients.Clear();
            driver.Navigate().GoToUrl("https://food.ndtv.com/ingredient");

            // Close obnoxious pop up if it appears
            try
            {
                PrintLine("Will close pop up if it appears");
                var closeButton = driver.FindElement(By.PartialLinkText("No, thanks!"));
                closeButton.Click();
            }
            catch
            {
                PrintLine("Annoying pop up hopefully didn't appear");
            }

            try
            {
                var linkBoxes = driver.FindElements(By.ClassName("IngrCrd_wrp"));
                PrintLine("Found " + linkBoxes.Count + " ingredient links");

                foreach (var linkBox in linkBoxes )
                {
                    try
                    {
                        PrintDashedLine();
                        // Print name of section
                        PrintLine("Getting ingredient category name");
                        var category = linkBox.FindElement(By.ClassName("IngrCrd_txt")).Text;
                        PrintLine(category);
                    }
                    catch
                    {
                        PrintLine("Couldn't find ingredient category name");
                    }
                    try
                    {
                        // Open link in new tab
                        PrintLine("Opening link in new tab");
                        var initialTab = driver.CurrentWindowHandle;
                        var link = linkBox.FindElement(By.ClassName("IngrCrd_im"));
                        link.SendKeys(Keys.Control + Keys.Enter);
                        driver.SwitchTo().Window(driver.WindowHandles.Last());

                        // Hit "Load more" button until it no longer appears
                        try
                        {
                            PrintLine("Looking for 'Load more' button");
                            var loadBtnWrapper = driver.FindElement(By.Id("pagination"));
                            var loadBtn = loadBtnWrapper.FindElement(By.PartialLinkText("Load more"));
                            PrintLine("Clicking 'Load more' button until it's gone");
                            while (loadBtn.Displayed)
                            {
                                loadBtn.Click();
                                // Need to pause b/c button briefly disappears as it loads
                                Thread.Sleep(1000);
                            }
                        }
                        catch
                        {
                            PrintLine("Unable to find or click 'Load more' button");
                        }

                        // Read all the ingredients
                        try
                        {
                            PrintLine("Finding ingredients");
                            var ingredientElements = driver.FindElements(By.ClassName("IngrLst-Ar_ttl"));
                            PrintLine("Found " + ingredientElements.Count + " ingredients");
                            foreach (var ingredientElement in ingredientElements)
                            {
                                string ingredient = ingredientElement.Text.Trim();
                                PrintLine(ingredient);
                                ingredients.Add(ingredient);
                            }
                        }
                        catch
                        {
                            PrintLine("Unable to find ingredients");
                        }

                        // Switch back to main page
                        PrintLine("Closing tab and switching back to main page");
                        driver.Close();
                        driver.SwitchTo().Window(initialTab);
                    }
                    catch
                    {
                        PrintLine("Unable to open link in new tab");
                    }
                }
            }
            catch
            {
                PrintLine("Unable to find ingredient links");
            }
            PrintDashedLine();
            PrintLine("Done! :)");
        }

        private async void toTxtButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new()
            {
                Filter = "txt|*.txt",
                Title = "Save ingredients to txt"
            };
            dlg.ShowDialog();

            PrintDashedLine();

            if (dlg.FileName != "")
            {
                PrintLine("Saving to " + dlg.FileName);

                try
                {
                    using StreamWriter file = new(dlg.FileName);
                    foreach (string ingredient in ingredients)
                        await file.WriteLineAsync(ingredient);
                    PrintLine("Done! :)");
                }
                catch (Exception ex)
                {
                    PrintLine("Something went wrong :(");
                    PrintLine(ex.Message);
                }
            }
            else
                PrintLine("Save cancelled");
        }

        private void PrintLine(string line)
        {
            logTextBox.Text += Environment.NewLine + line;
        }

        /// <summary>
        /// Prints a dashed line in the log text box
        /// </summary>
        private void PrintDashedLine()
        {
            PrintLine("-----------------------------------");
        }
    }
}