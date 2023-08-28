# Exploding Elves - Unity Game Project

Welcome to the **Exploding Elves** Unity game project! In this project, It was created a simple game where colorful elves spawn, move around, and interact based on their colors. [Zeject framework](https://github.com/modesttree/Zenject) for Dependency Injection and [UniRx](https://github.com/neuecc/UniRx) were used to manage the game's components efficiently. Follow the instructions below to set up and try the game mechanics.

## Table of Contents

- [Project Description](#project-description)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Game Mechanics](#game-mechanics)
  - [Spawners](#spawners)
  - [Elf Behavior](#elf-behavior)
  - [Interactions](#interactions)
  - [Player Interaction](#player-interaction)
- [Dependencies](#dependencies)
- [Contributing](#contributing)
- [License](#license)

## Project Description

**Exploding Elves** is a Unity3D game where colorful elves roam around a scene. The game includes spawners that generate elves of different colors. Elves interact based on their colors: same-colored elves generate more elves, while different-colored elves explode upon collision.

## Getting Started

### Prerequisites

- Unity3D (Version 2021.3.16f1)
- Zeject Framework (Version 9.2.0)
- UniRx Framework (Version 7.1.0)

### Installation

1. Clone this repository to your local machine.
2. Open the project using Unity3D.
3. Ensure that the Zeject and UniRx framework are integrated into the project.

## Game Mechanics

### Spawners

There are four spawners in the game, each responsible for generating one type of elf:
- Black Elf Spawner
- Red Elf Spawner
- White Elf Spawner
- Blue Elf Spawner

### Elf Behavior

Elves move randomly within the scene. They have the following attributes:
- Color: Black, Red, White, or Blue
- Movement: Random movement within the scene

### Interactions

- Elves of the same color collide: Generate one extra elf of the same type.
- Elves of different colors collide: Both elves explode.

### Player Interaction

The player can adjust the interval at which each spawner creates an elf and the maximum number of elves in scene for each color. This allows players to control the pace of the game.

To modify the interval:
1. Open the **SpawnerSettings** window in scene.
2. Adjust the spawn interval and/or maximum elves number parameters as needed.

## Dependencies

- Zeject Framework (Version 9.2.0)
- UniRx Framework (Version 7.1.0)

## License

This project is licensed under the [MIT License](LICENSE).

---

Have fun exploring **Exploding Elves**! If you have any questions or need assistance, please don't hesitate to reach out.

*Project created by Henrique Torres.*
