# oop_pw1_ext_2425
This repository is the base element for the development of Practice 1 for the extraordinary OOP exam session. 
# Table of contents
1. Introduction
2. Description
3. Problems encountered
4. Conclusions
5. Each commit

# Introduction
 Members- Hugo Sanz Hernandez
 The goal of this project is to simulate a train station, with a limited number platforms. 
 This doccument includes a general description of how this works and goes into the different classes and whats their funcionality, it also includes some problems i have encountered while developing the project, and, lastly, the conclusions i have taken after finishing.
 I have also listed the commits and wrote the most important things about them.

# Description
 The simulation of the train station works in 15 minutes ticks, in this interval the system updates the arrival time of the trains and manages the status of the platforms. When the arrival time of a train reaches 0 or less it starts searching for an available platform and if there is any free platforms it starts the docking process which takes 2 ticks, and when it finishes it sets the platform state to free.
 The stations have to types of trains Passenger and Freight which are subclasses of the abstract class Train this classes only have attributes and some getters and setters but no other different methods.
 We also have the platforms that have some methods:  
 - IsFree that returns truen only if the platform status if free. 
 - RequestPlatform that if a platform is free it set the current train the train introduced in the parameter. 
 - AdvanceTick that if a platform is occupied it substract 1 from docking time, and when docking gets to zero it releases the platform with the ReleasePlatform method. 
 The class station is the most complex one we start by defining two lists one for platforms and other for trains, then in the constructor we have a special method to add platforms so we can put platform and the number correspondent to each one, after this we have two main methods advancetick and displaystatus.
 - DisplayStatus shows the status of both, platforms and trains.
 - AdvanceTick for all the platforms it calls the platforms advancetick method and for the trains it executes different procedures depending on the state they are in.
 More station methods:
 - LoadTrainsFromFile reads a CSV and adds the trans contained in it.
 - AllTrainsDocked is used to end the similation when all the trains are in docked state
 # Problems encountered
 Tains platform assignment: When only one train in a tick had arrival time 0 it was assigned to all platforms, the problem was that when a trains is enroute and gets to 0 there is a loop that dicides if it goes to waiting or to docking, for docking there was a foreach for every platform and if the train had arrival time 0 or less and the platform was free it requested it, then changing the state to dockingn meaning every platform available will go through this, the thing that was needed was a break after the train status changed so only one platform will be assigned to the train.

 CSV file: At first i didnt know where to put this file so it will be read only with it's name i tried in every place and the one that works is bin.

 # Conclusions
 The experience of doing the ordinary practical work have helped so much into doing this one and not to repeat the same errors. 
 I have reinforced my knowledge about working with object oriented langueges and how important are some principles like inheritance. The structure of the code is clean, allowing for the easy addition of new train types or features.

# Each commit.
## First commit- `Train` abstract class done.
 I have made the Train class whith the atttributes discribed in PWI. 
 This class is abstract so the different trains can inherit from this one.
## Second commit- `PassengerTrain` class done.
 This class inherits from the Tain abstract class and adds the attributes numberOfCArriages and capacity.
## Third commit- `FreightTrain` class done.
 This class inherits from the Tain abstract class and adds the attributes MaxWeight and FreightType.
## Fourth commit-`Platform` class done.
 Created the platform class with its correspondig attributes.
 Added a method to request a platform and if there are free platforms the state will turn from free to accupied.
 Theres no need to advance tick in the platforms because the state of them won't change, since the program will end when all the platforms are occupied.
## Fifth commit- `Station`class almost completely done.
 Created the DispplayStatus method and the advanceTick method.
 For the Advance tick method i had to create some methods on the platform class to make this work, like request runway or the advance tick
 Tried to create another advancetick on the train class, only for code clarity, but it used foreach loops refered to the list runways that is a private attribute of the class station
 The only thing left id creating the methos to add trains from a csv file.
## Sixth commit- Developed LoadTrainsfromfile method.
 Finished the class Station with this.
## Seventh commit- `Program ` class done.
 Finished the main program.
 For this to work i had to create a method called AllTrainsDocked in the class station since thats the way the simulation can end.
## Eighth commit- `CSV` file done.
## Nineth and Tenth commit- Solutioned some errors. 
 Solutioned some errors in the station class that caused the program to malfunction
## Eleventh commit- DDD and class diagram done.
  
 

