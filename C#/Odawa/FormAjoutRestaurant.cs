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
    public partial class FormAjoutRestaurant : Form
    {
        public int restaurantId { get; set; }

        public FormAjoutRestaurant()
        {
            this.restaurantId = -1;
            InitializeComponent();
        }

        public FormAjoutRestaurant(Restaurant restaurant) : this()
        {
            this.restaurantId = restaurant.id;
            textBoxName.DataBindings.Add("Text", restaurant, "nom");
            textBoxAdresse.DataBindings.Add("Text", restaurant, "adresse");
            textBoxNumber.DataBindings.Add("Text", restaurant, "numero");
            textBoxZipcode.DataBindings.Add("Text", restaurant, "zipCode");
            textBoxLocalite.DataBindings.Add("Text", restaurant, "localite");
            checkBoxPromotion.DataBindings.Add("Checked", restaurant, "premium");
            comboBoxRestaurateur.DataBindings.Add("Text", restaurant, "idRestaurateur");
            comboBoxTypeCuisine.DataBindings.Add("Text", restaurant, "idTypeCuisine");
            textBoxHoraire.DataBindings.Add("Text", restaurant, "horaire");
        }

        private void saveRestaurant_Click(object sender, EventArgs e)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.id = this.restaurantId;
            restaurant.nom = textBoxName.Text;
            restaurant.adresse = textBoxAdresse.Text;
            restaurant.numero = textBoxNumber.Text;
            restaurant.zipCode = textBoxZipcode.Text;
            restaurant.localite = textBoxLocalite.Text;
            restaurant.premium = checkBoxPromotion.Checked;
            //restaurant.idRestaurateur = Int32.Parse(textBoxRestaurateur.Text);
            //restaurant.idTypeCuisine = Int32.Parse(textBoxTypecuisine.Text);
            restaurant.horaire = textBoxHoraire.Text;
            restaurant.description = "";

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
            labelHoraire.ForeColor = Color.Empty;
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

        private void comboBoxRestaurateur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
