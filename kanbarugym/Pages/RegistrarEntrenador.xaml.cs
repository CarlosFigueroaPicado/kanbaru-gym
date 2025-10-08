using System;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace kanbarugym.Pages
{
    public partial class RegistrarEntrenador : ContentPage
    {
        public ObservableCollection<string> Especialidades { get; set; }

        public RegistrarEntrenador()
        {
            InitializeComponent();

            //lista de especialidades
            Especialidades = new ObservableCollection<string>
            {
                "Cardio",
                "Fuerza",
                "Yoga",
                "Pilates"
            };

            // Establecer el contexto de enlace de datos
            BindingContext = this;
        }

        private async void OnCreateEntrenador(object sender, EventArgs e)
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombreEntrenador.Text))
            {
                await DisplayAlert("Error", "El nombre es obligatorio.", "OK");
                return;
            }

            // Validar fecha de nacimiento (formato YYYY-MM-DD)
            if (string.IsNullOrWhiteSpace(txtFechaNacimientoEntrenador.Text) ||
                !DateTime.TryParse(txtFechaNacimientoEntrenador.Text, out DateTime fechaNacimiento))
            {
                await DisplayAlert("Error", "Ingresa una fecha v�lida en formato YYYY-MM-DD.", "OK");
                return;
            }

            // Validar sexo
            if (cmbSexoEntrenador.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Selecciona el sexo.", "OK");
                return;
            }

            // Validar experiencia
            if (string.IsNullOrWhiteSpace(txtExperiencia.Text) ||
                !int.TryParse(txtExperiencia.Text, out int experiencia) || experiencia < 0)
            {
                await DisplayAlert("Error", "Ingresa una experiencia v�lida en a�os.", "OK");
                return;
            }

            // Validar especialidad
            if (cmbEspecialidad.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Selecciona una especialidad.", "OK");
                return;
            }

            // Validar correo electr�nico
            if (string.IsNullOrWhiteSpace(txtCorreoEntrenador.Text) ||
                !Regex.IsMatch(txtCorreoEntrenador.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DisplayAlert("Error", "Ingresa un correo electr�nico v�lido.", "OK");
                return;
            }

            // Validar n�mero de tel�fono
            if (string.IsNullOrWhiteSpace(txtTelefonoEntrenador.Text) ||
                txtTelefonoEntrenador.Text.Length < 7)
            {
                await DisplayAlert("Error", "Ingresa un n�mero de tel�fono v�lido.", "OK");
                return;
            }

            // Si todo est� bien, mostrar mensaje de �xito
            await DisplayAlert("�xito", "Entrenador registrado correctamente.", "OK");

            // Opcional: limpiar campos
            txtNombreEntrenador.Text = string.Empty;
            txtFechaNacimientoEntrenador.Text = string.Empty;
            cmbSexoEntrenador.SelectedIndex = -1;
            txtExperiencia.Text = string.Empty;
            cmbEspecialidad.SelectedIndex = -1;
            txtCorreoEntrenador.Text = string.Empty;
            txtTelefonoEntrenador.Text = string.Empty;
        }
    }
}
