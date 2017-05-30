package AutoTestJavaStatics.PageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

/**
 * Created by Kuba on 2017-05-30.
 */
public class WpPageMain extends WpPage {

    public static void Open(WebDriver driver) {
        driver.get(WpPage.MAINT_PAGE_URL);
    }

    public static void DisplayPost(int postNumber, WebDriver driver) {
        WebElement post = driver.findElement(By.xpath("//article[" + postNumber + "]"));
        WebElement postLink = post.findElement(By.className("entry-header"));
        postLink.click();
    }

}
