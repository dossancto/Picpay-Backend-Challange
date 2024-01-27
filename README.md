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


## TODO

- Assert that CPF and Email Are unique for Users and Shopkeepers

- Handle exceptions in Exception Handler

- Unit and Integration Tests 
