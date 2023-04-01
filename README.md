# ApiNote - master

El código es una implementación básica de una API RESTful que maneja la entidades utilizando ASP.NET Core y Entity Framework Core.
en el archivo Note.cs en el namespace Core.Entities se define la entidad Note con los atributos y tipos de datos que se utilizarán en la base de datos. En este caso, la entidad tiene los siguientes atributos: Id, Porcentage, DateNote, Observation, y ValueNote.

El archivo NoteConfiguration.cs en el namespace Infraestructure.Data.Config, se configura la entidad Note utilizando IEntityTypeConfiguration. En este caso, se define que los atributos Id, Porcentage, DateNote, Observation, y ValueNote son requeridos en la base de datos.

El archivo INoteRepository.cs en el namespace Infraestructure.Repository.IRepository, se define la interfaz INoteRepository que hereda de la interfaz genérica IRepository<Note> y se agrega un método UpdateNote que actualizará la nota en la base de datos.

El archivo NoteRepository.cs en el namespace Infraestructure.Repository, se implementa la interfaz INoteRepository y se agrega el método UpdateNote, que actualiza la nota en la base de datos.

En el archivo NoteController.cs en el namespace ApiNote.Controllers, se define el controlador para la entidad Note. Se inyecta INoteRepository en el constructor y se implementan los métodos GetNote, AddNote, GetNote, UpdateNote y DeleteNote.
