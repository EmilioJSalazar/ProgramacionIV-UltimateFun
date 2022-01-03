using System;

using UltimateFunUWP.ViewModels;
using UltimateFunUWP.Views.Users;
using Windows.UI.Xaml.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Windows.UI.Xaml.Input;

namespace UltimateFunUWP.Views
{
    public sealed partial class UsersPage : Page
    {
        public UsersViewModel ViewModel { get; } = new UsersViewModel();

        public UsersPage()
        {
            InitializeComponent();
        }

        //SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-SL1SN3F\SQLEXPRESS; Initial catalog=EntretenimientoBD;Integrated Security=True");

        public async Task logearAsync(string usuario, string contrasena)
        {
            if(usuario == "" ^ contrasena == ""){
                this.ErrorMessage.Text = ("Usuario y/o contraseña no pueden estar vacíos");
            }
            else
            {
                UsuariosViewModel cancion = new UsuariosViewModel();
                var httpHandler = new HttpClientHandler();
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44344/api/usuarios");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");

                var client = new HttpClient(httpHandler);

                HttpResponseMessage response = await client.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(content);

                /* System.Collections.IList list = resultado;
                 foreach (dynamic item in list)
                 {
                     string firstName = item.nombre;
                     this.ErrorMessage.Text = (firstName);
                 }
                 string r = "....";
                 for (int i = 0; i < list.Count; i++)
                 {
                     r = r + list[i];
                     /*if (list.Equals(cancion.Usuario))
                     {
                         byte[] item = (byte[])list[i];
                         cancion.Deserializar(item);

                     }
                     {
                         r = r + list[i];
                     }
                 }

                 Lista.ItemsSource = resultado;


                 this.ErrorMessage.Text = (r);*/
                Lista.ItemsSource = resultado;

                if (contrasena.Equals("123"))
                {
                    if (usuario.Equals("Patty"))
                    {
                       this.ErrorMessage.Text = ("Bienvenida Patricia Zurita (Administrador)");
                        Lista.ItemsSource = resultado;
                    }
                    else if(usuario.Equals("Dome"))
                    {
                        this.ErrorMessage.Text = ("Bienvenida Domenica Rueda (Administrador)");
                        Lista.ItemsSource = resultado;
                    }
                    else if(usuario.Equals("Emilio"))
                    {
                        this.ErrorMessage.Text = ("Bienvenido Emilio Salazar (Administrador)");
                        Lista.ItemsSource = resultado;
                    }
                    else if(usuario.Equals("Juan"))
                    {
                        this.ErrorMessage.Text = ("Bienvenido Juan (Usuario)");
                        Lista.ItemsSource = null;
                        
                    }
                    else
                    {
                        this.ErrorMessage.Text = ("Usuario y/o contraseña incorrectos");
                    }
                }
                else
                {
                   this.ErrorMessage.Text = ("Usuario y/o contraseña incorrectos");
                }

                //UsuarioTextBox.Visibility=false;
            }
            /* try
             {
                 con.Open();
                 SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_usuario FROM usuarios WHERE Usuario = @usuario AND Password = @pas", con);
                 cmd.Parameters.AddWithValue("usuario", usuario);
                 cmd.Parameters.AddWithValue("pas", contrasena);
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);



                 if (dt.Rows.Count == 1)
                 {
                     //cambiar pantalla
                     //Frame.Navigate(typeof(PeliculasPage));
                     if (dt.Rows[0][1].ToString() == "Administrador")
                     {
                         new Registro(dt.Rows[0][0].ToString(), "Administrador");
                         Frame.Navigate(typeof(Registro));


                     }
                     else if(dt.Rows[0][1].ToString() == "Usuario")
                     {
                         new Registro(dt.Rows[0][0].ToString(), "Usuario");
                         Frame.Navigate(typeof(Registro));
                     }
                 }
                 else 
                 {
                     this.ErrorMessage.Text = ("Usuario y/o contraseña incorrectos");
                 }
             }
             catch(Exception e){
                 this.ErrorMessage.Text=(e.Message);
             }*/
        }

        private void LoginButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.ErrorMessage.Text = ("...");
            _ = logearAsync(this.UsuarioTextBox.Text, this.PasswordTextBox.Password.ToString());

        }

        private void Lista_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            /*ListView movies = (ListView)sender;
            menu.ShowAt(movies, e.GetPosition(movies));
            var pel = ((FrameworkElement)e.OriginalSource).DataContext as PeliculasViewModel;
            peliSeleccionada = pel.PeliculaID;
            DetailsPelicula.detallePeli = pel.PeliculaID;
            EditPelicula.EditarPeliID = pel.PeliculaID;*/

        }

        private void Details_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(DetailsPelicula));

        }
        private async void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            /*var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44344/api/peliculas" + "/" + peliSeleccionada);
            request.Method = HttpMethod.Delete;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                httpHandler = new HttpClientHandler();
                request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:44344/api/peliculas");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");

                client = new HttpClient(httpHandler);

                response = await client.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<PeliculasViewModel>>(content);
                Lista.ItemsSource = resultado;

            }*/
        }
        private void Edit_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(EditPelicula));

        }
        private void RegisterButtonTextBlock_OnPointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Registro));
        }

        private void TextBlock_SelectionChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
