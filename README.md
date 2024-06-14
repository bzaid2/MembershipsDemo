# MembershipsDemo

El presente proyecto, pretende ser una demostración de los conocimientos que actualmente poseo y que forma parte de un portafolio que se irá actualizando según sea requerido, con la finalidad de facilitar un panorama completo a las instituciones, empresas o personas que quieran evaluar mis capacidades.

## Descripción del proyecto

El proyecto está construido en Wpf con Net core 8. Es un registro de "socios" que cuenta con las siguientes caracteristicas:

* Listado de socios
* Agregar nuevos socios
* Actualizar socios existentes
* Eliminar socios
* Control de errores
* Mensajes en pantalla
* Registro de logs
* Principios de SOLID
* Patrón de diseño MVVM
* Controles de usuarios

## Definición y propósito de los proyectos que involucran la aplicación

* MembershipsDemo - Aplicación principal que tiene el propósito de levantar la interfaz gráfica y cargar la configuración de todos los componentes involucrados.
* MembershipsDemo.Interfaces - Proyecto para definir todas las interfaces de la aplicación, que servirán para el "IOC".
* MembershipsDemo.LiteDb - Proyecto que contiene las consultas de la base de datos local hecha en LiteDb, permite la persistencia de la aplicación.
* MembershipsDemo.Messenger - Proyecto encargado de la comunicación entre los componentes de la aplicación.
* MembershipsDemo.Models - Proyecto que define los objetos y atributos de las representaciones abstractas.
* MembershipsDemo.Plugins - Proyecto que sirve para albergar todas las dependencias de terceros y que permite su fácil sustitución mediante el ["Principio de sustitución de Liskov"](https://es.wikipedia.org/wiki/Principio_de_sustituci%C3%B3n_de_Liskov)
* MembershipsDemo.Tests - Proyecto que contiene las pruebas unitarias de la aplicación, con la finalidad de tener siempre la regla de negocio como prioridad
* MembershipsDemo.Validators - Proyecto que se encarga de realizar las validaciones de los distintos modelos.
* MembershipsDemo.ViewModels - Proyecto que tiene la lógica de la aplicación segmentada por pequeñas clases que cumplen con el ["Principio de responsabilidad única"](https://es.wikipedia.org/wiki/Principio_de_responsabilidad_%C3%BAnica)

## Revisión de código SonarQube

```cmd
dotnet sonarscanner begin /k:"MembershipsDemo" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="{token}"

dotnet build

dotnet sonarscanner end /d:sonar.token="{token}"
```

![sonarqube](https://i.ibb.co/mqX4Hq6/sonarqube.png)
