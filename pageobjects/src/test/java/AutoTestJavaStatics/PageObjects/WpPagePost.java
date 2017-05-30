package AutoTestJavaStatics.PageObjects;

import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

/**
 * Created by Kuba on 2017-05-30.
 */
public class WpPagePost extends WpPage{

    private static final By COMMENT_BOX_LOCATOR = By.id("comment");
    private static final By EMAIL_BOX_LOCATOR = By.id("email");
    private static final By NAME_BOX_LOCATOR = By.id("author");
    private static final By POST_COMMENT_BUTTON_LOCATOR = By.id("comment-submit");
    private static final By COMMENT_CONTENT_LOCATOR = By.className("comment-content");

    public static void AddComment(String comment, String email, String name, WebDriver driver) {
        WaitForElementPresent(COMMENT_BOX_LOCATOR, driver);

        WebElement commentBox = driver.findElement(COMMENT_BOX_LOCATOR);
        commentBox.click();
        commentBox.clear();
        commentBox.sendKeys(comment);

        WebElement emailBox = driver.findElement(EMAIL_BOX_LOCATOR);
        emailBox.click();
        emailBox.clear();
        emailBox.sendKeys(email);

        WebElement nameBox = driver.findElement(NAME_BOX_LOCATOR);
        nameBox.click();
        nameBox.clear();
        nameBox.sendKeys(name);

        WebElement postCommentButton = driver.findElement(POST_COMMENT_BUTTON_LOCATOR);
        postCommentButton.click();
    }

    public static void AssertCommentIsPosted(String expectedCommentText, String name, WebDriver driver) {
        By postedCommentLocator = By.xpath("//article[.//cite[text()='" + name + "']]");
        WaitForElementPresent(postedCommentLocator, driver);

        WebElement postedComment = driver.findElement(postedCommentLocator);
        String actualCommenText = postedComment.findElement(COMMENT_CONTENT_LOCATOR).findElement(By.tagName("p")).getText();

        Assert.assertEquals(expectedCommentText, actualCommenText);
    }

}
