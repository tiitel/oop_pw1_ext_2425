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