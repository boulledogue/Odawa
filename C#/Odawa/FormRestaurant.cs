using BU;
using BU.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odawa
{
    public partial class FormRestaurant : Form
    {
        public int restaurantId { get; set; }

        public FormRestaurant()
        {
            this.restaurantId = -1;
            InitializeComponent();
            comboBoxRestaurateur.DataSource = RestaurateurManager.GetAll();
            comboBoxRestaurateur.DisplayMember = "nom";
            comboBoxRestaurateur.ValueMember = "id";
            comboBoxTypeCuisine.DataSource = TypeCuisineManager.GetAll();
            comboBoxTypeCuisine.DisplayMember = "type";
            comboBoxTypeCuisine.ValueMember = "id";
            comboBoxGenre.DisplayMember = "Text";
            comboBoxGenre.ValueMember = "Value";
            var items = new[] { 
                new { Text = "Restaurant", Value = 1 }, 
                new { Text = "Snack", Value = 2 }
            };
            comboBoxGenre.DataSource = items;            
        }

        public FormRestaurant(int id) : this()
        {
            comboBoxRestaurateur.SelectedValue = id;
        }

        public FormRestaurant(Restaurant restaurant) : this()
        {
            this.restaurantId = restaurant.id;            
            textBoxName.Text = restaurant.nom;
            textBoxAdresse.Text = restaurant.adresse;
            textBoxNumber.Text = restaurant.numero;
            textBoxZipcode.Text = restaurant.zipCode;
            textBoxLocalite.Text = restaurant.localite;
            textBoxBudgetLow.Text = restaurant.budgetLow.ToString();
            textBoxBudgetHigh.Text = restaurant.budgetHigh.ToString();
            checkBoxPromotion.Checked = restaurant.premium;
            richTextBoxDescription.Text = restaurant.description;
            comboBoxRestaurateur.SelectedValue = restaurant.idRestaurateur;
            comboBoxTypeCuisine.SelectedValue = restaurant.idTypeCuisine;
            comboBoxGenre.SelectedValue = restaurant.genre;
            PopulateHoraire(restaurant.horaire);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.id = this.restaurantId;
            restaurant.nom = textBoxName.Text;
            restaurant.adresse = textBoxAdresse.Text;
            restaurant.numero = textBoxNumber.Text;
            restaurant.zipCode = textBoxZipcode.Text;
            restaurant.localite = textBoxLocalite.Text;
            restaurant.premium = checkBoxPromotion.Checked;
            restaurant.idRestaurateur = int.Parse(comboBoxRestaurateur.SelectedValue.ToString());
            restaurant.idTypeCuisine = int.Parse(comboBoxTypeCuisine.SelectedValue.ToString());
            restaurant.genre = int.Parse(comboBoxGenre.SelectedValue.ToString());
            restaurant.budgetLow = int.Parse(textBoxBudgetLow.Text);
            restaurant.budgetHigh = int.Parse(textBoxBudgetHigh.Text);
            restaurant.horaire = BuildHoraireString();
            restaurant.description = richTextBoxDescription.Text;

            if (Validate(restaurant))
            {
                if (restaurantId == -1) RestaurantManager.Create(restaurant);
                else RestaurantManager.Update(restaurant);
                this.Dispose();
            }
        }

        private bool Validate(Restaurant restaurant)
        {
            labelNom.ForeColor = Color.Empty;
            labelAdresse.ForeColor = Color.Empty;
            labelNumero.ForeColor = Color.Empty;
            labelZipCode.ForeColor = Color.Empty;
            labelLocalite.ForeColor = Color.Empty;
            labelRestaurateur.ForeColor = Color.Empty;
            labelTypeCuisine.ForeColor = Color.Empty;
            labelPremium.ForeColor = Color.Empty;

            bool valid = true;
            string message = "";

            if(restaurant.nom.Length < 2)
            {
                labelNom.ForeColor = Color.Red;
                valid = false;
                message += "- Le nom doit contenir au moins 2 caractères.\n";
            }

            if(restaurant.adresse.Length < 6)
            {
                labelAdresse.ForeColor = Color.Red;
                valid = false;
                message += "- L'adresse doit contenir au moins 6 caractères.\n";
            }

            if (!valid)
            {
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }

            return valid;
        }

        private void PopulateHoraire(String horaire)
        {
            String[] horaireSemaine = horaire.Split(';');
            String[] horaireLundi = horaireSemaine[0].Split('-');
            String[] horaireMardi = horaireSemaine[1].Split('-');
            String[] horaireMercredi = horaireSemaine[2].Split('-');
            String[] horaireJeudi = horaireSemaine[3].Split('-');
            String[] horaireVendredi = horaireSemaine[4].Split('-');
            String[] horaireSamedi = horaireSemaine[5].Split('-');
            String[] horaireDimanche = horaireSemaine[6].Split('-');

            if (horaireLundi[0].Equals("0000") && horaireLundi[1].Equals("0000")) checkBoxMondayClosed.Checked = true;
            else if (horaireLundi[0].Equals("1111") && horaireLundi[1].Equals("1111")) checkBoxMondayOpen24.Checked = true;
            else
            {
                MondayOpenHour.Value = int.Parse(horaireLundi[0].Substring(0, 2));
                MondayOpenMinutes.Value = int.Parse(horaireLundi[0].Substring(2, 2));
                MondayCloseHour.Value = int.Parse(horaireLundi[1].Substring(0, 2));
                MondayCloseMinutes.Value = int.Parse(horaireLundi[1].Substring(2, 2));
            }

            if (horaireMardi[0].Equals("0000") && horaireMardi[1].Equals("0000")) checkBoxTuesdayClosed.Checked = true;
            else if (horaireMardi[0].Equals("1111") && horaireMardi[1].Equals("1111")) checkBoxTuesdayOpen24.Checked = true;
            else
            {
                TuesdayOpenHour.Value = int.Parse(horaireMardi[0].Substring(0, 2));
                TuesdayOpenMinutes.Value = int.Parse(horaireMardi[0].Substring(2, 2));
                TuesdayCloseHour.Value = int.Parse(horaireMardi[1].Substring(0, 2));
                TuesdayCloseMinutes.Value = int.Parse(horaireMardi[1].Substring(2, 2));
            }

            if (horaireMercredi[0].Equals("0000") && horaireMercredi[1].Equals("0000")) checkBoxWednesdayClosed.Checked = true;
            else if (horaireMercredi[0].Equals("1111") && horaireMercredi[1].Equals("1111")) checkBoxWednesdayOpen24.Checked = true;
            else
            {
                WednesdayOpenHour.Value = int.Parse(horaireMercredi[0].Substring(0, 2));
                WednesdayOpenMinutes.Value = int.Parse(horaireMercredi[0].Substring(2, 2));
                WednesdayCloseHour.Value = int.Parse(horaireMercredi[1].Substring(0, 2));
                WednesdayCloseMinutes.Value = int.Parse(horaireMercredi[1].Substring(2, 2));
            }

            if (horaireJeudi[0].Equals("0000") && horaireJeudi[1].Equals("0000")) checkBoxThursdayClosed.Checked = true;
            else if (horaireJeudi[0].Equals("1111") && horaireJeudi[1].Equals("1111")) checkBoxThursdayOpen24.Checked = true;
            else
            {
                ThursdayOpenHour.Value = int.Parse(horaireJeudi[0].Substring(0, 2));
                ThursdayOpenMinutes.Value = int.Parse(horaireJeudi[0].Substring(2, 2));
                ThursdayCloseHour.Value = int.Parse(horaireJeudi[1].Substring(0, 2));
                ThursdayCloseMinutes.Value = int.Parse(horaireJeudi[1].Substring(2, 2));
            }

            if (horaireVendredi[0].Equals("0000") && horaireVendredi[1].Equals("0000")) checkBoxFridayClosed.Checked = true;
            else if (horaireVendredi[0].Equals("1111") && horaireVendredi[1].Equals("1111")) checkBoxFridayOpen24.Checked = true;
            else
            {
                FridayOpenHour.Value = int.Parse(horaireVendredi[0].Substring(0, 2));
                FridayOpenMinutes.Value = int.Parse(horaireVendredi[0].Substring(2, 2));
                FridayCloseHour.Value = int.Parse(horaireVendredi[1].Substring(0, 2));
                FridayCloseMinutes.Value = int.Parse(horaireVendredi[1].Substring(2, 2));
            }

            if (horaireSamedi[0].Equals("0000") && horaireSamedi[1].Equals("0000")) checkBoxSaturdayClosed.Checked = true;
            else if (horaireSamedi[0].Equals("1111") && horaireSamedi[1].Equals("1111")) checkBoxSaturdayOpen24.Checked = true;
            else
            {
                SaturdayOpenHour.Value = int.Parse(horaireSamedi[0].Substring(0, 2));
                SaturdayOpenMinutes.Value = int.Parse(horaireSamedi[0].Substring(2, 2));
                SaturdayCloseHour.Value = int.Parse(horaireSamedi[1].Substring(0, 2));
                SaturdayCloseMinutes.Value = int.Parse(horaireSamedi[1].Substring(2, 2));
            }

            if (horaireDimanche[0].Equals("0000") && horaireDimanche[1].Equals("0000")) checkBoxSundayClosed.Checked = true;
            else if (horaireDimanche[0].Equals("1111") && horaireDimanche[1].Equals("1111")) checkBoxSundayOpen24.Checked = true;
            else
            {
                SundayOpenHour.Value = int.Parse(horaireDimanche[0].Substring(0, 2));
                SundayOpenMinutes.Value = int.Parse(horaireDimanche[0].Substring(2, 2));
                SundayCloseHour.Value = int.Parse(horaireDimanche[1].Substring(0, 2));
                SundayCloseMinutes.Value = int.Parse(horaireDimanche[1].Substring(2, 2));
            }
        }

        private String BuildHoraireString()
        {
            StringBuilder horaire = new StringBuilder();

            if (checkBoxMondayClosed.Checked) horaire.Append("0000-0000;");
            else if (checkBoxMondayOpen24.Checked) horaire.Append("1111-1111;");
            else horaire.Append(MondayOpenHour.Value.ToString("0#") + MondayOpenMinutes.Value.ToString("0#") + "-" + MondayCloseHour.Value.ToString("0#") + MondayCloseMinutes.Value.ToString("0#") + ";");

            if (checkBoxTuesdayClosed.Checked) horaire.Append("0000-0000;");
            else if (checkBoxTuesdayOpen24.Checked) horaire.Append("1111-1111;");
            else horaire.Append(TuesdayOpenHour.Value.ToString("0#") + TuesdayOpenMinutes.Value.ToString("0#") + "-" + TuesdayCloseHour.Value.ToString("0#") + TuesdayCloseMinutes.Value.ToString("0#") + ";");

            if (checkBoxWednesdayClosed.Checked) horaire.Append("0000-0000;");
            else if (checkBoxWednesdayOpen24.Checked) horaire.Append("1111-1111;");
            else horaire.Append(WednesdayOpenHour.Value.ToString("0#") + WednesdayOpenMinutes.Value.ToString("0#") + "-" + WednesdayCloseHour.Value.ToString("0#") + WednesdayCloseMinutes.Value.ToString("0#") + ";");

            if (checkBoxThursdayClosed.Checked) horaire.Append("0000-0000;");
            else if (checkBoxThursdayOpen24.Checked) horaire.Append("1111-1111;");
            else horaire.Append(ThursdayOpenHour.Value.ToString("0#") + ThursdayOpenMinutes.Value.ToString("0#") + "-" + ThursdayCloseHour.Value.ToString("0#") + ThursdayCloseMinutes.Value.ToString("0#") + ";");

            if (checkBoxFridayClosed.Checked) horaire.Append("0000-0000;");
            else if (checkBoxFridayOpen24.Checked) horaire.Append("1111-1111;");
            else horaire.Append(FridayOpenHour.Value.ToString("0#") + FridayOpenMinutes.Value.ToString("0#") + "-" + FridayCloseHour.Value.ToString("0#") + FridayCloseMinutes.Value.ToString("0#") + ";");

            if (checkBoxSaturdayClosed.Checked) horaire.Append("0000-0000;");
            else if (checkBoxSaturdayOpen24.Checked) horaire.Append("1111-1111;");
            else horaire.Append(SaturdayOpenHour.Value.ToString("0#") + SaturdayOpenMinutes.Value.ToString("0#") + "-" + SaturdayCloseHour.Value.ToString("0#") + SaturdayCloseMinutes.Value.ToString("0#") + ";");

            if (checkBoxSundayClosed.Checked) horaire.Append("0000-0000");
            else if (checkBoxSundayOpen24.Checked) horaire.Append("1111-1111");
            else horaire.Append(SundayOpenHour.Value.ToString("0#") + SundayOpenMinutes.Value.ToString("0#") + "-" + SundayCloseHour.Value.ToString("0#") + SundayCloseMinutes.Value.ToString("0#") + ";");

            return horaire.ToString();
        }


        // Gestion des checkboxes

        private void checkBoxMondayClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMondayClosed.Checked)
            {
                checkBoxMondayOpen24.Checked = false;
                checkBoxMondayOpen24.Enabled = false;
                MondayOpenHour.Enabled = false;
                MondayOpenMinutes.Enabled = false;
                MondayCloseHour.Enabled = false;
                MondayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxMondayOpen24.Enabled = true;
                MondayOpenHour.Enabled = true;
                MondayOpenMinutes.Enabled = true;
                MondayCloseHour.Enabled = true;
                MondayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxMondayOpen24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMondayOpen24.Checked)
            {
                checkBoxMondayClosed.Checked = false;
                checkBoxMondayClosed.Enabled = false;
                MondayOpenHour.Enabled = false;
                MondayOpenMinutes.Enabled = false;
                MondayCloseHour.Enabled = false;
                MondayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxMondayClosed.Enabled = true;
                MondayOpenHour.Enabled = true;
                MondayOpenMinutes.Enabled = true;
                MondayCloseHour.Enabled = true;
                MondayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxTuesdayClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTuesdayClosed.Checked)
            {
                checkBoxTuesdayOpen24.Checked = false;
                checkBoxTuesdayOpen24.Enabled = false;
                TuesdayOpenHour.Enabled = false;
                TuesdayOpenMinutes.Enabled = false;
                TuesdayCloseHour.Enabled = false;
                TuesdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxTuesdayOpen24.Enabled = true;
                TuesdayOpenHour.Enabled = true;
                TuesdayOpenMinutes.Enabled = true;
                TuesdayCloseHour.Enabled = true;
                TuesdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxTuesdayOpen24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTuesdayOpen24.Checked)
            {
                checkBoxTuesdayClosed.Checked = false;
                checkBoxTuesdayClosed.Enabled = false;
                TuesdayOpenHour.Enabled = false;
                TuesdayOpenMinutes.Enabled = false;
                TuesdayCloseHour.Enabled = false;
                TuesdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxTuesdayClosed.Enabled = true;
                TuesdayOpenHour.Enabled = true;
                TuesdayOpenMinutes.Enabled = true;
                TuesdayCloseHour.Enabled = true;
                TuesdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxWednesdayClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWednesdayClosed.Checked)
            {
                checkBoxWednesdayOpen24.Checked = false;
                checkBoxWednesdayOpen24.Enabled = false;
                WednesdayOpenHour.Enabled = false;
                WednesdayOpenMinutes.Enabled = false;
                WednesdayCloseHour.Enabled = false;
                WednesdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxWednesdayOpen24.Enabled = true;
                WednesdayOpenHour.Enabled = true;
                WednesdayOpenMinutes.Enabled = true;
                WednesdayCloseHour.Enabled = true;
                WednesdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxWednesdayOpen24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWednesdayOpen24.Checked)
            {
                checkBoxWednesdayClosed.Checked = false;
                checkBoxWednesdayClosed.Enabled = false;
                WednesdayOpenHour.Enabled = false;
                WednesdayOpenMinutes.Enabled = false;
                WednesdayCloseHour.Enabled = false;
                WednesdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxWednesdayClosed.Enabled = true;
                WednesdayOpenHour.Enabled = true;
                WednesdayOpenMinutes.Enabled = true;
                WednesdayCloseHour.Enabled = true;
                WednesdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxThursdayClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThursdayClosed.Checked)
            {
                checkBoxThursdayOpen24.Checked = false;
                checkBoxThursdayOpen24.Enabled = false;
                ThursdayOpenHour.Enabled = false;
                ThursdayOpenMinutes.Enabled = false;
                ThursdayCloseHour.Enabled = false;
                ThursdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxThursdayOpen24.Enabled = true;
                ThursdayOpenHour.Enabled = true;
                ThursdayOpenMinutes.Enabled = true;
                ThursdayCloseHour.Enabled = true;
                ThursdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxThursdayOpen24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThursdayOpen24.Checked)
            {
                checkBoxThursdayClosed.Checked = false;
                checkBoxThursdayClosed.Enabled = false;
                ThursdayOpenHour.Enabled = false;
                ThursdayOpenMinutes.Enabled = false;
                ThursdayCloseHour.Enabled = false;
                ThursdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxThursdayClosed.Enabled = true;
                ThursdayOpenHour.Enabled = true;
                ThursdayOpenMinutes.Enabled = true;
                ThursdayCloseHour.Enabled = true;
                ThursdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxFridayClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFridayClosed.Checked)
            {
                checkBoxFridayOpen24.Checked = false;
                checkBoxFridayOpen24.Enabled = false;
                FridayOpenHour.Enabled = false;
                FridayOpenMinutes.Enabled = false;
                FridayCloseHour.Enabled = false;
                FridayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxFridayOpen24.Enabled = true;
                FridayOpenHour.Enabled = true;
                FridayOpenMinutes.Enabled = true;
                FridayCloseHour.Enabled = true;
                FridayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxFridayOpen24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFridayOpen24.Checked)
            {
                checkBoxFridayClosed.Checked = false;
                checkBoxFridayClosed.Enabled = false;
                FridayOpenHour.Enabled = false;
                FridayOpenMinutes.Enabled = false;
                FridayCloseHour.Enabled = false;
                FridayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxFridayClosed.Enabled = true;
                FridayOpenHour.Enabled = true;
                FridayOpenMinutes.Enabled = true;
                FridayCloseHour.Enabled = true;
                FridayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxSaturdayClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSaturdayClosed.Checked)
            {
                checkBoxSaturdayOpen24.Checked = false;
                checkBoxSaturdayOpen24.Enabled = false;
                SaturdayOpenHour.Enabled = false;
                SaturdayOpenMinutes.Enabled = false;
                SaturdayCloseHour.Enabled = false;
                SaturdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxSaturdayOpen24.Enabled = true;
                SaturdayOpenHour.Enabled = true;
                SaturdayOpenMinutes.Enabled = true;
                SaturdayCloseHour.Enabled = true;
                SaturdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxSaturdayOpen24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSaturdayOpen24.Checked)
            {
                checkBoxSaturdayClosed.Checked = false;
                checkBoxSaturdayClosed.Enabled = false;
                SaturdayOpenHour.Enabled = false;
                SaturdayOpenMinutes.Enabled = false;
                SaturdayCloseHour.Enabled = false;
                SaturdayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxSaturdayClosed.Enabled = true;
                SaturdayOpenHour.Enabled = true;
                SaturdayOpenMinutes.Enabled = true;
                SaturdayCloseHour.Enabled = true;
                SaturdayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxSundayClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSundayClosed.Checked)
            {
                checkBoxSundayOpen24.Checked = false;
                checkBoxSundayOpen24.Enabled = false;
                SundayOpenHour.Enabled = false;
                SundayOpenMinutes.Enabled = false;
                SundayCloseHour.Enabled = false;
                SundayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxSundayOpen24.Enabled = true;
                SundayOpenHour.Enabled = true;
                SundayOpenMinutes.Enabled = true;
                SundayCloseHour.Enabled = true;
                SundayCloseMinutes.Enabled = true;
            }
        }

        private void checkBoxSundayOpen24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSundayOpen24.Checked)
            {
                checkBoxSundayClosed.Checked = false;
                checkBoxSundayClosed.Enabled = false;
                SundayOpenHour.Enabled = false;
                SundayOpenMinutes.Enabled = false;
                SundayCloseHour.Enabled = false;
                SundayCloseMinutes.Enabled = false;
            }
            else
            {
                checkBoxSundayClosed.Enabled = true;
                SundayOpenHour.Enabled = true;
                SundayOpenMinutes.Enabled = true;
                SundayCloseHour.Enabled = true;
                SundayCloseMinutes.Enabled = true;
            }
        }
    }
}
