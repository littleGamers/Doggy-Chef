# Doggy Chef

If you love dogs, food or video games - this game is for you!

It's so hard when you're a student who just wants to eat dinner.

Things get tougher when you find out that your dog ruined your kitchen and your recipe book.

Cam you restore all the recipes for your favorite meals?

You need to catch the right ingredients for each recipe.


<br/>

## Instructions

Move with the LEFT and RIGHT arrow keys.

Try to figure out which ingredients fit the recipe and which don't.

Avoid all the bad ingredients and catch all the good ones.

Don't worry if you lose - just press the LCTRL key and try again.

<br/>

## Components

**[Instruction](Assets/Scripts/Instruction.cs) -** A simple interface to be implemented by instruction objects.
<br />

**[MoveInstruction](Assets/Scripts/MoveInstruction.cs) -** Teaches the player how to move and wait for him to learn.
<br />

**[IngedientInstruction](Assets/Scripts/IngedientInstruction.cs) -** Teaches the player how to catch ingredients and wait for him to learn.
<br />

**[CookInstruction](Assets/Scripts/CookInstruction.cs) -** Teaches the player how to cook and wait for him to learn.
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

## External Links

Play the game on Itch.io:

https://littlegamers2021.itch.io/doggychef

pdf components file link:
<br />

**[Doggy_Chef_Components](Doggy_Chef_Components.pdf) -** pdf components of exercise 6.

## **Have Fun!**

