using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[Serializable]
public class PagoNomina
{
    [BsonElement("fecha")]
    public DateTime fecha { get; set; }

    [BsonElement("monto")]
    public decimal monto { get; set; }
}