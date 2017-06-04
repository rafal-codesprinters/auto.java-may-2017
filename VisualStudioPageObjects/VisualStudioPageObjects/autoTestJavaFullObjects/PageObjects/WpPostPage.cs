using OpenQA.Selenium;

namespace autoTestJavaFullObjects.PageObjects
{
    class WpPostPage : WpPage
    {
        private static readonly By LOCATOR_COMMENT_BOX = By.Id("comment");
        private static readonly By LOCATOR_COMMENT_EMAIL_BOX_HINT = By.CssSelector(".comment-form-email > label");
        private static readonly By LOCATOR_COMMENT_EMAIL_BOX = By.Id("email");
        private static readonly By LOCATOR_COMMENT_NAME_BOX_HINT = By.CssSelector(".comment-form-author > label");
        private static readonly By LOCATOR_COMMENT_NAME_BOX = By.Id("author");
        private static readonly By LOCATOR_COMMENT_POST_BUTTON = By.Id("comment-submit");
        private static readonly By LOCATOR_COMMENT_REPLY_LINK = By.ClassName("comment-reply-link");

        private static readonly By LOCATOR_REPLY_BOX = By.Id("comment");
        private static readonly By LOCATOR_REPLY_EMAIL_BOX = By.Id("email");
        private static readonly By LOCATOR_REPLY_NAME_BOX = By.Id("author");
        private static readonly By LOCATOR_REPLY_POST_BUTTON = By.Id("comment-submit");

        public WpPostPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddComment(string commentText, string commentAuthorEmail, string commentAuthorName)
        {
            WaitUntilElementIsClickable(LOCATOR_COMMENT_BOX, driver);
            IWebElement commentBox = driver.FindElement(LOCATOR_COMMENT_BOX);
            commentBox.Click();
            commentBox.Clear();
            commentBox.SendKeys(commentText);

            WaitUntilElementIsClickable(LOCATOR_COMMENT_EMAIL_BOX_HINT, driver);
            IWebElement emailBoxHint = driver.FindElement(LOCATOR_COMMENT_EMAIL_BOX_HINT);
            emailBoxHint.Click();
            WaitUntilElementIsHidden(LOCATOR_COMMENT_EMAIL_BOX_HINT, driver);
            IWebElement emailBox = driver.FindElement(LOCATOR_COMMENT_EMAIL_BOX);
            emailBox.Click();
            emailBox.Clear();
            emailBox.SendKeys(commentAuthorEmail);

            WaitUntilElementIsClickable(LOCATOR_COMMENT_NAME_BOX_HINT, driver);
            IWebElement nameBoxHint = driver.FindElement(LOCATOR_COMMENT_NAME_BOX_HINT);
            nameBoxHint.Click();
            WaitUntilElementIsHidden(LOCATOR_COMMENT_NAME_BOX_HINT, driver);
            IWebElement nameBox = driver.FindElement(LOCATOR_COMMENT_NAME_BOX);
            nameBox.Click();
            nameBox.Clear();
            nameBox.SendKeys(commentAuthorName);

            WaitUntilElementIsClickable(LOCATOR_COMMENT_POST_BUTTON, driver);
            IWebElement postButton = driver.FindElement(LOCATOR_COMMENT_POST_BUTTON);
            postButton.Click();
            WaitUntilElementIsHidden(LOCATOR_COMMENT_POST_BUTTON, driver);
        }

        public bool IsCommentPosted(string commentText, string commentAuthorName)
        {
            By commentLocator = GetPostedCommentLocator(commentText, commentAuthorName);
            try
            {
                driver.FindElement(commentLocator);
                return true;
            }
            catch (NoSuchElementException exception)
            {
                return false;
            }
        }

        private By GetPostedCommentLocator(string commentText, string commentAuthorName)
        {
            return By.XPath("//li/article[.//cite[text()='" + commentAuthorName + "'] and .//p[text()='" + commentText + "']]");
        }

        public void AddReplyToComment(string commentText, string commentAuthorName, string replyText, string replyAuthorEmail, string replyAuthorName)
        {
            By commentLocator = GetPostedCommentLocator(commentText, commentAuthorName);
            IWebElement postedComment = driver.FindElement(commentLocator);
            IWebElement replyLink = postedComment.FindElement(LOCATOR_COMMENT_REPLY_LINK);
            replyLink.Click();

            WaitUntilElementIsClickable(LOCATOR_REPLY_BOX, driver);
            IWebElement replyBox = driver.FindElement(LOCATOR_REPLY_BOX);
            replyBox.Click();
            replyBox.Clear();
            replyBox.SendKeys(replyText);

            IWebElement emailBox = driver.FindElement(LOCATOR_REPLY_EMAIL_BOX);
            emailBox.Click();
            emailBox.Clear();
            emailBox.SendKeys(replyAuthorEmail);

            IWebElement nameBox = driver.FindElement(LOCATOR_REPLY_NAME_BOX);
            nameBox.Click();
            nameBox.Clear();
            nameBox.SendKeys(replyAuthorName);

            WaitUntilElementIsClickable(LOCATOR_REPLY_POST_BUTTON, driver);
            IWebElement postButton = driver.FindElement(LOCATOR_REPLY_POST_BUTTON);
            postButton.Click();
            WaitUntilElementIsHidden(LOCATOR_REPLY_POST_BUTTON, driver);
        }

        private By GetPostedReplyLocator(string replyText, string replyAuthorName)
        {
            return By.XPath("//article[.//cite[text()='" + replyAuthorName + "'] and .//p[text()='" + replyText + "']]");
        }

        public bool IsReplyPosted(string commentText, string commentAuthorName, string replyText, string replyAuthorName)
        {
            By commentLocator = GetPostedCommentLocator(commentText, commentAuthorName);
            IWebElement postedComment = driver.FindElement(commentLocator);
            By replyLocator = GetPostedReplyLocator(replyText, replyAuthorName);
            try
            {
                postedComment.FindElement(replyLocator);
                return true;
            }
            catch (NoSuchElementException exception)
            {
                return false;
            }
        }
    }
}