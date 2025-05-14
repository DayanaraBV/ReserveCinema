# ReserveCinema

Una aplicación web de pila completa para reservar asientos en el cine, construida con **ASP.NET Core** (C#) para el backend y **React** (Vite + TailwindCSS) para el frontend.

## Características

- **Explorar funciones de películas**: Ver las funciones de películas disponibles y sus horarios.
- **Selección de asientos**: Ver los asientos disponibles para una función y seleccionar los que prefieras.
- **Reserva**: Reservar asientos proporcionando tu nombre.
- **Confirmación de reserva**: Obtener una confirmación con los detalles de la reserva.
- **Endpoints de administración**: Crear, actualizar y eliminar funciones (API).

## Stack Tecnológico

- **Backend**: ASP.NET Core, Entity Framework Core, PostgreSQL
- **Frontend**: React, Vite, TailwindCSS
- **API**: RESTful, CORS habilitado para el frontend

## Estructura del Proyecto

    ReserveCinema/            # Backend en ASP.NET Core
    ├── Controllers/          # Endpoints de la API (Funciones, Reservas)
    ├── ...                   # Capas de la aplicación, dominio, infraestructura
    reservecinema.frontend/   # Frontend en React
    ├── src/                  # Código fuente de React
    ├── public/               # Archivos estáticos
    ├── ...                   # Configuraciones de Vite, Tailwind
    
## Empezando

### Requisitos Previos

- .NET 8+ SDK
- Node.js 18+
- PostgreSQL

### Configuración del Backend

1. **Configurar la Base de Datos**:
   - Actualiza el archivo `ReserveCinema/appsettings.json` con tus credenciales de PostgreSQL.

   Predeterminado:
    ```   
    "DefaultConnection": "Host=localhost;Port=5432;Database=ReserveCinemaDb;Username=postgres;Password=tucontraseña"
    ```

2. **Ejecutar Migraciones y Sembrar Datos**:
    - Ejecuta el siguiente comando para aplicar las migraciones de la base de datos:

    ```
    cd ReserveCinema
    dotnet ef database update
    ```


3. **Iniciar el Backend**:
    - Para ejecutar la API del backend, ejecuta:

    ```
    dotnet run
    ```

    La API se ejecuta en https://localhost:5001 (predeterminado).

4. **Configuración del Frontend**:

    - Instalar dependencias:
    Navega a la carpeta del frontend e instala las dependencias requeridas:

    ```
    cd reservecinema.frontend
    npm install
    ```

5. **Iniciar el Frontend**:

    - Para iniciar la aplicación del frontend, ejecuta:

    ```
    npm run dev
    ```

    La aplicación se ejecuta en http://localhost:5173.

6. **Resumen de la API**
    - GET `/api/show` — Listar todas las funciones

    - POST `/api/show` — Crear una nueva función

    - PUT `/api/show/{id}` — Actualizar una función

    - DELETE `/api/show/{id}` — Eliminar una función

    - GET `/api/show/{id}` — Obtener detalles de una función

    - GET `/api/reservation/seats/{showId}` — Obtener los asientos disponibles para una función

    - POST `/api/reservation` — Crear una reserva

    - GET `/api/reservation/details/{id}` — Obtener detalles de una reserva


7. **Modelo de Dominio**
    - Función: Título de la película, hora de inicio, asientos, reservas

    - Asiento: Fila, columna, disponibilidad, función

    - Reserva: Nombre del cliente, función, asientos reservados

