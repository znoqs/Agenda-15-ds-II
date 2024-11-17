using AppEvento.Models;
namespace AppEvento.Views;

public partial class EventoCadastro : ContentPage
{
	public EventoCadastro()
	{
		InitializeComponent();

        dtpck_inicio.MinimumDate = DateTime.Now;
        dtpck_inicio.MaximumDate = DateTime.Now.AddMonths(1);

        dtpck_termino.MaximumDate = dtpck_inicio.Date.AddDays(3);
        dtpck_termino.MinimumDate = dtpck_inicio.Date.AddDays(1);
    }

    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_inicio = elemento.Date;

        dtpck_termino.MaximumDate = data_selecionada_inicio.AddDays(1);
        dtpck_termino.MinimumDate = data_selecionada_inicio.AddDays(3);

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {

            Evento evento = new Evento
            {
                NomeEvento = entry_evento.Text,
                QtdConvidados = Convert.ToInt32(stp_convidados.Value),
                DataInicio = dtpck_inicio.Date,
                DataTermino = dtpck_termino.Date,
                Endereco = entry_endereco.Text,
                ValorPorConvidado = Convert.ToDouble(valorConvidado.Text)
            };
            
            await Navigation.PushAsync(new EventoCadastrado()
            {
                BindingContext = evento
            });

        } catch (Exception ex)
        {
           await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}