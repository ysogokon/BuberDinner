# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

#### Login Response

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "firstName": "Yuriy",
  "lastName": "Sogokon",
  "email": "ysogokon@msn.com",
  "token": "eyJhb..hbbQ"
}
```

## Auth

### Register

```js
POST{{host}}/auth/register

```

#### Register Request

```json
{
  "firstName": "Yuriy",
  "lastName": "Sogokon",
  "email": "ysogokon@msn.com",
  "password": "Yuriy123!"
}
```

#### Register Response

```js
200 Ok
```

#### Login Request

```json
{
  "email": "ysogokon@msn.com",
  "password": "Yuriy123!"
}
```

#### Login Response

```js
200 Ok
```
