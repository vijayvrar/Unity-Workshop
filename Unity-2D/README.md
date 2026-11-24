# Unity 2D Platformer – VIT Workshop

A beginner-friendly Unity 2D platformer exercise prepared for the VIT faculty workshop.

## What you will build

- A simple 2D scene with a player, ground, platforms and obstacle
- Player left/right movement
- Jumping with ground detection
- Three simple animation clips (Idle, Walk and Jump)
- Reusable Coin Prefab
- Trigger-based coin collection

## Software

- Unity 6.3 LTS (`6000.3.29f1`)
- Universal 2D project template
- Visual Studio or another C# editor

## Quick start

1. Create a new project using the **Universal 2D** template.
2. Copy the `Assets/Scripts` folder from this repository into your Unity project's `Assets` folder.
3. Follow [Documentation/SETUP_GUIDE.md](Documentation/SETUP_GUIDE.md) to create the scene and configure components.
4. Open the `01_2D_Basics` scene and press Play.

## Controls

| Key | Action |
|---|---|
| A / D | Move left / right |
| Left / Right arrows | Move left / right |
| Space | Jump |

## Repository structure

```text
Assets/
  Scripts/
    PlayerMovement.cs
    CoinCollection.cs
Documentation/
  SETUP_GUIDE.md
.gitignore
README.md
```

The starter pack contains the scripts and written setup guide. It does **not** contain a complete Unity scene, animation assets, sprites, or a ready-to-run Unity project. Those are created in the Unity Editor by following the guide.

## Important setup notes

- Assign the Player GameObject the `Player` tag.
- Create a `Ground` layer and assign the ground, platforms and jumpable obstacle to it.
- Assign the `GroundCheck` child Transform and `Ground` layer to the PlayerMovement component.
- If using the legacy `Input.GetAxis` API, set **Active Input Handling** to **Both** under Project Settings > Player > Other Settings > Configuration, then restart Unity if prompted.
- The Coin needs a Collider2D with **Is Trigger** enabled.
- The Player needs a Rigidbody2D and Collider2D.

## Learning outcomes

By completing this exercise, learners practise:
- GameObjects and Components
- Transform and Sprite Renderer
- Rigidbody2D and Collider2D
- Layers and LayerMasks
- C# MonoBehaviour scripts
- Prefabs
- Trigger events
- Animator states and default animation

## Next step

Web publishing is a separate follow-up exercise. Add Web Build Support in Unity Hub, build for the Web platform, then deploy the output to a static hosting service after testing it.

## Licence

Add a licence file before making the repository public if you want to specify reuse permissions. Only include assets that you created or are permitted to redistribute.
