package autoTestJavaFullObjects.pageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

/**
 * Created by Rafal on 2017-05-31.
 */
public class WpPagePost extends WpPage {

    private static final By COMMENT_BOX_LOCATOR = By.id("comment");
    private static final By EMAIL_BOX_LABEL_LOCATOR = By.cssSelector(".comment-form-email > label");
    private static final By EMAIL_BOX_LOCATOR = By.id("email");
    private static final By NAME_BOX_LABEL_LOCATOR = By.cssSelector(".comment-form-author > label");
    private static final By NAME_BOX_LOCATOR = By.id("author");
    private static final By POST_COMMENT_BUTTON_LOCATOR = By.id("comment-submit");
    private static final By COMMENT_CONTENT_LOCATOR = By.className("comment-content");

    public WpPagePost(WebDriver driver) {
        super(driver);
    }

    public void AddComment(String comment, String email, String name) {
        WaitUntilElementIsClickable(COMMENT_BOX_LOCATOR, driver);
        WebElement commentBox = driver.findElement(COMMENT_BOX_LOCATOR);
        commentBox.click();
        commentBox.clear();
        commentBox.sendKeys(comment);

        driver.findElement(EMAIL_BOX_LABEL_LOCATOR).click();
        WaitUntilElementIsNotVisible(EMAIL_BOX_LABEL_LOCATOR, driver);
        WebElement emailBox = driver.findElement(EMAIL_BOX_LOCATOR);
        emailBox.click();
        emailBox.clear();
        emailBox.sendKeys(email);

        driver.findElement(NAME_BOX_LABEL_LOCATOR).click();
        WaitUntilElementIsNotVisible(NAME_BOX_LABEL_LOCATOR, driver);
        WebElement nameBox = driver.findElement(NAME_BOX_LOCATOR);
        nameBox.click();
        nameBox.clear();
        nameBox.sendKeys(name);

        WaitUntilElementIsClickable(POST_COMMENT_BUTTON_LOCATOR, driver);
        WebElement postCommentButton = driver.findElement(POST_COMMENT_BUTTON_LOCATOR);
        postCommentButton.click();
    }

    public boolean AssertCommentIsPosted(String expectedCommentText, String name) {
        By postedCommentLocator = GetPostedCommentLocator(name);
        WaitUntilElementIsClickable(postedCommentLocator, driver);

        WebElement postedComment = driver.findElement(postedCommentLocator);
        String actualCommentText = GetCommentText(postedComment);

        return expectedCommentText.equals(actualCommentText);
    }

    private static By GetPostedCommentLocator(String authorName) {
        return By.xpath("//article[.//cite[text()='" + authorName + "']]");
    }

    private static String GetCommentText(WebElement comment) {
        WebElement commentContent = comment.findElement(COMMENT_CONTENT_LOCATOR);
        return commentContent.findElement(By.tagName("p")).getText();
    }
}
