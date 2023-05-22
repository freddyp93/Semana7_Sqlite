using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite; //llamo al sqlite
using System.IO; //agrego entradas y salidas
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7_Sqlite.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //creo la variable para la conexion sql
        private SQLiteAsyncConnection conexion;
        public Login()
        {
            InitializeComponent();
            //inicializo la variable de conexion
            conexion = DependencyService.Get<DataBase>().GetConnection();

        }

        //metodo para verificar si el usuario y contrasenia coincide con la base de datos
        public static IEnumerable<TablaEstudiante> Select_Where(SQLiteConnection db, string Usuario,string Contrasena)
        {
            //ejecuto el query
            return db.Query<TablaEstudiante>("SELECT * FROM TablaEstudiante Where Usuario =? and Contrasena =?", Usuario, Contrasena);
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            //ejecuto el metodo de la conexion del SQLite con try catch
            try
            {
                //acceso a la ruta de la base
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");

                var db = new SQLiteConnection(ruta);

                //creo la tabla estudiante dentro de db
                db.CreateTable<TablaEstudiante>();

                //envio los datos
               IEnumerable<TablaEstudiante> resultado = Select_Where(db,txtUsuario.Text, txtContrasenia.Text);
                
                //verifico existencia de usuarios
                if (resultado.Count() > 0)
                {
                    //accedo al sistema
                    Navigation.PushAsync(new ConsultaRegistros());
                }
                else
                {
                    //caso contrario disparo una alerta
                    DisplayAlert("ALERTA", "Usuario/Contraseña Incorrectos", "Cerrar");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            //llamo a la ventana de registro
            Navigation.PushAsync(new Registro());
        }
    }
}