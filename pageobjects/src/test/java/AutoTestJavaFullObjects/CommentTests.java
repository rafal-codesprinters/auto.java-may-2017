package AutoTestJavaFullObjects;

import AutoTestJavaFullObjects.PageObjects.WpPageMain;
import AutoTestJavaFullObjects.PageObjects.WpPagePost;
import org.junit.Assert;
import org.junit.Test;

import java.util.UUID;

import static AutoTestJavaStatics.PageObjects.WpPageMain.Open;

/**
 * Created by Rafal on 2017-05-31.
 */
public class CommentTests extends BaseTests {

    @Test
    public void ShouldAddCommentToThirdPost() {

        // GIVEN / ARRANGE
        String comment = generateRandomText();
        String email = UUID.randomUUID().toString() + "@test.com";
        String name = UUID.randomUUID().toString();

        //WHEN / ACT
        WpPageMain mainPage = new WpPageMain(this.driver);
        mainPage.Open();
        WpPagePost postPage = mainPage.DisplayPost(3);
        postPage.AddComment(comment, email, name);

        //THEN / ASSERT
        Assert.assertTrue("Comment should be posted", postPage.AssertCommentIsPosted(comment, name));
    }

}
