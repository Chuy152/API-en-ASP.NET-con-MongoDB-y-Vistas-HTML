using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Trabajador
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; }

    [BsonElement("nombre")]

    public string nombre { get; set; }

    [BsonElement("puesto")]

    public string puesto { get; set; }

    [BsonElement("pagos")]

    public List<PagoNomina> pagos { get; set; } = new List<PagoNomina>();

}