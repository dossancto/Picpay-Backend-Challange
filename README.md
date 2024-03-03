# Picpay Backend challange

Picpay backend challange - [Try it out](https://picpay-backend-challange.onrender.com/swagger)

![picpay](https://github.com/lu-css/Picpay-Backend-Challange/assets/97306254/52152802-0d3d-48da-82f7-539b4422e422)

## About

This Application was developed using [Guardian](https://github.com/lu-css/guardian-cli) to easily development. Check the repository to architecture details.

### Documentation

The entity application contain documentation. This provider a rich API documentation, using Swagger (`/swagger`) and Redoc (`/api-docs`)

![image](https://github.com/lu-css/Picpay-Backend-Challange/assets/97306254/39646b60-dcf6-41c0-8304-a32a84d0846d)

This documentation also helps other developers mantain the code

## Running

- Setup the environment 🛠️

    ```sh
    make env/setup
    ```

- Start `Postgres` on docker-compose 🐘

    ```sh
    make compose/up
    ```

- Run migrations 📦

    ```sh
    make db/update
    ```

- Start the application 🚀

    ```sh
    make run
    ```

- Or with docker 🐳

    ```sh
    docker build -t picpay:latest .
    ```

    ```sh
    docker run --env-file .env -p 5175:8080 picpay
    ```

## TODO

- Assert that CPF and Email Are unique for Users and Shopkeepers

- Unit and Integration Tests 
