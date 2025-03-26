using LOGIN.Views;

namespace LOGIN
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void BTN_Entrar_registrar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PantallaRegistrarme());
        }

        private async void BTN_Entrar_existente(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PantallaLoginExistente());
        }
    }
}
