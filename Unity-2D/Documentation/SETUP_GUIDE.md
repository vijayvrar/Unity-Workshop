# Unity 2D Platformer – Setup Guide

This guide describes the small 2D platformer built during the VIT Unity workshop preparation.

## 1. Project setup

- Unity Editor: Unity 6.3 LTS (`6000.3.29f1`)
- Project template: Universal 2D
- Example project name: `VIT_Unity_Workshop`

Create and save a scene named `01_2D_Basics`.

## 2. Scene objects

Create these GameObjects using 2D built-in sprites:

- `Player` – Circle sprite
- `Ground` – Square sprite scaled into a long platform
- `Platform_01`, `Platform_02`, `Platform_03` – Square sprites scaled into platforms
- `Obstacle` – Square sprite
- `Background` – Square sprite scaled to cover the camera view
- `Coin` – Circle sprite

Set the Background Sprite Renderer Order in Layer to `-10` so it appears behind the other objects.

Use the Inspector to set object positions, scales and colours.

## 3. Physics components

### Player

Add:
- `Rigidbody2D`
  - Body Type: Dynamic
  - Gravity Scale: 1
  - Freeze Rotation Z: enabled
- `CircleCollider2D`

### Ground, platforms and obstacle

Add a `BoxCollider2D` to each.

The obstacle must also be assigned to the `Ground` layer if the player should be able to jump while standing on it.

## 4. Ground layer and GroundCheck

1. Create a layer named `Ground` using the Layer dropdown > Add Layer.
2. Assign `Ground`, all platforms, and any solid obstacle that should count as floor to this layer.
3. Create an empty child GameObject under Player named `GroundCheck`.
4. Set its local position to approximately `(0, -0.5, 0)`.
5. In the PlayerMovement component, assign:
   - Ground Check: the `GroundCheck` child Transform
   - Ground Layer: the `Ground` layer

The GroundCheck point is used by `Physics2D.OverlapCircle` to detect whether the player is standing on an object in the Ground layer.

## 5. Input System setting

This project uses the legacy `Input.GetAxis("Horizontal")` API and `Input.GetKeyDown`.

If Unity reports an InvalidOperationException about the Input System:
1. Stop Play mode.
2. Open Edit > Project Settings > Player.
3. Find Other Settings > Configuration.
4. Set Active Input Handling to `Both`.
5. Restart the Unity Editor when prompted.

## 6. Player movement script

Copy `Assets/Scripts/PlayerMovement.cs` into the project's `Assets/Scripts` folder and attach it to Player.

In the Inspector, set:
- Move Speed: `5`
- Jump Force: `8`
- Ground Check: drag the GroundCheck child here
- Ground Layer: select `Ground`

Controls:
- A / D or Left / Right arrows: move
- Space: jump

This sample uses `Rigidbody2D.linearVelocity`, supported by Unity 6.

## 7. Coin collection

1. Create a Coin using a Circle sprite.
2. Add `CircleCollider2D` and enable `Is Trigger`.
3. Create a tag named `Player` and assign it to the Player GameObject.
4. Attach `CoinCollection.cs` to the Coin.
5. Drag the Coin from Hierarchy into `Assets/Prefabs` to create a Prefab.
6. Duplicate the Coin Prefab in the scene to place more coins.

The Player needs a Collider2D and Rigidbody2D. When the Player touches a Coin, the script logs `Coin Collected!` in the Console and destroys that Coin instance.

## 8. Animation clips

The workshop exercise uses three simple clips:

### Player_Idle
- Scale: `(0.8, 0.8, 1)` at 0 seconds
- Scale: `(0.9, 0.9, 1)` at 0.5 seconds
- Scale: `(0.8, 0.8, 1)` at 1 second
- Enable Loop Time

### Player_Walk
- Rotation Z: `-10` degrees at 0 seconds
- Rotation Z: `+10` degrees at 0.25 seconds
- Rotation Z: `-10` degrees at 0.5 seconds
- Enable Loop Time

### Player_Jump
- Scale: `(0.8, 0.8, 1)` at 0 seconds
- Scale: `(0.7, 1.0, 1)` at 0.15 seconds
- Scale: `(0.8, 0.8, 1)` at 0.3 seconds
- Loop Time disabled

Unity plays the default state in the Animator Controller when the scene starts. To change the default, open Window > Animation > Animator, right-click the desired state and choose Set as Layer Default State.

**Important:** These clips are separate animation demonstrations until Animator transitions and parameters are configured. They do not automatically switch between Idle, Walk and Jump merely because the clips exist.

## 9. Game view resolution

For a clearer preview, select `Full HD (1920x1080)` in the Game view resolution dropdown. The Game view Scale slider controls how large the preview appears inside the Editor; it does not change the game's actual build resolution.

## 10. Suggested folder layout

Keep the Unity project structure organised:

```text
Assets/
  Animations/
  Prefabs/
  Scenes/
  Scripts/
  Sprites/
  Materials/
  Settings/
Documentation/
Packages/
ProjectSettings/
```

Save the scene under `Assets/Scenes/01_2D_Basics.unity`.

## 11. GitHub notes

For a Unity project repository:
- Commit `Assets/`, `Packages/`, and `ProjectSettings/`.
- Include the `.gitignore` file from this starter pack.
- Do not commit the generated `Library/`, `Temp/`, `Obj/`, `Logs/`, or build output folders.
- Include a screenshot or short GIF in the repository README after capturing it from your own project.
- Check the licence of any third-party assets before redistributing them.

## 12. Current scope and known limitations

This is a beginner workshop project, not a production game.

- The movement script uses `transform.Translate` for horizontal movement and Rigidbody2D velocity for jumping. For a more advanced physics-based controller, horizontal velocity can later be moved into FixedUpdate.
- Ground detection uses a small overlap circle. Adjust the GroundCheck position and radius if detection is inconsistent.
- The coin collection message appears in the Unity Console; there is no on-screen score UI yet.
- Animation clips are not automatically state-driven yet.
- The project has not yet been configured or tested for Web publishing. Web Build Support, Web platform build settings, and hosting configuration are a separate next step.
