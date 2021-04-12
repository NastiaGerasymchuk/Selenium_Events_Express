using OpenQA.Selenium;
using SeleniumTest.EventsExpressTests.Pages;

namespace SeleniumTest.EventsExpressTests
{
    public class AuthorInfo:BaseClass
    {
        private string xAuthor;
        private string xAuthorName= "/div/div/a/div/div[2]/h5";
        private By authorName;
        private By authorBtn;

        public AuthorInfo(IWebDriver driver,int order):base(driver)
        {
            int authorOrder =order * 2;//order of Author is mpy* 2 order info about author
            xAuthor = $"/html/body/div[{authorOrder}]/div[3]/ul/li";
            authorBtn = Xpath(xAuthor);
            authorName = Xpath(xAuthor+xAuthorName);
        }
        public string GetAuthorTitle()
        {
            return Text(authorName);
        }
        public HomeEvent AuthorClick()
        {
            Click(authorBtn);
            return new HomeEvent(driver);
        }
    }
}

