Roll-A-Ball Adventure — Unity Game Project
A fully-customized third-person adventure game built in Unity for IT201: Game Development.
This project began as the classic Roll-A-Ball tutorial and evolved across multiple assignment stages into a fully featured 3D game with movement upgrades, enemies, a new animated player model, a pet companion, a multi-level structure, HUD systems, and a teleportation endpoint into a second terrain-based world.


GAME OVERVIEW
You play as a robot exploring floating platforms in space. Your goal is to collect 12 pickups scattered throughout the level while avoiding enemy robots and bottomless pits. After collecting all pickups, a teleporter appears, allowing you to travel to a new terrain world with trees, grass, enemies, and a day/night cycle.


This project uses:
Unity Game Engine
C# (custom scripts)
Unity's Input System
Unity Terrain Tools
Unity Animator System
Git + GitHub for version control


FEATURES
PLAYER MOVEMENT & ABILITIES
CharacterController-based third-person movement
Directional camera-relative movement
Smooth model rotation
Jump (Spacebar)
Dash/Sprint (Left Shift) with cooldown
Improved collision behavior with obstacles


UPGRADED MODELS & STYLE
Player replaced with a modular robot model
Enemies replaced with alien robots
Pickups replaced with store assets
Pet companion upgraded
New asteroid obstacles and sci-fi level theming
Fully updated PBR materials
Space-themed skybox


AUDIO
Background music
Pickup sound effect


GAME LOGIC
Doors unlock at 2, 5, 8, and 10 pickups
Kill Floor that respawns player to nearest checkpoint
3 lives system with lives UI
Timer (2 minutes) that ends game on timeout
HUD displaying pickup count, lives, dash cooldown, timer


ENEMIES
Enemy robots deal damage on contact
Enemy removed when player wins


LEVELS
SCENE 1 — Space Platforms
Floating platforms
Moving obstacles
Pickups and doors
Enemies
Teleporter appears after 12 pickups

SCENE 2 — TerrainScene
Sculpted terrain
Painted textures (grass, rock, dirt)
Trees and grass placed
One enemy added
Fully implemented day/night cycle
Camera follows and rotates with player


PAUSE MENU
Press P or ESC to pause
Resume, Restart, and Quit buttons
Displays live dash cooldown


PROJECT STRUCTURE
Assets/
Scripts/
Prefabs/
Materials/
Models/
Scenes/
UI/

ASSIGNMENT 3 COMPLETION SUMMARY
Requirements Completed:
Teleporter appears after 12 pickups.
Teleporter sends player and pet to new scene.
TerrainScene created using terrain tools with textures, grass, trees, store models.
Enemy added to the new scene.
Extra Credit: Day/night cycle implemented.


HOW TO PLAY
Move: WASD
Jump: Space
Dash: Left Shift
Pause: P or ESC
Avoid enemies and falling
Collect all 12 pickups
Enter teleporter to reach TerrainScene


TECH USED
Unity
C#
New Input System
TextMeshPro
Unity Animator
Git/GitHub


NOTES
This game evolved across three assignments, expanding from simple roll-a-ball movement into a third-person adventure with animated characters, a HUD, world transitions, and a terrain environment.

PLAY THE GAME
https://play.unity.com/en/games/cee657d2-10a2-466b-929a-0a14786eb45d/rollballsubmission 
