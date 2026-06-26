using Microsoft.Playwright;

namespace TestProject1.Pages;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public Task NavigateAsync()
    {
        return _page.GotoAsync("https://playwright.dev");
    }
}