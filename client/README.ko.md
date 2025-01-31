# Savor22B Client (Prototype)

# 스펙
- godot(GDScript)
- graphql

# 실행 방법

- 서버가 실행되고 있어야 합니다.
  - 로컬에서 서버를 실행할 땐, `78f01e93bf90cfebfb23a27f2a37e24436651bc5` git 해시 이전 버전을 사용해야 합니다.
  - 서버용 프로젝트를 따로 clone 한 뒤, checkout 해야합니다. (프론트는 최신 버전이어야 함)
    ```
      git checkout 78f01e93bf90cfebfb23a27f2a37e24436651bc5
    ```

- 사전에 godot mono의 설치가 필요합니다.
  - 현재 프로젝트는 4.22 버전을 사용하고 있습니다. 

## Submodule 설치
 ```bash
  git submodule update --init
  ```

## Godot에서 프로젝트 실행
- 프로젝트를 실행하고 확인합니다.
- 가장 첫 인트로 화면에 지정받은 address가 표시됩니다. 
  ![image](https://github.com/user-attachments/assets/48c08085-418a-4d60-8336-04cb56e1ceb9)

  - 해당 address가 게임 내에서 사용할 주소가 됩니다.

## 옵션, 테스트용 BBG 받기
- 현재는 테스트를 위한 초기 BBG를 받을 수 있는 `showMeTheMoney` graphql query가 열려있습니다.
```graphql
query {
	showMeTheMoney(address: "your address")
}
```
- 위 쿼리를 입력해 초기 자금과 기타 자원(식재료, 음식 등)을 받을 수 있습니다.

# 프로젝트 기능
- 마을
    - 마을을 확인하고, 원하는 위치에 집을 설치할 수 있습니다.
      ![스크린샷 2025-01-31 오후 6 50 31](https://github.com/user-attachments/assets/c3a77bc6-888c-426f-a03b-3b60754b6d54)
      ![스크린샷 2025-01-31 오후 6 50 56](https://github.com/user-attachments/assets/06276dcb-ccee-4f37-a618-abbe8437a58f)
- 집
  - 밭을 가꿀 수 있습니다.
    ![image](https://github.com/user-attachments/assets/06cc1647-7223-4d6a-92bf-0936e8d6ecd8)
    - 총 8칸의 밭에 랜덤 종자를 설치하고, 재배해서 랜덤한 식재료를 얻을 수 있습니다.
    - 종자 재배 중 잡초를 제거해 더 효율적인 농사를 할 수 있습니다.
- 음식 및 슈퍼푸드
  - 인벤토리를 확인하고, 보유 재화를 확인할 수 있습니다.
  - 상점에서 필요한 물품을 구매할 수 있습니다.
      ![image](https://github.com/user-attachments/assets/a23ef923-fb24-4b5f-805c-9b82932fe1ec)
      ![스크린샷 2025-02-01 오전 3 04 18](https://github.com/user-attachments/assets/9fc7b781-7dd6-4d85-8921-c8d0bde41a1d)
  - 레시피북을 확인하고, 음식을 조리(슈퍼푸드 제작)할 수 있습니다.
      ![image](https://github.com/user-attachments/assets/b93f6018-bf86-4ef7-bd0b-b9fa2c738fd5)
      ![image](https://github.com/user-attachments/assets/b21311de-0987-43a3-804e-728e311aefa1)
- 무역
  - 무역 상점을 통해 물건을 구매하고, 팔 수 있습니다.

## 전투 기능 Prototype
- https://github.com/not-blond-beard/savor-22b-mock-battle

## Addons(Submodule)
- GraphQL client: https://github.com/Dracks/GodotGraphQL
