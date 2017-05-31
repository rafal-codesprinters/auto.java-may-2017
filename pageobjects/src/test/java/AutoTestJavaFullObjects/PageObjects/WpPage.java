package AutoTestJavaFullObjects.PageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

/**
 * Created by Rafal on 2017-05-31.
 */
public abstract class WpPage {

    protected WebDriver driver;
    public static final String MAIN_PAGE_URL = "http://autotestjava.wordpress.com";

    public WpPage(WebDriver driver) {
        this.driver = driver;
    }

    protected static void WaitForElementPresent(By byLocator, WebDriver driver) {
        WebDriverWait wait = new WebDriverWait(driver, 20);
        wait.until(ExpectedConditions.elementToBeClickable(byLocator));
    }
}
