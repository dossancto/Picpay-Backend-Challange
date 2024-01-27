compose/up:
	docker compose up -d

compose/down:
	docker compose down

db/update:
	dotnet ef database update -s Picpay.UI -p Picpay.Infra

env/setup:
	cp .env.example .env

run:
	dotnet run --project Picpay.UI 
