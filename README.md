# Agendamiento Turnos
Solución de agendamiento de turnos para que los clientes de varios comercios.

## Requisitos

Asegúrate de tener instalados los siguientes componentes antes de continuar:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)


## Configuración

### Base de Datos

1. En la raiz del repositorio hay un archivo .rar (Reserva_Turnos.rar) con los scripts de creación de base de datos, objetos e inserts de configuración, favor ejecutarlo en una base de datos Sql Server

2. Configura la cadena de conexión en `appsettings.json` o en las variables de entorno según corresponda:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TuBaseDeDatos;User Id=TuUsuario;Password=TuContraseña;"
  }
}
```
## Ejecución

1. Establecer cómo proyecto de inicio la Api "Reserva_Turnos"
2. Al ejecutar el proyecto se va a abrir Swagger con un Turnos
2.1 Cómo request body podemos enviar el siguiente Json:

```json
{
  "fechaInicio": "19/08/2023",
  "fechaFin": "19/08/2023",
  "idServicio": 1
}
```

Esto reservaría turnos para el servicio 1 que según nuestra configuración de Base de datos es el servicio de "Corte" del comercio de "Barberia", y cómo
respuesta obtendríamos un Json donde se van a ver propiedades cómo fechaTurno, horaInicio, horaFin, nombreServicio y nombreComercio

## Pruebas Unitarias

1. Las pruebas unitarias se realizaron usando el frameword NUnit y se testeo el controlador, la capa de negocio y las validaciones del objeto que se recibe en el request.

