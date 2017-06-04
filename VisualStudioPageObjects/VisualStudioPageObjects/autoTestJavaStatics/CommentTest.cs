using autoTestJavaStatics.PageObjects;
using Xunit;

namespace autoTestJavaStatics
{
    public class CommentTest : BaseTests
    {
        [Fact]
        public void ShouldAddCommentToThirdPost()
        {
            // GIVEN / ARRANGE
            string commentText = GenerateRandomText();
            string commentAuthorEmail = GenerateRandomEmail();
            string commentAuthorName = GenerateRandomName();

            //WHEN / ACT
            WpMainPage.Open(driver);
            WpMainPage.DisplayPost(3, driver);
            WpPostPage.AddComment(commentText, commentAuthorEmail, commentAuthorName, driver);

            //THEN / ASSERT
            Assert.True(WpPostPage.IsCommentPosted(commentText, commentAuthorName, driver));
        }

        [Fact]
        public void ShouldAddReplyToComment()
        {
            // GIVEN / ARRANGE
            string commentText = GenerateRandomText();
            string commentAuthorEmail = GenerateRandomEmail();
            string commentAuthorName = GenerateRandomName();

            string replyText = GenerateRandomText();
            string replyAuthorEmail = GenerateRandomEmail();
            string replyAuthorName = GenerateRandomName();

            //WHEN / ACT
            WpMainPage.Open(driver);
            WpMainPage.DisplayPost(3, driver);
            WpPostPage.AddComment(commentText, commentAuthorEmail, commentAuthorName, driver);
            WpPostPage.AddReplyToComment(commentText, commentAuthorName, replyText, replyAuthorEmail, replyAuthorName, driver);

            //THEN / ASSERT
            Assert.True(WpPostPage.IsReplyPosted(commentText, commentAuthorName, replyText, replyAuthorName, driver));
        }
    }
}
