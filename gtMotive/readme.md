# Prueba técnica 

Implementar un microservicio que permita gestionar la siguiente funcionalidad:
Una Empresa de renting. El microservicio debería de permitir realizar las siguientes acciones (a través de llamadas REST):
- Debería de gestionar la creación de nuevos vehículos para la flota.
- Poder listar los vehículos disponibles de la flota.
- Poder alquilar un vehículo.
- Devolución del vehículo.

## Restricciones:
- Una misma persona no debería de poder reservar más de 1 vehículo al mismo tiempo.
- La flota no debe de contener vehículos cuya fecha de fabricación sea superior a 5 años


## Nota técnica
No he usado bases de datos y como hice un diseño codefirst he usado una base de datos en memoria con EntityFramwork: UseInMemoryDatabase

Como es una api pequeña no he implementado el Repository Pattern aunque podría haberlo hecho. 

Aqui teneis una interesante charla en su contra: https://www.c-sharpcorner.com/article/the-downsides-of-using-the-repository-pattern/

Para ejecutar la aplicación se puede hacer con un 

``docker-compose up -d #lo que va a generar un contenedor que escucha en el puerto 3000 de localhost``

Os adjunto también la colección postman con las peticiones json
