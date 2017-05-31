package autoTestJavaStatics.pageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

/**
 * Created by Kuba on 2017-05-30.
 */
public abstract class WpPagePost extends WpPage{

    private static final By COMMENT_BOX_LOCATOR = By.id("comment");
    private static final By EMAIL_BOX_LABEL_LOCATOR = By.cssSelector(".comment-form-email");
    private static final By EMAIL_BOX_LOCATOR = By.id("email");
    private static final By NAME_BOX_LABEL_LOCATOR = By.cssSelector(".comment-form-author");
    private static final By NAME_BOX_LOCATOR = By.id("author");
    private static final By POST_COMMENT_BUTTON_LOCATOR = By.id("comment-submit");
    private static final By COMMENT_CONTENT_LOCATOR = By.className("comment-content");

    public static void AddComment(String comment, String email, String name, WebDriver driver) {
        WaitForElementPresent(COMMENT_BOX_LOCATOR, driver);
        WebElement commentBox = driver.findElement(COMMENT_BOX_LOCATOR);
        commentBox.click();
        commentBox.clear();
        commentBox.sendKeys(comment);

        driver.findElement(EMAIL_BOX_LABEL_LOCATOR).click();
        WaitForElementPresent(EMAIL_BOX_LOCATOR, driver);
        WebElement emailBox = driver.findElement(EMAIL_BOX_LOCATOR);
        emailBox.click();
        emailBox.clear();
        emailBox.sendKeys(email);

        driver.findElement(NAME_BOX_LABEL_LOCATOR).click();
        WaitForElementPresent(NAME_BOX_LOCATOR, driver);
        WebElement nameBox = driver.findElement(NAME_BOX_LOCATOR);
        nameBox.click();
        nameBox.clear();
        nameBox.sendKeys(name);

        WaitForElementPresent(POST_COMMENT_BUTTON_LOCATOR, driver);
        WebElement postCommentButton = driver.findElement(POST_COMMENT_BUTTON_LOCATOR);
        postCommentButton.click();
    }

    public static boolean IsCommentPosted(String expectedCommentText, String name, WebDriver driver) {
        By postedCommentLocator = GetPostedCommentLocator(name);
        WaitForElementPresent(postedCommentLocator, driver);

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
