# SeleniumAndCWebTestingShoppingSite

## Automation Test Framework setup to test a mock shopping site

### Initial 4 user stories produced and tested:
  
    - As a user if there is an item already inside my basket, <br> I want to be able to delete the item from the basket page, <br> so that I can see the basket is empty.

      **Acceptance Criteria:**
        - Shopping cart has Delete button
        - Item is removed from basket/cart
        - Banner must display 'Your shopping cart is empty'

    -As a user I want to select The 'Summer Dresses' option from the navigation menu, <br> so that i can view an item from the summer collection.

      **Acceptance Criteria:**
        - On mouse-hover button 'WOMAN', sub navigation options will appear
        - Summer items only display inside the search results

    - As a user when searching for a summer dress, <br> I want to change the proce range to $16-$20, <br> so that I can see the search results change.

      **Acceptance Criteria:**
        - Slider changes the price range
        - Search results are updated
        - Items returned are within the price range

    - As a user I want to create a new account <br> so that I can start buying items using my personal account.

      **Acceptance Criteria:**
        - Form can only accept valid information
        - Invalid inforamtion will give an error message
        - completing registration will take user to 'MY ACCOUNT' page
        - User can see account name on top right

