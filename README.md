# Doggy Chef

It's so hard when you're a student who just wants to eat dinner.

Things get tougher when you find out that your dog ruined your kitchen and your recipe book.

Cam you restore all the recipes for your favorite meals?

You need to catch the right ingredients for each recipe.

<br/>

## Instructions:

Move with the LEFT and RIGHT arrow keys.

Avoid all the bad ingredients (Red) and catch all the good ones (Green).

Don't worry if you lose - just press the SPACE key and try again.

<br/>

## Components

**[DestroyOnTrigger](Assets/Scripts/DestroyOnTrigger.cs) -** Used by all ingredients to destroy themselves when grabbed by player.
<br />

**[EnemyHit](Assets/Scripts/EnemyHit.cs) -** Used when player catches a bad ingredient tp decrement life by 1.
<br />

**[GameOverOnTrigger](Assets/Scripts/GameOverOnTrigger.cs) -** Ends the game when lives reach 0.
<br />

**[HitPoints](Assets/Scripts/HitPoints.cs) -** Handles the score and lives of the player.
<br />

**[MoveSpawner](Assets/Scripts/MoveSpawner.cs) -** Moves the ingredients down the screen automatically.
<br />

**[Mover](Assets/Scripts/Mover.cs) -** Controls the player's movement on the X axis.
<br />

**[RandomTimedSpawner](Assets/Scripts/RandomTimedSpawner.cs) -** Spawns new ingredients from the sky in a random X position and sets random attributes to each spawned ingredient.
<br />

## External Links

Play the game on Itch.io:

https://littlegamers2021.itch.io/doggychef

pdf components file link:
<br />

**[Doggy_Chef_Components](Doggy_Chef_Components.pdf) -** pdf components of matala #6. 

## **Have Fun!**

