using System;
using System.Collections.Generic;
using System.Text;
using SQLite; //utilizar los metodos de la BDD, insertar, eliminar, actualizar

namespace Semana7_Sqlite
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection(); //Defino el metodo de conexión
    }
}
