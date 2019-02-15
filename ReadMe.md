
# ASP.NET MVC5 Project - Second Hand Store Yad2
User Can sell products, quantity of each product is one. 
When user is logged in, there is 10% discont. 
Any user can create or buy a product. 

# UI explanation

## User login and register
Once User is logged in, we can see his name. The price decreased.
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/login.JPG "Login")

## Product
On the main page is product preview, products can be sorted by date and price:
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/preview.JPG "Preview")

Full description and more images are on the product details page
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/details.JPG "Details")


## Cart
Once product is bought it will be removed from database
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/carttview.JPG "Cart")


Registration page
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/reg.JPG "Registration")

# MVC model explanation
## Models 
In the store there are 2 Models: Products and Users. 

![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/models.JPG "Models")

Product class
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/products.JPG "Products")

User class
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/User.JPG "Users")


## Controllers 
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/controllers.JPG "Controllers")

In Cart controller I've added Sessons so product will be not avaliable on the main page while it is the cart
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/cart.JPG "Cart")

Set coocies in AccountController
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/Account.JPG "Account")

## Views 
![Alt text](https://github.com/olgush/Yad2Store/blob/new/yad2/assests/Views.JPG "Views")

