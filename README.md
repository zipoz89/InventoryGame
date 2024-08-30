# InventoryGame
Demo project made in 6h

![](Screen.png)

Most of the systems could be easily extended and used in other systems.


Controlls
    WSAD - Movement
    Mouse - Look
    Space - Jump
    LMB - Interact
    Tab - Inventory

Shortcuts i took that might be bad design but I used them for time saving
-Generic pool manager instead of sepparate pool menagers per object that might extend the use
-No Game controller or ui aggregate  controller - the player is "main" class but it also might be used for easier multiplayer implementation
-Dependency injection by SerializedFields
-VFX are very simple (no time for experimentation)
-UI is awful


Atributions:
Ore model: https://sketchfab.com/3d-models/ore-crystals-238d3ca0fa614d3ab68a6f1438832d65
Stone: https://sketchfab.com/3d-models/stone-2e966dce9db34fecad1290452bdab165
Quake controller: https://github.com/WiggleWizard/quake3-movement-unity3d/tree/master
icons: https://game-icons.net