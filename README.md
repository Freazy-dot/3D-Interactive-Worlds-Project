## Overview of the Game:
The idea of the game is a wave-based shooter where players can choose between two distinct characters: a ranged fighter or a melee warrior. The project is done by two team members, one focusing on the melee character gameplay, and a melee enemy, and the other on making a ranged mage, Aswell as a ranged enemy. The objective is simple: survive as long as possible while racking up points by defeating enemies. As the game progresses, the challenge gets higher, with enemies spawning more frequently and randomly in a compact arena.
The gameplay focuses on increasing difficulty with hack and slash elements, with enemies randomly spawning at designated locations and alternating between melee and ranged enemy types. Players use a combination of mouse and keyboard inputs to navigate and fight, in third person.
## The main parts of the game are:
-	Player – The Player can select between two characters, one specializing in melee combat and the other in ranged attacks. Each character has a basic attack and a special ability.
-	Camera – A third-person camera system follows the player and is controlled via the mouse.
-	Enemies – Two enemy types: ranged and melee. Enemies spawn randomly at pre-defined points and continuously move towards the player until they are within range of the player. Each enemy also features basic and special attacks, mirroring the player’s mechanics.
-	Combat – In an enclosed arena, each character has a basic attack and special attack. The melee character has a melee basic attack with its sword, and its special is 10 slashes in an area in front of it.
-	Score – Score increases with each enemy killed
## Game features:
-	Enemies spawn position randomized within a set of spawn points
-	More enemies spawn with time
-	The game keeps track of the score
-	2 Player Characters available
## How were the Different Parts of the Course Utilized:
It contains character and camera movement scripts, using the transform component in unity.  The game utilizes the particle system from unity, when using some attacks, and has use of materials, with the particle system using a material which uses the “Particles/Standard Unlit” shader option. Interaction with other gameObjects is done primarily through raycasting, to detect wether or not an enemy has been hit by an attack, or the player has been hit. Probuilder has been used for Building the arena Level. For Animation, Unitys own animation window was used, to create animation for the melee characters basic attack, utilizing keyframes and animation states for idle and attacking. Unitys Particle system was utilisied for the Melee Character Special Attack, using the options to create a bloodstreak like effect. Rigidbody is used for physics for enemy characters, for moving them.

## Running The Game
1. Download Unity 6
2. Clone or download the project
3. The game requires mouse and keyboard
4. The game is only tested and confirmed to run on Windows.

## Time Management / Bjarke

| Task                                              | Time it Took (in hours) |
|---------------------------------------------------|-------------------------|
| Setting up Unity, making a project in GitHub      | 0.5                     |
| Research and conceptualization of game idea       | 2                       |
| Basic Enemy Function, Move towards player, attack, etc. | 1                |
| Basic Melee Player Movement, Jumping              | 1                       |
| Basic Melee Player Attack                         | 1                       |
| Making Sword Model in Blender                         | 2                       |
| Inserting Model for Sword for Melee Player + Animations | 2                  |
| Special Attack Melee + Particle System            | 1                       |
| Arena Level Design                                | 0.5                     |
| Enemy Spawning                                    | 1.5                     |
| Start Menu & Character Select                     | 1                       |
| Camera Movement + Player Rotation                 | 0.5                     |
| Small Fixes and Polish                            | 1                     |
| **ALL**                                           |   15                  |

## Time Management / Oliver

| Task                                           | Time it Took (in hours) |
|------------------------------------------------|--------------------------|
| Setting up Unity, making a project in GitHub  | 0.5                      |
| Research and conceptualization of game idea   | 2                        |
| Enemy / Friendly attributes; health, armor, and damage | 2                 |
| Ranged Enemy                                   | 1                        |
| Ranged Friendly                                | 3                        |
| Particle Death Animation                       | 2                        |
| Ranged Friendly Special Particle Animation    | 1                        |
| Health Bars                                    | 2                        |
| Main Menu and Character Select Screen         | 0.5                      |
| Bug Fixing                                     | 1.5                      |
| **ALL**                                       | **15.5**                   |
