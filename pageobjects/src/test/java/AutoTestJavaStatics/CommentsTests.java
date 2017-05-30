package AutoTestJavaStatics;

import AutoTestJavaStatics.PageObjects.WpPageMain;
import AutoTestJavaStatics.PageObjects.WpPagePost;
import org.junit.Test;
import java.util.UUID;

/**
 * Created by Kuba on 2017-05-30.
 */
public class CommentsTests extends BaseTests{

    @Test
    public void ShouldAddCommentToThirdPost() {

        // GIVEN / ARRANGE
        String comment = generateRandomText();
        String email = UUID.randomUUID().toString() + "@test.com";
        String name = UUID.randomUUID().toString();

        //WHEN / ACT
        WpPageMain.Open(driver);
        WpPageMain.DisplayPost(3, driver);
        WpPagePost.AddComment(comment, email, name, driver);

        //THEN / ASSERT
        WpPagePost.AssertCommentIsPosted(comment, name, driver);
    }
}
