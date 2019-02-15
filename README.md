# Checkout Code Kata
This project is an attempt to reproduce the Checkout CodeKata challenge.
The purpose of this code is to validate code isolation techniques (e.g. TDD, SRP, etc.)

## Technologies
* C#
* .NET Core
* NUnit

## Glossary
* **Checkout**: A system that calculates the total price of items
* **Cart Item**: A scanned product
* **Product**: SKU and Price
* **Price Rule**: Does calculation on top of a collection of Cart Items

## Business Requirements
* Prices are defined at startup
* Offers are defined at startup
* Each product has only one Offer
* Add items by scanning SKU's
* Invalid SKU's are ignored
* Offers can be evaluated in multiples (e.g 2 for 45, 4 for 90, etc.)

## Technical Requirements
* New offer strategies can be implemented (ex: discount per sku, discount on total)


## Credits
* https://github.com/Carnect/checkout
* https://rubygem.me/2014/01/16/shopping-cart-kata/
* http://codekata.com/kata/kata09-back-to-the-checkout/