compose/up:
	docker compose up -d

compose/down:
	docker compose down

db/update:
	dotnet ef database update -s Picpay.UI -p Picpay.Infra

db/setup/test:
	dotnet ef database update  -s Picpay.UI -p Picpay.Infra --connection "Server=localhost;Port=5432;Database=mydatabase_test;User Id=postgres;Password=postgres;"

env/setup:
	cp .env.example .env

run:
	dotnet run --project Picpay.UI 

test:
	dotnet test
