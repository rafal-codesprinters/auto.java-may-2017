using autoTestJavaFullObjects.PageObjects;
using Xunit;

namespace autoTestJavaFullObjects
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
            WpMainPage mainPage = new WpMainPage(this.driver);
            mainPage.Open();
            WpPostPage postPage = mainPage.DisplayPost(3);
            postPage.AddComment(commentText, commentAuthorEmail, commentAuthorName);

            //THEN / ASSERT
            Assert.True(postPage.IsCommentPosted(commentText, commentAuthorName));
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
            WpMainPage mainPage = new WpMainPage(this.driver);
            mainPage.Open();
            WpPostPage postPage = mainPage.DisplayPost(1);
            postPage.AddComment(commentText, commentAuthorEmail, commentAuthorName);
            postPage.AddReplyToComment(commentText, commentAuthorName, replyText, replyAuthorEmail, replyAuthorName);

            //THEN / ASSERT
            Assert.True(postPage.IsReplyPosted(commentText, commentAuthorName, replyText, replyAuthorName));
        }
    }
}
