# Pip: The Second Coming
A sequel to Pip: The Game, original cancer here:
https://github.com/chiekaze/Pip

*Special thanks to Winded for the Code Guidelines*

## Code guidelines

- public variables: camelCase
- private/protected variables: camelCase with underscore (_) in front
- classes: PascalCase
- methods: PascalCase
- script names: PascalCase

*Code should be in english except when it is inconvenient.*

## Scenes in version control

Scenes often cause merge conflicts when the same scene is edited by multiple people.
Everyone should make their own test scene to test their own features. This way the amount of perkele will be reduced.
Only one scene should be the official scene that will be in the final game. Only one person should be editing this scene at a time.

*To make it easier to move features to the main scene, use prefabs.*


## Asset organization

Assets should be in english as well except when inconvenient.


Folder structure for future reference:
- Scripts -> All code made by us here
- Sounds -> All sounds here
- Shaders -> Shader code here
- Scenes -> All scenes including test scenes
- Prefabs -> All prefabs
- Models -> All models
- Models/Materials -> Materials related to models
- Materials -> Other materials
- Textures -> Textures
- ThirdParty -> Third party content (SteamVR, third party models/textures, etc)