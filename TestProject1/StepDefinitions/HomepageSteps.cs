using Microsoft.Playwright;
using Reqnroll;
using TestProject1.Pages;

namespace TestProject1.StepDefinitions;

[Binding]
public class HomepageSteps
{
    private readonly ScenarioContext _scenarioContext;

    public HomepageSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the user opens the Playwright homepage")]
    public async Task GivenTheUserOpensThePlaywrightHomepage()
    {
        var page = _scenarioContext.Get<IPage>("page");

        var homePage = new HomePage(page);
        await homePage.NavigateAsync();
    }

    [Then("the page title contains {string}")]
    public async Task ThenThePageTitleContains(string expectedTitle)
    {
        var page = _scenarioContext.Get<IPage>("page");

        await Assertions.Expect(page)
            .ToHaveTitleAsync(new Regex(expectedTitle));
    }

}