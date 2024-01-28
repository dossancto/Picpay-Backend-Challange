# Picpay Backend challange

Picpay backend challange


## Running

- Setup the environment

    ```sh
    make env/setup
    ```

- Start `Postgres` on docker-compose

    ```sh
    make compose/up
    ```

- Run migrations

    ```sh
    make db/update
    ```

- Start the application

    ```sh
    make run
    ```

- Or with docker

    ```sh
    docker build -t picpay:latest .
    ```

    ```sh
    docker run --env-file .env picpay:latest
    ```

## TODO

- Assert that CPF and Email Are unique for Users and Shopkeepers

- Unit and Integration Tests 
