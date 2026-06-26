using Microsoft.Playwright;
using Reqnroll;

namespace TestProject1.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var playwright = await Playwright.CreateAsync();

        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 500
        });

        var page = await browser.NewPageAsync();

        _scenarioContext["playwright"] = playwright;
        _scenarioContext["browser"] = browser;
        _scenarioContext["page"] = page;
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        var browser = _scenarioContext["browser"] as IBrowser;
        var playwright = _scenarioContext["playwright"] as IPlaywright;

        if (browser is not null)
            await browser.CloseAsync();

        playwright?.Dispose();
    }
}