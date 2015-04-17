using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Odawa.BU;

namespace Odawa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAL.DatabaseConnection.FillDataSet();      

            dataGridViewAdministrateurs.DataSource = AdministrateurManager.GetAll();
            dataGridViewAdministrateurs.Columns["username"].Visible = false;
            dataGridViewAdministrateurs.Columns["password"].Visible = false;
            dataGridViewAdministrateurs.Columns["email"].Visible = false;
            dataGridViewAdministrateurs.Columns["phone"].Visible = false;

            dataGridViewRestaurateurs.DataSource = RestaurateurManager.GetAll();
            dataGridViewRestaurateurs.Columns["username"].Visible = false;
            dataGridViewRestaurateurs.Columns["password"].Visible = false;
            dataGridViewRestaurateurs.Columns["email"].Visible = false;
            dataGridViewRestaurateurs.Columns["phone"].Visible = false;

            dataGridViewUtilisateurs.DataSource = UtilisateurManager.GetAll();
            dataGridViewUtilisateurs.Columns["username"].Visible = false;
            dataGridViewUtilisateurs.Columns["password"].Visible = false;
            dataGridViewUtilisateurs.Columns["email"].Visible = false;
            dataGridViewUtilisateurs.Columns["phone"].Visible = false;

            dataGridViewRestaurants.DataSource = RestaurantManager.GetAll();
            dataGridViewRestaurants.Columns["adresse"].Visible = false;
            dataGridViewRestaurants.Columns["numero"].Visible = false;
            dataGridViewRestaurants.Columns["description"].Visible = false;
            dataGridViewRestaurants.Columns["horaire"].Visible = false;
            dataGridViewRestaurants.Columns["budget"].Visible = false;
            dataGridViewRestaurants.Columns["idTypeCuisine"].Visible = false;
            dataGridViewRestaurants.Columns["idRestaurateur"].Visible = false;

            dataGridViewTypesCuisine.DataSource = TypeCuisineManager.GetAll();
        }
    }
}
