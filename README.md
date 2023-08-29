# Exploding Elves - Unity Game Project

Welcome to the **Exploding Elves** Unity game project! In this project, It was created a simple game where colorful elves spawn, move around, and interact based on their colors. [Zenject framework](https://github.com/modesttree/Zenject) for Dependency Injection and [UniRx](https://github.com/neuecc/UniRx) were used to manage the game's components efficiently. Follow the instructions below to set up and experience the project.

## Table of Contents

- [Project Description](#project-description)
- [Architecture](#architecture)
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

## Architecture

The project's architecture was designed using the **[MVC](https://www.toptal.com/unity-unity3d/unity-with-mvc-how-to-level-up-your-game-development)** design pattern and two 3rd-Party Libraries, **[Zenject](https://github.com/modesttree/Zenject)** for efficient management of the game's components, and **[UniRx](https://github.com/neuecc/UniRx)** for simpler management of asynchronous data (e.g. coroutines) and events (e.g. monobehaviour events) using the **Observables** design pattern.

The Zenject library makes it possible to transform the code into a system with **loosely coupled** parts and with **highly segmented** responsibilities by using [Installers](https://github.com/modesttree/Zenject#installers) and [Signals](https://github.com/modesttree/Zenject/blob/master/Documentation/Signals.md).

In addition, Zenject also facilitated the implementation of other design patterns that were used for the development of this game:
 - **[Factory](https://github.com/modesttree/Zenject/blob/master/Documentation/Factories.md)** for instantiating new Prefabs (e.g. Spawners, Elves, Explosions, SpawnEffects).
 - **[Memory Pooling](https://github.com/modesttree/Zenject/blob/master/Documentation/MemoryPools.md)** for memory management. 
 - **[Facade](https://github.com/modesttree/Zenject/blob/master/Documentation/SubContainers.md)** for abstracting instantiated entities (e.g. Elves, Spawners).
 - **[Singleton](https://github.com/modesttree/Zenject#installers:~:text=AsSingle%20%2D%20Exactly%20the,a%20second%20instance.)** to ensure that every dependency that uses certain components is injected with the same instance. [(know more)](https://github.com/modesttree/Zenject#isnt-this-overkill--i-mean-is-using-statically-accessible-singletons-really-that-bad:~:text=Isn%27t%20this%20overkill%3F%20I%20mean%2C%20is%20using%20statically%20accessible%20singletons%20really%20that%20bad%3F).
 
When using the MVC standard, only the View inherits from a MonoBehaviour, which means that the other layers avoid the extra weight of inheriting all the methods and properties of a MonoBehaviour. However, not having a MonoBehaviour means not having also the **"Start"**, **"Update"**, **"Instantiate"** and **"Coroutine"** methods, among others, available. Zenject helps with this by implementing [Interfaces](https://github.com/modesttree/Zenject#using-non-monobehaviour-classes:~:text=Using%20Non%2DMonoBehaviour%20Classes) for MonoBehaviour's methods; Factories for Instantiating; and, for Coroutines, using the UniRx library allows even more efficient management with [MicroCoroutines](https://github.com/modesttree/Zenject#using-non-monobehaviour-classes:~:text=Using%20Non%2DMonoBehaviour%20Classes).

 To keep the code loosely coupled, the controllers talk to each other via [Signals](https://github.com/modesttree/Zenject/blob/master/Documentation/Signals.md). An example would be updating the UI. The UI then subscribes to the signal and, when an element that should be shown in the UI is changed, whoever changes it triggers the signal and the UI changes it asynchronously.

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
