build:
	docker compose up --build -d

# Attiva i servizi dei contenitori
up:
	docker compose up -d

# Spegni e rimuovi i servizi dei contenitori
down:
	docker compose down

# Arresta i servizi dei contenitori
stop:
	docker compose stop

migrate:
	cd backend/Api && \
	export PATH="$(HOME)/.dotnet/tools:$$PATH"; \
	CONNECTION_STRING="Server=localhost,1433;Database=TennisDb;User=sa;Password=Your_password123;Encrypt=False;TrustServerCertificate=True;" \
	dotnet ef database update




clean:
	docker compose down -v --remove-orphans
	docker system prune -f