Object-Oriented Programming Exercises for C#

This application is for familiarizing yourself with object-oriented programming and C# through a series of excersises. You will be improving 
a text-based role-playing game. 

To get started, clone this repo or download the files. You will be able to interact with this program using the console shell in Visual Studio
or via the bash command line using mono.

----------- ! Currently Under Construction ! ----------

Challenge: Add a Constructor

In the AddMonster method of our Fight class, we are setting each property of our “monster” object individually. This isn’t a big deal now, but what if we wanted to initialize a new instance of our Monster class somewhere else? There is a quicker way to do this. 

Add a constructor to the Monster class. It should set the Name, Strength, Defense, OriginalHP, and CurrentHP according to parameters that are passed in. Refactor the AddMonster method of the Fight class to reflect this change. 

Challenge: Add a Property

It looks like we have some repeated code in our Fight class. The HeroTurn, MonsterTurn, and Win methods are all passing around the same instance of Monster that we initialized in the Start method. There must be an easier, more DRY way to do this. 

Add a property to the Fight class that references to an instance of the Monster class. Change the Start method so that it sets this property. Refactor the HeroTurn, MonsterTurn, and Win methods so they are referencing to this property instead of passing around an object. 