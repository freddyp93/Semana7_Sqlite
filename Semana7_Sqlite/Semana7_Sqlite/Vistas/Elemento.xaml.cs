using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite; //habilito el sqlite
using System.IO; //habilito opciones de entrada y salida a la base de datos
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7_Sqlite.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        //almaceno la clave primaria
        public int idSeleccionado;

        //creo la variable de conexion
        private SQLiteAsyncConnection conexion;

        //creo variables de tipo estudiante para actualizar y eliminar
        IEnumerable<TablaEstudiante> RActualizar;
        IEnumerable<TablaEstudiante> REliminar;

        //modifico constructor para que reciba cuatro elementos
        public Elemento(int id, string nombre, string usuario, string contrasenia)
        {
            InitializeComponent();
            //cargo los datos
            txtID.Text = id.ToString();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasenia.Text=contrasenia;

            //conecto a la base de datos
            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = id;
        }

        //creo metodo para eliminar
        public static IEnumerable<TablaEstudiante> Eliminar(SQLiteConnection db, int id)
        {
            //el signo =? significa que es un dato que va a llegar
            return db.Query<TablaEstudiante>("DELETE FROM TablaEstudiante where id =?", id);
        }

        //creo el metodo para actualizar
        public static IEnumerable<TablaEstudiante> Actualizar(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            //retorno la consulta
            return db.Query<TablaEstudiante>("UPDATE TablaEstudiante set Nombre=?, Usuario=?, Contrasena=? where id=?", nombre, usuario, contrasena, id);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            //metodo actualizar
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                RActualizar = Actualizar(db, txtNombre.Text, txtUsuario.Text, txtContrasenia.Text, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());
            }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            //metodo eliminar
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());
            }
            catch (Exception ex)
            {

                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }
    }
}