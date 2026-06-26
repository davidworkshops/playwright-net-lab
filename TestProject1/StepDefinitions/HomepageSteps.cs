using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Reqnroll;

namespace TestProject1.StepDefinitions;

[Binding]
public class HomepageSteps : PageTest
{
    [Given("the user opens the Playwright homepage")]
    public async Task GivenTheUserOpensThePlaywrightHomepage()
    {
        await Page.GotoAsync("https://playwright.dev");
    }

    [Then("the page title contains {string}")]
    public async Task ThenThePageTitleContains(string expectedTitle)
    {
        await Expect(Page).ToHaveTitleAsync(new Regex(expectedTitle));
    }
}