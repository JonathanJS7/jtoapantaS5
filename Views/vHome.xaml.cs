using jtoapantaS5.Models;

namespace jtoapantaS5.Views;

public partial class vHome : ContentPage
{
    private Persona selectedPerson;
    public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personrepo.AddNewPerson(txtNombre.Text);
        status.Text = App.personrepo.StatusMessage;

    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Persona> people = App.personrepo.GetAllPeople();
        ListaPersonas.ItemsSource = people;
        txtNombre.Text = "";

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if (selectedPerson != null && !string.IsNullOrEmpty(txtNombre.Text))
        {
            status.Text = "";
            App.personrepo.UpdatePerson(selectedPerson.Id, txtNombre.Text);
            status.Text = App.personrepo.StatusMessage;
            btnListar_Clicked(sender, e);
            selectedPerson = null;
            txtNombre.Text = "";
        }
        else
        {
            status.Text = "Por favor, seleccione una persona de la lista y proporcione un nuevo nombre";
        }


    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (selectedPerson != null)
        {
            status.Text = "";
            App.personrepo.DeletePerson(selectedPerson.Id);
            status.Text = App.personrepo.StatusMessage;
            btnListar_Clicked(sender, e);
            selectedPerson = null;
            txtNombre.Text = "";
        }
        else
        {
            status.Text = "Por favor, seleccione una persona de la lista para eliminar";
        }

    }

    private void ListaPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            selectedPerson = (Persona)e.CurrentSelection[0];
            txtNombre.Text = selectedPerson.Nombre;
        }

    }
}