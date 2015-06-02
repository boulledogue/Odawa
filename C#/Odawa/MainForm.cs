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
            //Si la connexion à la base de données est possible
            if (CommonManager.CheckDBConnection())
            {
                #region DataGrid Administrateurs

                dataGridViewAdministrateurs.DataSource = AdministrateurManager.GetAll();
                //Renommage des colonnes affichées
                dataGridViewAdministrateurs.Columns["nom"].HeaderText = "Nom";
                dataGridViewAdministrateurs.Columns["prenom"].HeaderText = "Prénom";
                dataGridViewAdministrateurs.Columns["email"].HeaderText = "Email";
                dataGridViewAdministrateurs.Columns["phone"].HeaderText = "Téléphone";
                //Masquage des colonnes inutiles
                dataGridViewAdministrateurs.Columns["id"].Visible = false;
                dataGridViewAdministrateurs.Columns["username"].Visible = false;
                dataGridViewAdministrateurs.Columns["password"].Visible = false;
                //si DataGrid vide, désactivation des boutons Supprimer et Modifier
                if (dataGridViewAdministrateurs.Rows.Count == 0) buttonDelAdmin.Enabled = buttonModAdmin.Enabled = false;
                else buttonDelAdmin.Enabled = buttonModAdmin.Enabled = true;

                #endregion DataGrid Administrateurs

                #region DataGrid Restaurateurs

                //DataGrid Restaurateurs
                dataGridViewRestaurateurs.DataSource = RestaurateurManager.GetAll();
                //Renommage des colonnes affichées
                dataGridViewRestaurateurs.Columns["nom"].HeaderText = "Nom";
                dataGridViewRestaurateurs.Columns["prenom"].HeaderText = "Prénom";
                dataGridViewRestaurateurs.Columns["email"].HeaderText = "Email";
                dataGridViewRestaurateurs.Columns["phone"].HeaderText = "Téléphone";
                //Masquage des colonnes inutiles
                dataGridViewRestaurateurs.Columns["id"].Visible = false;
                dataGridViewRestaurateurs.Columns["username"].Visible = false;
                dataGridViewRestaurateurs.Columns["password"].Visible = false;
                //si DataGrid vide, désactivation des boutons Supprimer, Modifier et Consulter restaurants
                if (dataGridViewRestaurateurs.Rows.Count == 0) buttonDelRestaurateur.Enabled = buttonModRestaurateur.Enabled = buttonViewRestaurants.Enabled = false;
                else buttonDelRestaurateur.Enabled = buttonModRestaurateur.Enabled = buttonViewRestaurants.Enabled = true;

                #endregion DataGrid Restaurateurs

                #region DataGrid Utilisateurs

                //DataGrid Utilisateurs
                dataGridViewUtilisateurs.DataSource = UtilisateurManager.GetAll();
                //Renommage des colonnes affichées
                dataGridViewUtilisateurs.Columns["nom"].HeaderText = "Nom";
                dataGridViewUtilisateurs.Columns["prenom"].HeaderText = "Prénom";
                dataGridViewUtilisateurs.Columns["email"].HeaderText = "Email";
                dataGridViewUtilisateurs.Columns["phone"].HeaderText = "Téléphone";
                //Masquage des colonnes inutiles
                dataGridViewUtilisateurs.Columns["id"].Visible = false;
                dataGridViewUtilisateurs.Columns["username"].Visible = false;
                dataGridViewUtilisateurs.Columns["password"].Visible = false;
                //Fonctions Ajouter et Modifier désactivées car gérées par l'utilisateur sur le site
                //Suppression autorisée
                buttonAddUser.Enabled = buttonModUser.Enabled = false;

                #endregion DataGrid Utilisateurs

                #region DataGrid Restaurants

                //DataGrid Restaurants
                dataGridViewRestaurants.DataSource = RestaurantManager.GetAll();
                //Renommage des colonnes affichées
                dataGridViewRestaurants.Columns["nom"].HeaderText = "Nom";
                dataGridViewRestaurants.Columns["zipCode"].HeaderText = "Code Postal";
                dataGridViewRestaurants.Columns["localite"].HeaderText = "Localité";
                dataGridViewRestaurants.Columns["premium"].HeaderText = "Premium";
                dataGridViewRestaurants.Columns["genre"].HeaderText = "Genre";
                dataGridViewRestaurants.Columns["idTypeCuisine"].HeaderText = "Type de cuisine";
                //Masquage des colonnes inutiles
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
                //Si DataGrid vide, désactivation des boutons Supprimer, Modifier et Consulter réservations
                if (dataGridViewRestaurants.Rows.Count == 0) buttonDelResto.Enabled = buttonModResto.Enabled = buttonViewReservations.Enabled = false;
                else buttonDelResto.Enabled = buttonModResto.Enabled = buttonViewReservations.Enabled = true;

                #endregion DataGrid Restaurants

                #region DataGrid TypeCuisine

                //DataGrid TypeCuisine
                dataGridViewTypesCuisine.DataSource = TypeCuisineManager.GetAll();
                //Renommage des colonnes affichées
                dataGridViewTypesCuisine.Columns["type"].HeaderText = "Type de cuisine";
                dataGridViewTypesCuisine.Columns["description"].HeaderText = "Description";
                //Masquage des colonnes inutiles
                dataGridViewTypesCuisine.Columns["id"].Visible = false;
                //Si DataGrid vide, désactivation des boutons Supprimer et Modifier
                if (dataGridViewTypesCuisine.Rows.Count == 0) buttonDelType.Enabled = buttonModType.Enabled = false;
                else buttonDelType.Enabled = buttonModType.Enabled = true;

                #endregion DataGrid TypeCuisine
            }
            //Sinon
            else
            {
                string message = "Une erreur est survenue lors de la connexion à la base de données, l'application va maintenant se fermer.";
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
                Application.Exit();
            }
        }

        #region Boutons Administrateurs

        //Clic sur Ajouter ou Modifier dans le DataGrid Administrateurs provoque l'affichage d'un nouveau FormAdministrateur
        //Ajouter
        private void buttonAddAdmin_Click(object sender, EventArgs e)
        {            
            //Ouverture du form sans paramètres (textBoxes vides)
            FormAdministrateur f = new FormAdministrateur();
            f.ShowDialog();
            PopulateGrids();
        }

        //Modifier
        private void buttonModAdmin_Click(object sender, EventArgs e)
        {            
            //Obtention de l'id de la ligne sélectionnée
            int id = (int)dataGridViewAdministrateurs.SelectedRows[0].Cells[0].Value;
            //Recherche de l'administrateur sur base de l'id
            Administrateur a = AdministrateurManager.GetAll().Find(x => x.id == id);
            //Ouverture du form avec passage de l'administrateur sélectionné (textBoxes préremplies)
            if (a != null)
            {
                FormAdministrateur f = new FormAdministrateur(a);
                f.ShowDialog();
                PopulateGrids();
            }
        }

        //Clic sur Supprimer dans le Datagrid Administrateurs
        private void buttonDelAdmin_Click(object sender, EventArgs e)
        {
            //Affichage d'une demande de confirmation
            string message = "Voulez-vous vraiment supprimer cet administrateur?";
            string caption = "Suppression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            //Si oui
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Obtention de l'id de la ligne sélectionnée
                int id = (int)dataGridViewAdministrateurs.SelectedRows[0].Cells[0].Value;
                //Envoi à la couche BU qui retourne un booléen (true: suppression ok, false: erreur lors de la suppression)
                if (AdministrateurManager.Delete(id))
                {                    
                    message = "Administrateur supprimé!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                }
                else
                {
                    message = "Erreur lors de la suppression!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Error;
                }                
                //Message de résultat                
                MessageBox.Show(message, caption, buttons, icon);
                //Rafraichissement des grids
                PopulateGrids();
            }
        }

        #endregion Boutons Administrateurs

        #region Boutons Restaurateurs

        //Clic sur Consulter restaurants dans le DataGrid Restaurateurs provoque l'affichage de FormViewRestaurant
        //qui contient la liste des restaurants du restaurateur sélectionné
        private void buttonViewRestaurants_Click(object sender, EventArgs e)
        {
            //Obtention de l'id de la ligne sélectionnée
            int id = (int)dataGridViewRestaurateurs.SelectedRows[0].Cells[0].Value;
            //Ouverture du form avec passage de l'id du restaurateur sélectionné
            if (id > 0)
            {
                FormViewRestaurant f = new FormViewRestaurant(id);
                f.ShowDialog();
                PopulateGrids();
            }
        }

        //Clic sur Ajouter ou Modifier dans le DataGrid Restaurateurs provoque l'affichage d'un nouveau FormRestaurateur
        //Ajouter
        private void buttonAddRestaurateur_Click(object sender, EventArgs e)
        {            
            //Ouverture du form sans paramètres (textBoxes vides)
            FormRestaurateur f = new FormRestaurateur();
            f.ShowDialog();
            PopulateGrids();
        }

        //Modifier
        private void buttonModRestaurateur_Click(object sender, EventArgs e)
        {
            //Obtention de l'id de la ligne sélectionnée
            int id = (int)dataGridViewRestaurateurs.SelectedRows[0].Cells[0].Value;
            //Recherche du restaurateur sur base de l'id
            Restaurateur r = RestaurateurManager.GetAll().Find(x => x.id == id);
            //Ouverture du form avec passage du restaurateur sélectionné (textBoxes préremplies)
            if (r != null)
            {
                FormRestaurateur f = new FormRestaurateur(r);
                f.ShowDialog();
                PopulateGrids();
            }
        }

        //Clic sur Supprimer dans le Datagrid Restaurateurs
        private void buttonDelRestaurateur_Click(object sender, EventArgs e)
        {
            //Obtention de l'id de la ligne sélectionnée
            int id = (int)dataGridViewRestaurateurs.SelectedRows[0].Cells[0].Value;
            string caption = "Suppression";
            //Si la somme des restaurants dont le restaurateur est celui qu'on veut supprimer = 0 
            if (RestaurantManager.GetAll().Where(x => x.idRestaurateur == id).Count() == 0)
            {
                //Demande de confirmation
                string message = "Voulez-vous vraiment supprimer ce restaurateur?";                
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, icon);
                //Si oui
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Envoi à la couche BU qui retourne un booléen (true: suppression ok, false: erreur lors de la suppression)
                    if (RestaurateurManager.Delete(id))
                    {                        
                        message = "Restaurateur supprimé!";
                        buttons = MessageBoxButtons.OK;
                        icon = MessageBoxIcon.Information;
                    }
                    else
                    {
                        message = "Erreur lors de la suppression!";
                        buttons = MessageBoxButtons.OK;
                        icon = MessageBoxIcon.Error;
                    }
                    MessageBox.Show(message, caption, buttons, icon);
                    PopulateGrids();
                }
            }
            //Sinon, avertissement: on ne peut pas supprimer un restaurateur qui gère au moins un restaurant
            else
            {
                string message = "Au moins un restaurant est lié à ce restaurateur, impossible de le supprimer.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        #endregion Boutons Restaurateurs

        #region Boutons Utilisateurs

        //Clic sur Supprimer dans le Datagrid Utilisateurs
        private void buttonDelUser_Click(object sender, EventArgs e)
        {
            string message = "Voulez-vous vraiment supprimer cet utilisateur?";
            string caption = "Suppression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            //Si oui
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int id = (int)dataGridViewUtilisateurs.SelectedRows[0].Cells[0].Value;
                //Si suppression ok
                if (UtilisateurManager.Delete(id))
                {                    
                    message = "Utilisateur supprimé!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                }
                //Si erreur de suppression
                else
                {
                    message = "Erreur lors de la suppression!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Error;
                }
                MessageBox.Show(message, caption, buttons, icon);
                PopulateGrids();
            }
        }

        #endregion Boutons Utilisateurs

        #region Boutons Restaurants

        //Clic sur Consulter reservations dans le DataGrid Restaurants provoque l'affichage de FormViewReservation
        //qui contient la liste des reservations du restaurant sélectionné
        private void buttonViewReservations_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRestaurants.SelectedRows[0].Cells[0].Value;
            if (id > 0)
            {
                FormViewReservation f = new FormViewReservation(id);
                f.ShowDialog();
                PopulateGrids();
            }
        }

        //Ajouter restaurant
        private void buttonAddResto_Click(object sender, EventArgs e)
        {
            FormRestaurant f = new FormRestaurant();
            f.ShowDialog();
            PopulateGrids();
        }

        //Modifier restaurant
        private void buttonModResto_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRestaurants.SelectedRows[0].Cells[0].Value;
            if (id > 0)
            {
                Restaurant restaurant = RestaurantManager.GetAll().Find(x => x.id == id);
                FormRestaurant f = new FormRestaurant(restaurant);
                f.ShowDialog();
                PopulateGrids();
            }
        }

        //Supprimer restaurant
        private void buttonDelResto_Click(object sender, EventArgs e)
        {
            string message = "Voulez-vous vraiment supprimer ce restaurant?";
            string caption = "Suppression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);
            //Si oui
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int id = (int)dataGridViewRestaurants.SelectedRows[0].Cells[0].Value;
                if (RestaurantManager.Delete(id))
                {
                    message = "Restaurant supprimé!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                }
                else
                {
                    message = "Erreur lors de la suppression!";
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Error;
                }
                MessageBox.Show(message, caption, buttons, icon);
                PopulateGrids();
            }
        }

        #endregion Boutons Restaurants

        #region Boutons Types Cuisine

        //Ajouter Type de Cuisine
        private void buttonAddType_Click(object sender, EventArgs e)
        {
            FormTypeCuisine f = new FormTypeCuisine();
            f.ShowDialog();
            PopulateGrids();
        }

        //Modifier Type de Cuisine
        private void buttonModType_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewTypesCuisine.SelectedRows[0].Cells[0].Value;
            TypeCuisine typeCuisine = TypeCuisineManager.GetAll().Find(x => x.id == id);
            if (id > 0)
            {
                FormTypeCuisine f = new FormTypeCuisine(typeCuisine);
                f.ShowDialog();
                PopulateGrids();
            }
        }

        //Supprimer Type de Cuisine
        private void buttonDelType_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewTypesCuisine.SelectedRows[0].Cells[0].Value;
            //Si aucun restaurant n'est du type à supprimer
            if (RestaurantManager.GetAll().Where(x => x.idTypeCuisine == id).Count() == 0)
            {
                //Demande de confirmation
                string message = "Voulez-vous vraiment supprimer ce type de cuisine?";
                string caption = "Suppression";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons, icon);
                //Si oui
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Si suppression ok
                    if (TypeCuisineManager.Delete(id))
                    {                        
                        message = "Type de cuisine supprimé!";
                        buttons = MessageBoxButtons.OK;
                        icon = MessageBoxIcon.Information;
                    }
                    //Sinon
                    else
                    {
                        message = "Erreur lors de la suppression!";
                        buttons = MessageBoxButtons.OK;
                        icon = MessageBoxIcon.Error;
                    }
                    MessageBox.Show(message, caption, buttons, icon);
                    PopulateGrids();
                }
            }
            //Sinon, avertissement: on ne peut pas supprimer un type de cuisine lié à au moins un restaurant.
            else
            {
                string caption = "Erreur lors de la suppression";
                string message = "Au moins un restaurant est lié à ce type de cuisine, impossible de le supprimer.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        #endregion Boutons Types Cuisine
    }
}
