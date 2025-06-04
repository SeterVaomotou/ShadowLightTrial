# Shadowlight Trials 
*A 2D Puzzle-Platformer of Emotion, Light, and Redemption.*

---

## Overview

**Shadowlight Trials** is a 2D side-scrolling puzzle-platformer created in Unity.  
You play as a lost soul navigating through five emotional trials:  
**Regret, Hope, Anger, Forgiveness, and Acceptance**.  
Your goal? Conquer the obstacles, and ascend toward the light.

---

## Gameplay Features

- **Cinematic Intro & Ending** — Simple story-driven fade-in/out sequences
- **Smooth 2D Player Movement** — Walking, jumping, animated transitions
- **Five Unique Trial Levels** — Each themed around an emotional journey
- **In-Game Timer** — Tracks player progress and speedrun potential
- **Pause Menu** — Resume/Quit options with a clean UI
- **Checkpoint System** — Glowing flag-pole save progress during trials
- **Lives System** — Player has 3 lives per section, resets on failure
- **Hazards & Obstacles** — Spikes, vanishing platforms, enemies
- **Sound Effects** — Jump, checkpoint activation, and music
- **Game Complete Screen** — Celebrates your success and lets you replay or quit

---

## Design Patterns Used

### Singleton Pattern  
Used in the `GameManager.cs` to manage player lives, timer, respawn logic, and game state across scenes.

### Factory Pattern  
Implemented in an `ObstacleFactory` to dynamically spawn level hazards like spikes and platforms.

### Prefabs
Used prefabs to easily build other levels/scenes using what I've already made. Saved me time by allowing me to reuse certain game objects.

---

## Unit Testing

- Tested checkpoint updates
- Validated player respawn behavior
- Verified jump input and ground checks
- Timer increments with time
- Game over triggers at 0 lives

> All test cases written using Unity’s built-in NUnit framework

---

## Tech Stack

- **Engine:** Unity 6.1
- **Language:** C#  
- **Tools:** VSCode, Unity Test Framework, Git  
- **Version Control:** Git + GitHub

---

## How to Play

1. Clone the repo  
2. Open the project in Unity
3. Press Play in the Unity Editor or build it as an executable

---

## Future Improvements

- Add double jump and dashing mechanics  
- Dialogue system and visual storytelling moments  
- Speedrun timer leaderboard  
- Post-processing effects and glow shaders  
- Save/load system

---

## Credits & Inspiration

- Player & environment sprites: **[SunnyLand Asset Pack, Pixel Adventure 1, Pixel Skies, Simple 2D platformer BE2 (Free)]**
- Inspiration: *Ori and the Blind Forest*, *Celeste*, *Hollow Knight*
- Music: **SunnyLand Asset Pack**

---

## License

This project is for educational purposes. Free to clone, study, or expand upon.  
