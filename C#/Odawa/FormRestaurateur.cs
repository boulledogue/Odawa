using BU;
using BU.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odawa
{
    public partial class FormRestaurateur : Form
    {
        public int restaurateurId { get; set; }

        public FormRestaurateur()
        {
            this.restaurateurId = -1;
            InitializeComponent();
        }

        public FormRestaurateur(Restaurateur restaurateur) : this()
        {
            this.restaurateurId = restaurateur.id;
            textBoxNom.DataBindings.Add("Text", restaurateur, "nom");
            textBoxPrenom.DataBindings.Add("Text", restaurateur, "prenom");
            textBoxUsername.DataBindings.Add("Text", restaurateur, "username");
            textBoxPassword.DataBindings.Add("Text", restaurateur, "password");
            textBoxEmail.DataBindings.Add("Text", restaurateur, "email");
            textBoxPhone.DataBindings.Add("Text", restaurateur, "phone");

        }

        private void saveRestaurateur_Click(object sender, EventArgs e)
        {
            Restaurateur restaurateur = new Restaurateur();

            restaurateur.id = this.restaurateurId;
            restaurateur.nom = textBoxNom.Text.ToUpper();
            restaurateur.prenom = textBoxPrenom.Text;
            restaurateur.username = textBoxUsername.Text.ToLower();
            restaurateur.password = textBoxPassword.Text;
            restaurateur.email = textBoxEmail.Text.ToLower();
            restaurateur.phone = textBoxPhone.Text;

            if (Validate(restaurateur))
            {
                if (restaurateurId == -1) RestaurateurManager.Create(restaurateur);
                else RestaurateurManager.Update(restaurateur);
                this.Dispose();
            }
        }

        private bool Validate(Restaurateur a)
        {
            labelNom.ForeColor = Color.Empty;
            labelPrenom.ForeColor = Color.Empty;
            labelUsername.ForeColor = Color.Empty;
            labelPassword.ForeColor = Color.Empty;
            labelEmail.ForeColor = Color.Empty;
            labelPhone.ForeColor = Color.Empty;
            bool valid = true;
            string message = "";
            if (a.nom.Length < 2 || a.nom.Length > 30)
            {
                labelNom.ForeColor = Color.Red;
                valid = false;
                message += "- Nom invalide\n";
            }
            if (a.prenom.Length < 2 || a.prenom.Length > 30)
            {
                labelPrenom.ForeColor = Color.Red;
                valid = false;
                message += "- Prénom invalide\n";
            }
            if (
                (a.username.Length < 3 || a.username.Length > 30) ||
                (RestaurateurManager.GetAll().Find(x => x.username == a.username) != null && a.id == -1)
               )
            {
                labelUsername.ForeColor = Color.Red;
                valid = false;
                message += "- Username invalide ou déjà existant\n";
            }
            if (a.password.Length < 4 || a.password.Length > 30)
            {
                labelPassword.ForeColor = Color.Red;
                valid = false;
                message += "- Password invalide\n";
            }
            if (
                (a.email.Length < 9 || a.email.Length > 30) ||
                (RestaurateurManager.GetAll().Find(x => x.email == a.email) != null && a.id == -1)
               )
            {
                labelEmail.ForeColor = Color.Red;
                valid = false;
                message += "- Email invalide ou déjà existant\n";
            }
            if (a.phone.Length < 9 || a.phone.Length > 10)
            {
                labelPhone.ForeColor = Color.Red;
                valid = false;
                message += "- Numéro de téléphone invalide\n";
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
