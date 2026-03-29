using System.Threading.Tasks;

namespace quizz_Maui.Paginas;

public partial class Resultado : ContentPage
{
	public Resultado()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        string nome = await SecureStorage.Default.GetAsync("nome");
        string parcial = await SecureStorage.Default.GetAsync("parcial");
        double final = double.Parse(parcial) / 2 * 100;


        LBLSaudacao.Text = "Olá, " + nome + "!";
        LBLResultado.Text = "Você acertou " + final + "% das respostas";
    }
}