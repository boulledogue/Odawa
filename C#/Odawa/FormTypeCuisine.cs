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
    public partial class FormTypeCuisine : Form
    {
        //Propriété du form, garde l'id du typeCuisine édité en mémoire
        private int typeCuisineId { get; set; }

        //constructeur du form sans paramètre (Ajout typeCuisine)
        public FormTypeCuisine()
        {
            //Initialisation de l'id à -1, textBoxes vides
            this.typeCuisineId = -1;
            InitializeComponent();
        }

        //constructeur du form avec paramètre (Modification typeCuisine), hérite du constructeur par défaut
        public FormTypeCuisine(TypeCuisine typeCuisine) : this()
        {
            //Initialisation de l'id et des textBoxes avec les valeurs transmises
            this.typeCuisineId = typeCuisine.id;
            textBoxTypeCuisine.DataBindings.Add("Text", typeCuisine, "type");
            richTextBoxDescType.DataBindings.Add("Text", typeCuisine, "description");            
        }

        //Bouton sauver
        private void buttonTypeCuisine_Click(object sender, EventArgs e)
        {
            //Création d'un objet TypeCuisine avec l'id à -1 (création) ou >0 (passé en paramètre)
            //Les autres propriétés viennent des textBoxes
            TypeCuisine t = new TypeCuisine();
            t.id = this.typeCuisineId;
            t.type = textBoxTypeCuisine.Text;
            //si pas de description, remplissage avec un texte prédéfini
            if (richTextBoxDescType.Text.Length == 0) t.description = "Aucune description pour ce type de cuisine.";
            else t.description = richTextBoxDescType.Text;
            //Si Validate renvoie true, l'objet est valide et peut être transmis à la BU pour traitement
            if(Validate(t))
            {
                //Si id = -1 alors c'est une création, envoi à la BU (TypeCuisineManager.Create)
                if (typeCuisineId == -1) TypeCuisineManager.Create(t);
                //Sinon c'est une modification, envoi à la BU (TypeCuisineManager.Update)
                else TypeCuisineManager.Update(t);
                //Fermeture du form
                this.Dispose();
            }
        }

        private bool Validate(TypeCuisine t)
        {
            //Initialisation de la couleur des labels à "par défaut"
            labelTypeCuisine.ForeColor = Color.Empty;
            labelDescriptionType.ForeColor = Color.Empty;
            bool valid = true;
            string message = "";
            //Si le nom du type fait moins de 3
            if(t.type.Length < 3)
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Le nom du type doit au moins faire 3 caractères.\n";
            }
            //Si le nom du type contient autre chose que des caractères et des espaces
            if(!Regex.IsMatch(t.type, @"^[a-zA-Z ]+$"))
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Le nom du type ne doit contenir que des caractères alphabétiques.\n";
            }
            //Si le nom du type existe déjà
            if(TypeCuisineManager.GetAll().Find(x => x.type == t.type) != null)
            {
                //Si c'est un ajout OU que l'id du type modifié est différent de l'id du type existant
                if ((this.typeCuisineId == -1) || (this.typeCuisineId != TypeCuisineManager.GetAll().Find(x => x.type == t.type).id))
                {
                    labelTypeCuisine.ForeColor = Color.Red;
                    valid = false;
                    message += "Le type existe déjà.\n";
                } 
            }
            //Si la description fait moins de 10 (préremplie si vide)
            if (t.description.Length < 10)
            {
                labelDescriptionType.ForeColor = Color.Red;
                valid = false;
                message += "La description doit être vide ou faire au moins 10 caractères.\n";
            }
            //Si le TypeCuisine envoyé par le form est invalide
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

        //Bouton Annuler
        private void buttonCancelTypeCuisine_Click(object sender, EventArgs e)
        {
            //Fermeture du form
            this.Dispose();
        }
    }
}
