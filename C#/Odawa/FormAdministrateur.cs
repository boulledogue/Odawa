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
    public partial class FormAdministrateur : Form
    {
        //Propriété du form, garde l'id de l'administrateur édité en mémoire
        private int administrateurId { get; set; }

        //constructeur du form sans paramètre (Ajout administrateur)
        public FormAdministrateur()
        {
            //Initialisation de l'id à -1, textBoxes vides
            this.administrateurId = -1;
            InitializeComponent();
        }

        //constructeur du form avec paramètre (Modification administrateur), hérite du constructeur par défaut
        public FormAdministrateur(Administrateur a) : this()
        {
            //Initialisation de l'id et des textBoxes avec les valeurs transmises 
            this.administrateurId = a.id;
            textBoxNom.DataBindings.Add("Text", a, "nom");
            textBoxPrenom.DataBindings.Add("Text", a, "prenom");
            textBoxUsername.DataBindings.Add("Text", a, "username");
            textBoxPassword.DataBindings.Add("Text", a, "password");
            textBoxEmail.DataBindings.Add("Text", a, "email");
            textBoxPhone.DataBindings.Add("Text", a, "phone");
        }

        //Bouton sauver
        private void saveAdministrateur_Click(object sender, EventArgs e)
        {
            //Création d'un objet Administrateur avec l'id à -1 (création) ou >0 (passé en paramètre)
            //Les autres propriétés viennent des textBoxes
            Administrateur administrateur = new Administrateur();
            administrateur.id = this.administrateurId;
            administrateur.nom = textBoxNom.Text.ToUpper();
            administrateur.prenom = textBoxPrenom.Text;
            administrateur.username = textBoxUsername.Text.ToLower();
            administrateur.password = textBoxPassword.Text;
            administrateur.email = textBoxEmail.Text.ToLower();
            administrateur.phone = textBoxPhone.Text;
            //Si Validate renvoie true, l'objet est valide et peut être transmis à la BU pour traitement
            if (Validate(administrateur))
            {
                //Si id = -1 alors c'est une création, envoi à la BU (AdministrateurManager.Create)
                if (administrateurId == -1) AdministrateurManager.Create(administrateur);
                //Sinon c'est une modification, envoi à la BU (AdministrateurManager.Update)
                else AdministrateurManager.Update(administrateur);
                //Fermeture du form
                this.Dispose();
            }
        }

        private bool Validate(Administrateur a)
        {
            //Expression régulière pour nom et prénom: caractères maj-min + (- espace '), longueur entre 2 et 30
            var nomRegex = new Regex(@"^[-'a-zA-Z ]{2,30}$");
            //Expression régulière pour nom d'utilisateur: caractères maj-min uniquement, longueur entre 3 et 30
            var usernameRegex = new Regex(@"^[a-zA-Z]{3,30}$");
            //Expression régulière pour email: "caractère(s) et/ou tiret(s) et point(s) + @ + caractère(s) et/ou tiret(s) + point + 2-3 caractères
            var emailRegex = new Regex(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$");
            //Expression régulière pour numéro de téléphone: commence par 0 + [1-9] + [0-9] * 7 ou 8 (fixe ou mobile) 
            var phoneRegex = new Regex(@"^0[1-9][0-9]{7,8}$");
            //Initialisation de la couleur des labels à "par défaut"
            labelNom.ForeColor = Color.Empty;
            labelPrenom.ForeColor = Color.Empty;
            labelUsername.ForeColor = Color.Empty;
            labelPassword.ForeColor = Color.Empty;
            labelEmail.ForeColor = Color.Empty;
            labelPhone.ForeColor = Color.Empty;
            //Initialisation de la validité à "vrai"
            bool valid = true;
            //Initialisation du message d'erreur
            string message = "";
            //Si le nom ne correspond pas à l'expression régulière nomRegex
            if (!nomRegex.IsMatch(a.nom))
            {
                labelNom.ForeColor = Color.Red;                
                valid = false;
                message += "- Nom invalide\n";
            }
            //Si le prénom ne correspond pas à l'expression régulière nomRegex
            if (!nomRegex.IsMatch(a.prenom))
            {
                labelPrenom.ForeColor = Color.Red;
                valid = false;
                message += "- Prénom invalide\n";
            }
            //Si le nom d'utilisateur ne correspond pas à l'expression régulière usernameRegex
            if (!usernameRegex.IsMatch(a.username))
            {
                labelUsername.ForeColor = Color.Red;
                valid = false;
                message += "- Nom d'utilisateur invalide\n";
            }
            //Si le nom d'utilisateur existe déjà et que c'est une création
            if (AdministrateurManager.GetAll().Find(x => x.username == a.username) != null && a.id == -1)
            {
                labelUsername.ForeColor = Color.Red;
                valid = false;
                message += "- Nom d'utilisateur déjà existant\n";
            }
            //Si le mot de passe est plus court que 4 ou plus long que 30
            if (a.password.Length < 4 || a.password.Length > 30)
            {
                labelPassword.ForeColor = Color.Red;
                valid = false;
                message += "- Mot de passe invalide\n";
            }
            //Si l'email ne correspond pas à l'expression régulière usernameRegex
            if (!emailRegex.IsMatch(a.email))
            {
                labelEmail.ForeColor = Color.Red;
                valid = false;
                message += "- Email invalide\n";
            }
            //Si l'email existe déjà et que c'est une création
            if (AdministrateurManager.GetAll().Find(x => x.email == a.email) != null && a.id == -1)
            {
                labelEmail.ForeColor = Color.Red;
                valid = false;
                message += "- Email déjà existant\n";
            }
            //Si le numéro de téléphone ne correspond pas à l'expression régulière phoneRegex
            if (!phoneRegex.IsMatch(a.phone))
            {
                labelPhone.ForeColor = Color.Red;
                valid = false;
                message += "- Numéro de téléphone invalide\n";
            }
            //Si l'administrateur envoyé par le form est invalide
            if (!valid)
            {
                //Affichage du message d'erreur
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
            //retourne valid
            return valid;
        }

        //Bouton annuler
        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            //Fermeture du form
            this.Dispose();
        }
    }
}
