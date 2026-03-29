namespace quizz_Maui.Paginas;

public partial class Questao2 : ContentPage
{
	bool marcou = false;
	bool acerto = false;

	public Questao2()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

	private void verificar(object sender, EventArgs e)
	{
		if (marcou)
		{
			marcou = false;
		}
		else
		{
			RadioButton opcao = sender as RadioButton;
            string valorOpcao = opcao.Value.ToString();

            acerto = valorOpcao.Contains("certo") ? true : false;

			marcou = true;
        }
    }

    private async void BTNVerificar_Clicked(object sender, EventArgs e)
    {
		if (acerto)
		{
            string valor = await SecureStorage.GetAsync("parcial");
            double parcial = double.Parse(valor);
            parcial = parcial + 1;
            await SecureStorage.SetAsync("parcial", parcial.ToString());

            await Navigation.PushAsync(new Paginas.Resultado());
        }
		else
		{
            await Navigation.PushAsync(new Paginas.Resultado());
        }
    }
}