# oop_pw1_ext_2425
This repository is the base element for the development of Practice 1 for the extraordinary OOP exam session. 

# Each commit
## First commit- `Train` abstract class done
 I have made the Train class whith the atttributes discribed in PWI. 
 This class is abstract so the different trains can inherit from this one.
## Second commit- `PassengerTrain` class done
 This class inherits from the Tain abstract class and adds the attributes numberOfCArriages and capacity.
## Third commit- `FreightTrain` class done
 This class inherits from the Tain abstract class and adds the attributes MaxWeight and FreightType.
## Fourth commit-`Platform` class done
 Created the platform class with its correspondig attributes.
 Added a method to request a platform and if there are free platforms the state will turn from free to accupied.
 Theres no need to advance tick in the platforms because the state of them won't change, since the program will end when all the platforms are occupied.
## Fifth commit- `Station`class almost completely done
 Created the DispplayStatus method and the advanceTick method.
 For the Advance tick method i had to create some methods on the platform class to make this work, like request runway or the advance tick
 Tried to create another advancetick on the train class, only for code clarity, but it used foreach loops refered to the list runways that is a private attribute of the class station
 The only thing left id creating the methos to add trains from a csv file.
