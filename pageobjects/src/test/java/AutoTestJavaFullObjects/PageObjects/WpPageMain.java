package AutoTestJavaFullObjects.PageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

/**
 * Created by Rafal on 2017-05-31.
 */
public class WpPageMain extends WpPage{

    private static final By POST_LINK_LOCATOR = By.className("entry-header");

    public WpPageMain(WebDriver driver) {
        super(driver);
    }

    public void Open() {
        driver.get(WpPage.MAIN_PAGE_URL);
    }

    public WpPagePost DisplayPost(int postNumber) {
        By postLocator = GetPostLocator(postNumber);
        WebElement post = driver.findElement(postLocator);
        WebElement postLink = post.findElement(POST_LINK_LOCATOR);
        postLink.click();
        return new WpPagePost(driver);
    }

    private static By GetPostLocator(int postNumber) {
        return By.xpath("//article[" + postNumber + "]");
    }
}
