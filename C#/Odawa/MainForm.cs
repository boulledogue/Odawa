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
            dataGridViewAdministrateurs.Columns["username"].Visible = false;
            dataGridViewAdministrateurs.Columns["password"].Visible = false;
            dataGridViewAdministrateurs.Columns["email"].Visible = false;

            dataGridViewRestaurateurs.DataSource = RestaurateurManager.GetAll();
            dataGridViewRestaurateurs.Columns["username"].Visible = false;
            dataGridViewRestaurateurs.Columns["password"].Visible = false;
            dataGridViewRestaurateurs.Columns["email"].Visible = false;

            dataGridViewUtilisateurs.DataSource = UtilisateurManager.GetAll();
            dataGridViewUtilisateurs.Columns["username"].Visible = false;
            dataGridViewUtilisateurs.Columns["password"].Visible = false;
            dataGridViewUtilisateurs.Columns["email"].Visible = false;

            dataGridViewRestaurants.DataSource = RestaurantManager.GetAll();
            dataGridViewRestaurants.Columns["adresse"].Visible = false;
            dataGridViewRestaurants.Columns["numero"].Visible = false;
            dataGridViewRestaurants.Columns["description"].Visible = false;
            dataGridViewRestaurants.Columns["budgetLow"].Visible = false;
            dataGridViewRestaurants.Columns["budgetHigh"].Visible = false;
            dataGridViewRestaurants.Columns["idTypeCuisine"].Visible = false;
            dataGridViewRestaurants.Columns["idRestaurateur"].Visible = false;
            dataGridViewRestaurants.Columns["idHoraire"].Visible = false;

            dataGridViewTypesCuisine.DataSource = TypeCuisineManager.GetAll();
        }

        private void buttonAddAdmin_Click(object sender, EventArgs e)
        {

        }

        private void buttonModAdmin_Click(object sender, EventArgs e)
        {

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
                dataGridViewTypesCuisine.DataSource = typeof(List<TypeCuisine>);
                PopulateGrids();
                message = "Administrateur supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonAddRestaurateur_Click(object sender, EventArgs e)
        {

        }

        private void buttonModRestaurateur_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelRestaurateur_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRestaurateurs.SelectedRows[0].Cells[0].Value;
            if (BU.RestaurantManager.GetAll().Where(x => x.idRestaurateur == id).Count() == 0)
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
                    dataGridViewTypesCuisine.DataSource = typeof(List<TypeCuisine>);
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
                dataGridViewTypesCuisine.DataSource = typeof(List<TypeCuisine>);
                PopulateGrids();
                message = "Utilisateur supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonAddResto_Click(object sender, EventArgs e)
        {
            Restaurant r = new Restaurant();
            r.nom = "toto";
            r.adresse = "zhsz";
            r.numero = "123";
            r.zipCode = "5000";
            r.localite = "zehzhz";
            r.description = "";
            r.budgetLow = 0;
            r.budgetHigh = 0;
            r.premium = true;
            r.idHoraire = 1;
            r.idRestaurateur = 1;
            r.idTypeCuisine = 1;
            RestaurantManager.Create(r);
            dataGridViewTypesCuisine.DataSource = typeof(List<TypeCuisine>);
            PopulateGrids();
        }

        private void buttonModResto_Click(object sender, EventArgs e)
        {

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
                dataGridViewTypesCuisine.DataSource = typeof(List<TypeCuisine>);
                PopulateGrids();
                message = "Restaurant supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void buttonAddType_Click(object sender, EventArgs e)
        {
            FormAjoutTypeCuisine f = new FormAjoutTypeCuisine();
            f.ShowDialog();
        }

        private void buttonModType_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewTypesCuisine.SelectedRows[0].Cells[0].Value;
            FormAjoutTypeCuisine f = new FormAjoutTypeCuisine(id);
            f.ShowDialog();
        }

        private void buttonDelType_Click(object sender, EventArgs e)
        {
            string message = "Voulez-vous vraiment supprimer ce type de cuisine?";
            string caption = "Suppression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int id = (int)dataGridViewTypesCuisine.SelectedRows[0].Cells[0].Value;
                TypeCuisineManager.Delete(id);
                dataGridViewTypesCuisine.DataSource = typeof(List<TypeCuisine>);
                PopulateGrids();
                message = "Type de cuisine supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }
    }
}
