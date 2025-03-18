using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Configuration;
using ProyectoFinalU1;

namespace ProyectoFinalU1
{
	public class ConexionMongoDB
	{

        private readonly IMongoCollection<Trabajador> _trabajadoresCollection;
        public ConexionMongoDB()
        {
            var Cliente = new MongoClient(ConfigurationManager.AppSettings["MongoDBConnectionString"]);
            var database = Cliente.GetDatabase(ConfigurationManager.AppSettings["MongoDBDatabaseName"]);
            _trabajadoresCollection = database.GetCollection<Trabajador>("Trabajadores");
        }

        //obtiene el trabajador desde la base de datos
        public  Trabajador ObtenerTrabajador(string id)
        {

            System.Diagnostics.Debug.WriteLine("Consultando en MongoDB con ID:" + id);

            if(string.IsNullOrEmpty(id) || id.Length != 24 || !MongoDB.Bson.ObjectId.TryParse(id,out ObjectId objectId))
            {
                System.Diagnostics.Debug.WriteLine("Error: ID invalido para MongoDB.");
                return null;
            }
            return _trabajadoresCollection.Find(t => t.Id == objectId.ToString()).FirstOrDefault();
        }

        //agrega un nuevo trabajador a la coleccion de la base de datos
        public void AgregarTrabajador(Trabajador trabajador)
        {
            if (trabajador.Id == null)
            {
                trabajador.Id = ObjectId.GenerateNewId().ToString();
            }

            _trabajadoresCollection.InsertOne(trabajador);
        }

        //actualizar el trabajador en la base de datos
        public void ActualizarTrabajdor(string id, Trabajador trabajador)
            => _trabajadoresCollection.ReplaceOne(t => t.Id == id, trabajador);

        public void AgregarPagoNomina(string id, PagoNomina pago)
        {
            var filtro = Builders<Trabajador>.Filter.Eq(t => t.Id, id);
            var actualizacion = Builders<Trabajador>.Update.Push(t => t.pagos, pago);
            _trabajadoresCollection.UpdateOne(filtro, actualizacion);
        }

        //eliminar el trabajador de acuerdo a la id
        public void EliminarTrabajador(string id) =>

            _trabajadoresCollection.DeleteOne(t => t.Id == id);

        //obtiene la lista de los trabajadores de la base de datos
        public List<Trabajador> ObtenerTrabajadores() =>
            _trabajadoresCollection.Find(t => true).ToList();
        

    }
}