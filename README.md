# InventoryGame<br />
Demo project made in 6h<br />

![](Screen.png)<br />

Most of the systems could be easily extended and used in other systems.<br />


Controlls<br />
    WSAD - Movement<br />
    Mouse - Look<br />
    Space - Jump<br />
    LMB - Interact<br />
    Tab - Inventory<br />
<br />
Shortcuts i took that might be bad design but I used them for time saving<br />
-Generic pool manager instead of sepparate pool menagers per object that might extend the use<br />
-No Game controller or ui aggregate  controller - the player is "main" class but it also might be used for easier multiplayer implementation<br />
-Dependency injection by SerializedFields<br />
-VFX are very simple (no time for experimentation)<br />
-UI is awful<br />


Atributions:<br />
Ore model: https://sketchfab.com/3d-models/ore-crystals-238d3ca0fa614d3ab68a6f1438832d65<br />
Stone: https://sketchfab.com/3d-models/stone-2e966dce9db34fecad1290452bdab165<br />
Quake controller: https://github.com/WiggleWizard/quake3-movement-unity3d/tree/master<br />
icons: https://game-icons.net<br />