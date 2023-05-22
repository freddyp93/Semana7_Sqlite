using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7_Sqlite.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistros : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        //defino una variable
        private ObservableCollection<TablaEstudiante> tablaEstudiante;
        public ConsultaRegistros()
        {
            InitializeComponent();

            //inicializo la conexion
            conexion = DependencyService.Get<DataBase>().GetConnection();

            //oculto la flecha de navegacion
            NavigationPage.SetHasBackButton(this, false);

            //llamo al metodo
            ObtenerEstudiantes();
        }

        public async void ObtenerEstudiantes()
        {
            var ResulEstudiantes = await conexion.Table<TablaEstudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<TablaEstudiante>(ResulEstudiantes);
            listaEstudiantes.ItemsSource = tablaEstudiante;

        }


        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //metodo para el elemento que este seleccionado en el list view

            //declaro una variable
            var objetoEstudiante = (TablaEstudiante)e.SelectedItem;

            var ItemId = objetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(ItemId); //ID
            string nombre = objetoEstudiante.Nombre.ToString();
            string usuario = objetoEstudiante.Usuario.ToString();
            string contrasenia = objetoEstudiante.Contrasena.ToString();

            Navigation.PushAsync(new Elemento(id, nombre, usuario, contrasenia));
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            //metodo salir
            Navigation.PushAsync(new Login());
        }
    }
}