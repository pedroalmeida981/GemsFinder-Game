# GemsFinder — Unity 3D collectible game

**Unity 2020.1.4f1 · C# · 3D exploration**

> **Status:** Historical game-development learning project; no recent clean build or complete gameplay verification is claimed.

## Overview

GemsFinder is a first-person Unity project built around exploring a 3D environment and collecting objects. The code contains movement, camera controls, collectible tracking, UI feedback and scene transitions.

## Code-level features

- First-person walking, jumping, gravity and ground checks using a `CharacterController`.
- Mouse-look controls and player scripts.
- Collectibles handled through trigger callbacks (`CollectStar.cs`).
- A count displayed in the UI, with a completion message when the counter reaches zero.
- Menu actions for starting or quitting the game.
- Scene transition scripts and assets for an ending scene.
- Supporting models, materials, prefabs, sounds and other Unity assets.

## Technical details

| Topic | Detail |
| --- | --- |
| Engine | Unity **2020.1.4f1** |
| Language | C# |
| Main code | `Assets/Scripts/` |
| Scene assets | `Assets/MainMenu/`, `Assets/Scene1 Medieval/`, `Assets/Last Scene/` |
| Input/movement | Unity Input, physics queries and CharacterController |

## How to inspect

1. Clone and open the repository in Unity Hub.
2. Prefer Unity 2020.1.4f1 to minimise import differences.
3. Review `ProjectSettings` and the scene order in Build Settings.
4. Open the main menu and gameplay scene; verify inspector references, tags, sound sources and player controller before running.

No successful clean build or gameplay test was independently confirmed while preparing these notes.

## Known technical risks

- `CollectStar.OnTriggerEnter` disables the GameObject even when a non-player collider enters, because only the decrement is conditional on the Player tag.
- `CollectStar.objects` is a static counter; lifecycle and reset behaviour between scene loads should be tested.
- `CountObjects` looks up a UI object by name and accesses a Text component on every frame; missing references may cause errors.
- Some scene changes depend on fixed scene indices; Build Settings must match the intended flow.
- The project includes third-party-looking asset directories, so asset licence/attribution should be reviewed before reuse.

## Suggested QA scenarios

Collectibles touched by player versus other colliders, simultaneous collision events, zero/negative counters, restarting a level, missing audio/UI objects, landing and jump boundaries, scene order and keyboard-only menu navigation.

## Portfolio context

This is a learning project in Unity and C#. Its value is the gameplay source and the opportunity to discuss state management, collision edge cases, test design and maintainability—not an assertion of a polished released game.