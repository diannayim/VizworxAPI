# Vizworx Code Challenge

**Disclaimer**: Most of the error checking for this application has not been done. Some of the assumptions are written below but it assumes almost perfect user input with this system and no fatal errors occurring.

## How to Run
Tests have been automated in two ways. The first is running the application normally, which pulls up a webpage. Clicking the button "Run Full Example" will display the meal order provided the information in the example. The second is the automated unit tests that have been implemented. Running VizworxAPI.Tests will run through the unit tests that I have implemented to check some of the functions that I have made.

## Assumptions

* All restaurant names are unique.
* Ratings are integers.
* If two restaurants have the same rating, it doesn't matter which restaurant gets chosen for the meal order.
* There are always enough meals to satisify the meal orders over the restaurant list.
* Restaurants do not need to be removed from the list.

## Things to Note
* If you simply refresh the page, it does not refresh the HTML context and will not work when you run the full example. Please re-run the program if retesting.
