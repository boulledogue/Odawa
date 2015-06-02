using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BU;
using BU.Entities;

namespace Odawa
{
    public partial class FormViewRestaurant : Form
    {
        //Propriété du form, garde l'id du restaurateur sélectionné en mémoire
        private int idRestaurateur { get; set; }

        //constructeur du form avec paramètre (int -> idrestaurateur)
        public FormViewRestaurant(int id)
        {
            this.idRestaurateur = id;
            InitializeComponent();
        }

        //Bouton Fermer
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //Fermeture du form
            this.Dispose();
        }

        //Initialisation du grid au chargement du form
        private void FormViewRestaurant_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void Populate()
        {
            //Récupération du restaurateur sur base de l'id
            Restaurateur r = RestaurateurManager.GetAll().Find(x => x.id == this.idRestaurateur);
            //Construction de la chaine nom + prénom
            labelRestaurateur.Text = r.nom + " " + r.prenom;
            //Récupération de la liste des restaurants pour ce restaurateur et liaison au grid
            dataGridViewRestOwned.DataSource = RestaurantManager.GetAll().Where(x => x.idRestaurateur == this.idRestaurateur).ToList();        
            //Masquage des colonnes inutiles
            dataGridViewRestOwned.Columns["id"].Visible = false;
            dataGridViewRestOwned.Columns["adresse"].Visible = false;
            dataGridViewRestOwned.Columns["numero"].Visible = false;
            dataGridViewRestOwned.Columns["description"].Visible = false;
            dataGridViewRestOwned.Columns["budgetLow"].Visible = false;
            dataGridViewRestOwned.Columns["budgetHigh"].Visible = false;
            dataGridViewRestOwned.Columns["horaire"].Visible = false;
            dataGridViewRestOwned.Columns["genre"].Visible = false;
            dataGridViewRestOwned.Columns["idRestaurateur"].Visible = false;
            dataGridViewRestOwned.Columns["idTypeCuisine"].Visible = false;
            //Si la liste des restaurants est vide, désactivation des boutons supprimer et modifier restaurant
            if (dataGridViewRestOwned.Rows.Count == 0) buttonDelResto.Enabled = buttonModResto.Enabled = false;
            else buttonDelResto.Enabled = buttonModResto.Enabled = true;
            //renommage des colonnes affichées
            dataGridViewRestOwned.Columns["nom"].HeaderText = "Nom";
            dataGridViewRestOwned.Columns["zipCode"].HeaderText = "Code Postal";
            dataGridViewRestOwned.Columns["localite"].HeaderText = "Localité";
            dataGridViewRestOwned.Columns["premium"].HeaderText = "Premium";
            dataGridViewRestOwned.Columns["genre"].HeaderText = "Genre";
            dataGridViewRestOwned.Columns["idTypeCuisine"].HeaderText = "Type de cuisine";
        }

        //Bouton supprimer restaurant
        private void buttonDelResto_Click(object sender, EventArgs e)
        {
            string message = "Voulez-vous vraiment supprimer ce restaurant?";
            string caption = "Suppression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //récupération de l'id du restaurant sélectionné
                int id = (int)dataGridViewRestOwned.SelectedRows[0].Cells[0].Value;
                //si suppression ok
                if (RestaurantManager.Delete(id))
                {
                    message = "Restaurant supprimé!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                }
                //si erreur
                else
                {
                    message = "Erreur lors de la suppression!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Error;
                }
                //affichage du message
                MessageBox.Show(message, caption, buttons, icon);
                Populate();
            }
        }

        //Bouton ajouter restaurant
        private void buttonAddResto_Click(object sender, EventArgs e)
        {
            //Affichage du form d'ajout en passant l'id du restaurateur en paramètre
            FormRestaurant f = new FormRestaurant(idRestaurateur);
            f.ShowDialog();
            Populate();
        }

        //Bouton modifier restaurant
        private void buttonModResto_Click(object sender, EventArgs e)
        {
            //récupération du restaurant
            Restaurant r = RestaurantManager.GetAll().Find(x => x.id == (int)dataGridViewRestOwned.SelectedRows[0].Cells[0].Value);
            if (r != null)
            {
                FormRestaurant f = new FormRestaurant(r);
                f.ShowDialog();
                Populate();
            }
        }
    }
}
