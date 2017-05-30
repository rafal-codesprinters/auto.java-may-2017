package AutoTestJavaStatics.PageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

/**
 * Created by Kuba on 2017-05-30.
 */
public abstract class WpPage {

    public static final String MAINT_PAGE_URL = "http://autotestjava.wordpress.com";

    protected static void WaitForElementPresent(By byLocator, WebDriver driver) {
        WebDriverWait wait = new WebDriverWait(driver, 20);
        wait.until(ExpectedConditions.elementToBeClickable(byLocator));
    }

}
