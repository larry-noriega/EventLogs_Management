# EventLogs_Management

## Características:
- Motor de base de datos relacional: SQL Server.
- Solución realizada en Backend ASP.NET Core 7.
- Uso de la librería Ocelot para el requerimiento APIGateway.
- Uso de Swagger UI para el requerimiento de formulario con sus respectivos filtros.
- Anexado documento postman con respectivo consumo del APIGateway y la API con sus respectivos payloads de ejemplo [postman_collection.json](https://github.com/larry-noriega/EventLogs_Management/blob/master/Documentation/Event%20Logs%20API.postman_collection.json).

## Información Adicional:
- Uso de Entity Framework como ORM.
- la base de datos `Registration` se crea inicialmente con data de prueba en la tabla `EventLogs` para agilizar las pruebas de consumo.

![image](https://github.com/user-attachments/assets/6db56a1c-28e5-4b1f-8ace-6cc6cf93799b)

![image](https://github.com/user-attachments/assets/2e505395-0f43-4a1d-a1ea-67516b3c9386)


- La solución se correo con visual studio 2022 y en el menu de configuración de proyectos de inicio es necesario seleccionar el proyecto `EventLogs_Management.WebAPI` e `EventLogs_Management.APIGateway`

![image](https://github.com/user-attachments/assets/e7b10beb-7de8-4652-9f0e-0f0bb3f05c92)

