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
    public partial class FormAjoutAdministrateur : Form
    {

        private int administrateurId { get; set; }

        public FormAjoutAdministrateur()
        {
            this.administrateurId = -1;
            InitializeComponent();
        }

        public FormAjoutAdministrateur(Administrateur a) : this()
        {
            this.administrateurId = a.id;
            textBoxNom.DataBindings.Add("Text", a, "nom");
            textBoxPrenom.DataBindings.Add("Text", a, "prenom");
            textBoxUsername.DataBindings.Add("Text", a, "username");
            textBoxPassword.DataBindings.Add("Text", a, "password");
            textBoxEmail.DataBindings.Add("Text", a, "email");
            textBoxPhone.DataBindings.Add("Text", a, "phone");
        }

        private void saveAdministrateur_Click(object sender, EventArgs e)
        {
            Administrateur administrateur = new Administrateur();
            administrateur.id = this.administrateurId;
            administrateur.nom = textBoxNom.Text.ToUpper();
            administrateur.prenom = textBoxPrenom.Text;
            administrateur.username = textBoxUsername.Text.ToLower();
            administrateur.password = textBoxPassword.Text;
            administrateur.email = textBoxEmail.Text.ToLower();
            administrateur.phone = textBoxPhone.Text;
            if (Validate(administrateur))
            {
                if (administrateurId == -1) AdministrateurManager.Create(administrateur);
                else AdministrateurManager.Update(administrateur);
                this.Dispose();
            }
        }

        private bool Validate(Administrateur a)
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
                (AdministrateurManager.GetAll().Find(x => x.username == a.username) != null && a.id == -1)
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
                (AdministrateurManager.GetAll().Find(x => x.email == a.email) != null && a.id == -1) 
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

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
