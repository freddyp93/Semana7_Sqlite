using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite; //implemento los metodos del sqlite
using System.IO; //implemento metodos de entrada y salida 
using Semana7_Sqlite.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))] //le digo al compilador que tambien agregue la clase de ClienteAndroid

namespace Semana7_Sqlite.Droid
{
    public class ClienteAndroid : DataBase
    {
        //se coloca la clase publica por que el data base esta en
        //otro proyecto

        //llamo al data base
        public SQLiteAsyncConnection GetConnection()
        {
            //implemento la ruta hacia la base de datos y la base de datos
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            //creo la base de datos sobre la ruta anterior
            var BaseDatos = Path.Combine(ruta, "uisrael.db3"); //no debe cambiar la extension .db3
            return new SQLiteAsyncConnection(BaseDatos);
        }
    }
}