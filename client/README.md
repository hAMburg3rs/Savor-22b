# Savor22B Client (Prototype)

# Specifications
- godot(GDScript)
- graphql

# How to Run

- The server must be running.
  - When running the server locally, use the version prior to the git hash `78f01e93bf90cfebfb23a27f2a37e24436651bc5`.
  - You need to clone the server project separately and check out the required version (the front-end should be the latest version).
    ```
      git checkout 78f01e93bf90cfebfb23a27f2a37e24436651bc5
    ```

- Godot Mono needs to be installed in advance.
  - The current project uses version 4.22.

## Install Submodule
 ```bash
  git submodule update --init
  ```

## Run the Project in Godot
- Run the project and check it.
- The first intro screen will display the assigned address. 
  ![image](https://github.com/user-attachments/assets/48c08085-418a-4d60-8336-04cb56e1ceb9)

  - This address will be used in the game.

## Options, Test BBG
- Currently, there is a `showMeTheMoney` graphql query available to receive initial BBG for testing purposes.
```graphql
query {
	showMeTheMoney(address: "your address")
}
```
- Enter the above query to receive initial funds and other resources (ingredients, food, etc.).

# Project Features
- Village
    - You can view the village and place houses at your desired locations.
      ![ScreenShot 2025-01-31 6 50 31 PM](https://github.com/user-attachments/assets/c3a77bc6-888c-426f-a03b-3b60754b6d54)
      ![ScreenShot 2025-01-31 6 50 56 PM](https://github.com/user-attachments/assets/06276dcb-ccee-4f37-a618-abbe8437a58f)
- House
  - You can cultivate fields.
    ![image](https://github.com/user-attachments/assets/06cc1647-7223-4d6a-92bf-0936e8d6ecd8)
    - You can plant random seeds in the eight available plots and harvest random ingredients.
    - Weeding during seed cultivation helps to make farming more efficient.
- Food and Superfoods
  - You can check your inventory and available currency.
  - You can buy necessary items from the shop.
      ![image](https://github.com/user-attachments/assets/a23ef923-fb24-4b5f-805c-9b82932fe1ec)
      ![ScreenShot 2025-02-01 3 04 18 AM](https://github.com/user-attachments/assets/9fc7b781-7dd6-4d85-8921-c8d0bde41a1d)
  - You can check the recipe book and cook food (create superfoods).
      ![image](https://github.com/user-attachments/assets/b93f6018-bf86-4ef7-bd0b-b9fa2c738fd5)
      ![image](https://github.com/user-attachments/assets/b21311de-0987-43a3-804e-728e311aefa1)
- Trade
  - You can buy and sell items through the trade shop.

## Combat Feature Prototype
- https://github.com/not-blond-beard/savor-22b-mock-battle

## Addons(Submodule)
- GraphQL client: https://github.com/Dracks/GodotGraphQL
