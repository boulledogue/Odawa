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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //initialisation des datagrids au chargement du Mainform
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateGrids();
        }

        private void PopulateGrids()
        {
            dataGridViewAdministrateurs.DataSource = AdministrateurManager.GetAll();
            dataGridViewAdministrateurs.Columns["nom"].HeaderText = "Nom";
            dataGridViewAdministrateurs.Columns["prenom"].HeaderText = "Prénom";            
            dataGridViewAdministrateurs.Columns["email"].HeaderText = "Email";
            dataGridViewAdministrateurs.Columns["phone"].HeaderText = "Téléphone";
            dataGridViewAdministrateurs.Columns["id"].Visible = false;
            dataGridViewAdministrateurs.Columns["username"].Visible = false;
            dataGridViewAdministrateurs.Columns["password"].Visible = false;

            dataGridViewRestaurateurs.DataSource = RestaurateurManager.GetAll();
            dataGridViewRestaurateurs.Columns["nom"].HeaderText = "Nom";
            dataGridViewRestaurateurs.Columns["prenom"].HeaderText = "Prénom";
            dataGridViewRestaurateurs.Columns["email"].HeaderText = "Email";
            dataGridViewRestaurateurs.Columns["phone"].HeaderText = "Téléphone";
            dataGridViewRestaurateurs.Columns["id"].Visible = false;
            dataGridViewRestaurateurs.Columns["username"].Visible = false;
            dataGridViewRestaurateurs.Columns["password"].Visible = false;

            dataGridViewUtilisateurs.DataSource = UtilisateurManager.GetAll();
            dataGridViewUtilisateurs.Columns["nom"].HeaderText = "Nom";
            dataGridViewUtilisateurs.Columns["prenom"].HeaderText = "Prénom";
            dataGridViewUtilisateurs.Columns["email"].HeaderText = "Email";
            dataGridViewUtilisateurs.Columns["phone"].HeaderText = "Téléphone";
            dataGridViewUtilisateurs.Columns["id"].Visible = false;
            dataGridViewUtilisateurs.Columns["username"].Visible = false;
            dataGridViewUtilisateurs.Columns["password"].Visible = false;

            dataGridViewRestaurants.DataSource = RestaurantManager.GetAll();
            dataGridViewRestaurants.Columns["nom"].HeaderText = "Nom";
            dataGridViewRestaurants.Columns["zipCode"].HeaderText = "Code Postal";
            dataGridViewRestaurants.Columns["localite"].HeaderText = "Localité";
            dataGridViewRestaurants.Columns["premium"].HeaderText = "Premium";
            dataGridViewRestaurants.Columns["genre"].HeaderText = "Genre";
            dataGridViewRestaurants.Columns["idTypeCuisine"].HeaderText = "Type de cuisine";
            dataGridViewRestaurants.Columns["id"].Visible = false;
            dataGridViewRestaurants.Columns["adresse"].Visible = false;
            dataGridViewRestaurants.Columns["numero"].Visible = false;
            dataGridViewRestaurants.Columns["description"].Visible = false;
            dataGridViewRestaurants.Columns["budgetLow"].Visible = false;
            dataGridViewRestaurants.Columns["budgetHigh"].Visible = false;
            dataGridViewRestaurants.Columns["horaire"].Visible = false;
            dataGridViewRestaurants.Columns["genre"].Visible = false;
            dataGridViewRestaurants.Columns["idRestaurateur"].Visible = false;
            dataGridViewRestaurants.Columns["idTypeCuisine"].Visible = false;

            dataGridViewTypesCuisine.DataSource = TypeCuisineManager.GetAll();
            dataGridViewTypesCuisine.Columns["type"].HeaderText = "Type de cuisine";
            dataGridViewTypesCuisine.Columns["id"].Visible = false;
        }

        private void buttonAddAdmin_Click(object sender, EventArgs e)
        {
            FormAdministrateur f = new FormAdministrateur();
            f.ShowDialog();
            PopulateGrids();
        }

        private void buttonModAdmin_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewAdministrateurs.SelectedRows[0].Cells[0].Value;
            Administrateur a = AdministrateurManager.GetAll().Find(x => x.id == id);
            FormAdministrateur f = new FormAdministrateur(a);
            f.ShowDialog();
            PopulateGrids();
        }

        private void buttonDelAdmin_Click(object sender, EventArgs e)
        {
            string message = "Voulez-vous vraiment supprimer cet administrateur?";
            string caption = "Suppression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int id = (int)dataGridViewAdministrateurs.SelectedRows[0].Cells[0].Value;
                AdministrateurManager.Delete(id);
                PopulateGrids();
                message = "Administrateur supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonAddRestaurateur_Click(object sender, EventArgs e)
        {
            FormRestaurateur f = new FormRestaurateur();
            f.ShowDialog();
            PopulateGrids();
        }

        private void buttonModRestaurateur_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRestaurateurs.SelectedRows[0].Cells[0].Value;
            Restaurateur r = RestaurateurManager.GetAll().Find(x => x.id == id);
            FormRestaurateur f = new FormRestaurateur(r);
            f.ShowDialog();
            PopulateGrids();
        }

        private void buttonDelRestaurateur_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRestaurateurs.SelectedRows[0].Cells[0].Value;
            if (RestaurantManager.GetAll().Where(x => x.idRestaurateur == id).Count() == 0)
            {
                string message = "Voulez-vous vraiment supprimer ce restaurateur?";
                string caption = "Suppression";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, icon);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    RestaurateurManager.Delete(id);
                    PopulateGrids();
                    message = "Restaurateur supprimé!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }
            else
            {
                string caption = "Erreur lors de la suppression";
                string message = "Au moins un restaurant est lié à ce restaurateur, impossible de le supprimer.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonModUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelUser_Click(object sender, EventArgs e)
        {
            string message = "Voulez-vous vraiment supprimer cet utilisateur?";
            string caption = "Suppression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int id = (int)dataGridViewUtilisateurs.SelectedRows[0].Cells[0].Value;
                UtilisateurManager.Delete(id);
                PopulateGrids();
                message = "Utilisateur supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonAddResto_Click(object sender, EventArgs e)
        {
            FormRestaurant f = new FormRestaurant();
            f.ShowDialog();
            PopulateGrids();
        }

        private void buttonModResto_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRestaurants.SelectedRows[0].Cells[0].Value;
            Restaurant restaurant = RestaurantManager.GetAll().Find(x => x.id == id);
            FormRestaurant f = new FormRestaurant(restaurant);
            f.ShowDialog();
            PopulateGrids();
        }

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
                int id = (int)dataGridViewRestaurants.SelectedRows[0].Cells[0].Value;
                RestaurantManager.Delete(id);
                PopulateGrids();
                message = "Restaurant supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonAddType_Click(object sender, EventArgs e)
        {
            FormTypeCuisine f = new FormTypeCuisine();
            f.ShowDialog();
            PopulateGrids();
        }

        private void buttonModType_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewTypesCuisine.SelectedRows[0].Cells[0].Value;
            TypeCuisine typeCuisine = TypeCuisineManager.GetAll().Find(x => x.id == id);
            FormTypeCuisine f = new FormTypeCuisine(typeCuisine);
            f.ShowDialog();
            PopulateGrids();
        }

        private void buttonDelType_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewTypesCuisine.SelectedRows[0].Cells[0].Value;
            if (RestaurantManager.GetAll().Where(x => x.idTypeCuisine == id).Count() == 0)
            {
                string message = "Voulez-vous vraiment supprimer ce type de cuisine?";
                string caption = "Suppression";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, icon);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    TypeCuisineManager.Delete(id);
                    PopulateGrids();
                    message = "Type de cuisine supprimé!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }
            else
            {
                string caption = "Erreur lors de la suppression";
                string message = "Au moins un restaurant est lié à ce type de cuisine, impossible de le supprimer.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonViewReservations_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRestaurants.SelectedRows[0].Cells[0].Value;
            FormViewReservation f = new FormViewReservation(id);
            f.ShowDialog();
        }
    }
}
