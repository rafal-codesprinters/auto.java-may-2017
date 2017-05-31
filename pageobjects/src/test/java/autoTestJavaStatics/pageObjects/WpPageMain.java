package autoTestJavaStatics.pageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

/**
 * Created by Kuba on 2017-05-30.
 */
public abstract class WpPageMain extends WpPage {

    private static final By POST_LINK_LOCATOR = By.className("entry-header");

    public static void Open(WebDriver driver) {
        driver.get(WpPage.MAIN_PAGE_URL);
        WpPage.WaitUntilFooterIsDisplayed(driver);
    }

    public static void DisplayPost(int postNumber, WebDriver driver) {
        By postLocator = GetPostLocator(postNumber);
        WebElement post = driver.findElement(postLocator);
        WebElement postLink = post.findElement(POST_LINK_LOCATOR);
        postLink.click();
    }

    private static By GetPostLocator(int postNumber) {
        return By.xpath("//article[" + postNumber + "]");
    }

}
