# Jet Control Game

Welcome to the Jet Control Game repository! This game features a jet controlled by the player, allowing it to take off, land, turn, and shoot. The game includes particle effects for a more immersive experience.

## Table of Contents

- [Installation](#installation)
- [Controls](#controls)
- [Features](#features)
- [Code Overview](#code-overview)
- [Credits](#credits)
- [License](#license)

## Installation

To play the game or modify the source code, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/Gadaffi508/Yandex-Game.git
    ```
2. Open the project in Unity (version X.Y.Z or later).

3. Press the `Play` button in the Unity Editor to start the game.

## Controls

- **W**: Ascend
- **S**: Descend
- **Mouse Movement**: Turn the jet
- **Left Mouse Button**: Shoot
- **Shift**: Boost speed

## Features

- **Jet Control**: Smooth control over the jet's movements using keyboard and mouse inputs.
- **Shooting Mechanism**: Fire bullets by clicking the left mouse button.
- **Speed Boost**: Increase speed by holding down the Shift key.
- **Particle Effects**: Visual effects for shooting and jet engines.

## Code Overview

### Jet Movement

The jet's movement is controlled using the `JetController` script. Here is a brief explanation of the core functions:

```csharp
using UnityEngine;

public class JetController : MonoBehaviour
{
    public float speed = 10f;
    public float boostMultiplier = 2f;
    public float rotationSpeed = 100f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public ParticleSystem jetParticles;

    void Update()
    {
        // Handle jet movement
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, moveVertical, 0);

        // Handle jet rotation
        float moveHorizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, moveHorizontal, 0);

        // Handle speed boost
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * boostMultiplier * speed * Time.deltaTime);
        }

        // Handle shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        jetParticles.Play();
    }
}
```

![1](https://github.com/user-attachments/assets/17541606-88ca-4f0f-a324-dd21d01cb7c7)

![2](https://github.com/user-attachments/assets/28011d3a-06f9-434f-bcdf-85c1511448e5)


This README provides a clear overview of your project, including installation instructions, controls, features, and an overview of the core code. Feel free to modify and expand upon this template as needed to better fit your project.
