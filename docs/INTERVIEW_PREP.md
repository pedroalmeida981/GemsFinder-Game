# Interview preparation and QA review

> These are source-review notes and **suggested** test scenarios. They do not represent executed test cases, successful builds or approved production requirements.

## Project in one sentence

Unity collectible and exploration mechanics.

## Technical interview questions and grounded answers

### 1. How are collectibles tracked?

CollectStar increments a static counter in Awake and decrements it when a tagged Player collider enters the trigger; CountObjects shows that count and reacts to zero.

### 2. Can you identify a real code issue?

The GameObject is disabled even if a collider is not tagged Player, because the SetActive(false) call is outside the tag condition. This can remove a collectible without decrementing its counter.

### 3. Why is the static count risky?

Static fields survive object lifecycles and may require explicit reset on restart/scene reload; multiple objects can also make lifecycle assumptions hard to debug.

### 4. How does scene navigation work?

MainMenu loads the next build index; FinalScene loads a fixed scene index. This creates a dependency on Build Settings.

### 5. How would you improve the implementation?

Guard all collection actions with the correct tag, centralise progress in a session manager, avoid per-frame Find/GetComponent and add scene-independent tests around counts.

## Suggested functional and accessibility test cases

| ID | Scenario | Expected / verification objective |
| --- | --- | --- |
| COLL-01 | Player enters collectible trigger | Exactly one collectible is counted and disabled |
| COLL-02 | Non-player collider enters trigger | Collectible remains and count does not change |
| COLL-03 | Two colliders trigger same collectible | No double-decrement or negative count |
| STATE-01 | Restart after partial collection | Count resets to match active items |
| SCENE-01 | Collect final item and reach exit | Progress and scene transitions are consistent |
| A11Y-01 | Review HUD visibility and keyboard/menu access | Relevant accessibility issues are documented |

## Limitations to disclose

Unity 2020.1.4f1 project. Source-only review; do not say collision bugs were reproduced in runtime without running the scene.

## How to discuss the project

Explain what the code currently contains, which components you actually developed, the difference between intent and implementation, one defect or risk you identified, and how you would validate a fix. Avoid claiming tests have passed unless you can provide reproducible evidence.

## Suggested next improvements

- Verify a clean checkout/build with a documented environment.
- Record reproducible bugs or missing features as GitHub Issues.
- Add evidence-backed screenshots and a short demo only after confirming they match the actual project.
- Add focused automated tests where the architecture makes them worthwhile; keep manual exploratory and accessibility testing visible.
