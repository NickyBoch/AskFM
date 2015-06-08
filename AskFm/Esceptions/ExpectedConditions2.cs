#region Usages

using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

#endregion

namespace AskFm.Base.Extensions
{
    public static class ExpectedConditions2
    {

        /// <summary>
        /// An expectation for checking that an element is either invisible or not
        /// present on the DOM.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns><see langword="true"/> when the element is invisible or not present; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebDriver, bool> ElementIsInvisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed || (element.Size.Height == 0) || (element.Size.Width == 0);
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that amount of elements is greater or equals to expected amount.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="expAmount">The expected amount of the elements found by locator.</param>
        /// <returns><see langword="true"/> when the amount of the elements less than expected amount, otherwise <see langword="false"/>.</returns>
        public static Func<IWebDriver, bool> ElementsAmount(By locator, int expAmount)
        {
            return (driver) =>
            {
                try
                {
                    return driver.FindElements(locator).Count <= expAmount;
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that function returns true.
        /// </summary>
        /// <param name="func">The function that returns true when some condition achieved</param>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns></returns>
        public static Func<IWebDriver, bool> Condition(Func<IWebElement, bool> func, By locator)
        {
            return (driver) =>
            {
                try
                {
                    var elem = driver.FindElement(locator);
                    return func(elem);
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that an element is either invisible or not
        /// present on the DOM.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns><see langword="true"/> when the element is invisible or not present; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebDriver, bool> ElementsIsInvisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var elements = driver.FindElements(locator);
                    return elements.Aggregate(true, (current, element) => current && (!element.Displayed || (element.Size.Height == 0) || (element.Size.Width == 0)));

                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        /// <summary>
        /// An expectation for checking whether an element is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located, visible and clickable.</returns>
        public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
        {
            return driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    var location = element.Location;
                    Thread.Sleep(500);
                    return (element.Displayed && element.Enabled && element.Location.Equals(location)) ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, IWebElement> PresenceOfElementLocated(By locator)
        {
            return (Func<IWebDriver, IWebElement>)(driver =>
            {
                try
                {
                    return driver.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        public static Func<IWebDriver, bool> AbsenceOfElementLocated(By locator)
        {
            return (Func<IWebDriver, bool>)(driver =>
            {
                try
                {
                    driver.FindElement(locator);
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

    }
}
