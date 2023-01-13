# Welcome to Banken!

This is a application that simulates an ATM.


## Introduction to the code

 - **Program.cs** loops the login menu until a user is logged in then initialize the main menu
 - **Menu.cs** contains the methods for each menu.
 - **User.cs** contains user data & the methods (login, print, transfer, withdraw &  some methods for repetitive code).
 
The program is built whit methods calling upon other methods. 

The program will throw you into the main menu when logged in. From there the user will make a choice to look at balance, transfer, withdraw or logout. This action will logout the user or call upon a new menu for that specific choice. This new menu are going to call upon a method from User.cs, then return to the previous menu were the user can decide if they want to make the same action again or go back to the main menu.


## Reflections
I've chosen to keep most of the code away from **Program.cs** to keep the code clean and organized.
The program is also built so that the temporary variables in methods wont allocate memory when they're not needed. I have built it so that the deepest level of methods calling other methods two layers, menu calling on calculation methods. They will run once and then wont take up memory when you go back to menu.

> I want to try and build this in an OOP way to optimize the code further. Were the menu system is created as objects at the start of the program and the methods could be inherited.

**User.cs** contain all the user data and calculating methods because of scope and security reasons. I didn't want any other class to be able to access the user data. The calculating methods need to access it, that's why they are in the same class. Since there is no other project connected or needed I've chosen to set all classes as internal so they can't be accessed from outside projects if there will be an integration in the future.
I've chosen to store the user data in private jagged arrays and only make the logged in users username available for other function so I can welcome them by name. This is the best security solution I could come up with without using objects and get/set.
> Here I would like to experiment more with objects and text files (database) for storing data more securely and to be able to save data between program exits.

## Conclusions
I'm satisfied with my code but I still want to implement more features and explore deeper into OOP.
Whit this project I learned to "kill my darlings". I spent the first three weeks trying to perfect how to read in user data from a text file and didn't pay attention to actually build the program. I had to scrap everything and start over.

> **Note-to-self**: Build the foundation first

Other then that I found this an interesting project that I will continue to tweak and add to while I continue my journey to become a programmer.