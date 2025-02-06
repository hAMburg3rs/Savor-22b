# SAVOR22B

# Project Termination
The scope of the game grew too large, and developing it with blockchain as the backend turned out to be slow and complex.  
Blockchain also imposed design constraints, making the gameplay feel too static. Without confidence that the game would be engaging or attract players, continuing didn’t seem viable.  
Instead, I want to focus on building a simpler game first and gaining experience in growing a player base.

## Introduction
SAVOR22B is a game (prototype) where you explore the world, create food using randomly grown ingredients from your own farm, and make the best superfoods.

## Project
The repository is a monorepo that contains both a backend project, which stores game information on the blockchain and provides data through GQL, and a client project that receives the data and runs the game.  
Each project has its own README.md and CONTRIBUTING.md files, so please refer to them for detailed information.

## Transparent Game
SAVOR22B is a decentralized game. Using [libplanet](https://github.com/planetarium/libplanet), all game data is stored on the blockchain, allowing anyone to participate in game development and fork it.  
All in-game information is publicly available as a blockchain and cannot be manipulated, ensuring transparency.
