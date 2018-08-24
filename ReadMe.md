
# ASP.NET MVC5 Project - Second Hand Store Yad2
User Can sell products, quantity of each product is one. 
When user is logged in, there is 10% discont. 
Any user can create or buy a product. 

# UI explanation

## User login and register
Once User is logged in, we can see his name. The price decreased.
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/login.JPG "Login")

## Product
On the main page is product preview, products can be sorted by date and price:
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/preview.JPG "Preview")

Full description and more images are on the product details page
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/details.JPG "Details")


## Cart
Once product is bought it will be removed from database
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/carttview.JPG "Cart")


Registration page
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/reg.JPG "Registration")

# MVC model explanation
## Models 
In the store there are 2 Models: Products and Users. 

![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/models.JPG "Models")

Product class
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/products.JPG "Products")

User class
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/User.JPG "Users")


## Controllers 
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/controllers.JPG "Controllers")

In Cart controller I've added Sessons so product will be not avaliable on the main page while it is the cart
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/cart.JPG "Cart")

Set coocies in AccountController
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/Account.JPG "Account")

## Views 
![Alt text](https://github.com/olgush/Yad2Store/yad2/assets/Views.JPG "Views")

