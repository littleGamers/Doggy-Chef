# Doggy Chef

If you love dogs, food or video games - this game is for you!

It's so hard when you're a student who just wants to eat dinner.

Things get tougher when you find out that your dog ruined your kitchen and your recipe book.

Cam you restore all the recipes for your favorite meals?

You need to catch the right ingredients for each recipe.


<br/>

## Instructions

Move with the RIGHT and LEFT arrows.

Catch only ingredients that sounds like they would fit the recipe.

If you caught the right ingredients - you win!

If one of the ingredients was incorrect - you lose 1 life.

Pay attention to the stat bar on the top left corner,

it indicates the amount of ingredients needed for the recipe and the lives left for the current level.

There are also boosters that you can catch,

the bone will make you faster and the water bottle will make you slower.

<br/>

## Components

**[Instruction](Assets/Scripts/Instruction.cs) -** A simple interface to be implemented by instruction objects.
<br />

**[MoveInstruction](Assets/Scripts/MoveInstruction.cs) -** Teaches the player how to move and wait for him to learn.
<br />

**[IngedientInstruction](Assets/Scripts/IngedientInstruction.cs) -** Teaches the player how to catch ingredients and wait for him to learn.
<br />

**[BookPageFlip](Assets/Scripts/BookPageFlip.cs) -** Flips pages on the recipe book between levels.
<br />

**[EndGameOnCall](Assets/Scripts/EndGameOnCall.cs) -** Handles different game ending scenarios.
<br />

**[IngredientCatcher](Assets/Scripts/IngredientCatcher.cs) -** Used by player to handle ingredients catching.
<br />

**[IngredientsManager](Assets/Scripts/IngredientsManager.cs) -** Used by GameManager object to handle all ingredients rules. Holds the recipe and modify it when needed.
<br />

**[LivesManager](Assets/Scripts/LivesManager.cs) -** Used by GameManager object to handle the player's lives.
<br />

**[RecipeManager](Assets/Scripts/RecipeManager.cs) -** Used in RecipeBook screen handle the levels and recipes.
<br />

**[MouseSceneLoader](Assets/Scripts/MouseSceneLoader.cs) -** A simple script that creates buttons from objects to load scenes.
<br />

**[PlaceDishOnPlate](Assets/Scripts/PlaceDishOnPlate.cs) -** A script for the WinScene screen that places the dish from previous level on the plate.
<br />

**[PlayChosenLevel](Assets/Scripts/PlayChosenLevel.cs) -** Used in RecipeBook screen to set the scene to load with the "Play" button.
<br />

**[LevelNumber](Assets/LevelNumber.cs) -** Sets and returns the level number with text.
<br />

**[DestroyOnTrigger](Assets/DestroyOnTrigger.cs) -** On trigger destroys the object itself.
<br />

**[InstructionManager](Assets/InstructionManager.cs) -** Used to control the instructions on the screen and mark them after completion.
<br />

**[Mover](Assets/Mover.cs) -** Moves its object with a given speed and set it's boundries.
<br />

**[MoveSpawner](Assets/MoveSpawner.cs) -** Moves its object in a fixed velocity. velocity is a vector defined as speed+direction.
<br />

**[RandomTimedSpawner](Assets/RandomTimedSpawner.cs) -** Instantiates a given prefab at random time intervals and random bias from its object position.
<br />

<br />

## External Links

Play the game on Itch.io:

https://littlegamers2021.itch.io/doggychef

pdf components file link:
<br />

**[Doggy_Chef_Components](Doggy_Chef_Components.pdf) -** pdf components of exercise 6.

## **Have Fun!**

