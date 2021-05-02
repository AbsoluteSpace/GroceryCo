## GroceryCo

This is a kiosk checkout system for GroceryCo.

I used VSCode to create this project, and if you want to run/test it as I have, you can do so by navigating to the GroceryCo/GroceryCo directory and typing `dotnet run` in the VSCode terminal.
To test, navigate to the GroceryCo/GroceryCoTest directory and type `dotnet test`.

The program once started will ask you whether you want to checkout or close down the kiosk. Every time a customer chooses to checkout, the kiosk will look for new price information which can be updated as the program is running in the prices/prices.txt file. To prevent the program from reading the entire price catalog everytime, known price information is cleared from this file so that only new information is found. These prices exist for the duration of the program and the format of the prices.txt file is a comma seperated list of `item_name:price:sale_price` where `sale_price` is only included if the item is on sale.

The customer's basket is represented by groceries/groceries.txt which is an unordered comma seperated list of items. This can also be changed as the program is running.

## Design Choices and Assumptions

Instead of just having the price catalog be a dictionary where the key is the item's name and the value it's cost, I chose to wrap the cost as what I've called an Item so that it contain more things like the sale price, best before date, and so on which should make extending the kiosk's functionality easier.

I've made the assumption that the last price given for an item (assuming it's valid) is the correct price, so for example if multiple prices are given for a single item in one prices.txt, I just use the latest.

The main method has options for more key presses because I was trying to think of what a real kiosk might have, and I wanted to make it easy to add more things like "Scan membership card."

## What I'd like to keep adding

I wasn't able to completely finish my unit tests and I would like to uncomment the checkout tests to have them read what is printed to the console to verify it's output. I planned to add two of these checkout tests, one that looks at the output when every item in the cart is present in the price catalog and another where items can't be found.


