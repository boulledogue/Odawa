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
        private int idRestaurateur { get; set; }
        public FormViewRestaurant(int id)
        {
            this.idRestaurateur = id;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormViewRestaurant_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void Populate()
        {
            Restaurateur r = RestaurateurManager.GetAll().Find(x => x.id == this.idRestaurateur);
            labelRestaurateur.Text = r.nom + " " + r.prenom;
            dataGridViewRestOwned.DataSource = RestaurantManager.GetAll().Where(x => x.idRestaurateur == this.idRestaurateur).ToList();
            /*dataGridViewRestOwned.Columns["nom"].HeaderText = "Nom";*/
            dataGridViewRestOwned.Columns["zipCode"].HeaderText = "Code Postal";
            dataGridViewRestOwned.Columns["localite"].HeaderText = "Localité";
            dataGridViewRestOwned.Columns["premium"].HeaderText = "Premium";
            dataGridViewRestOwned.Columns["genre"].HeaderText = "Genre";
            dataGridViewRestOwned.Columns["idTypeCuisine"].HeaderText = "Type de cuisine";
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
                int id = (int)dataGridViewRestOwned.SelectedRows[0].Cells[0].Value;
                RestaurantManager.Delete(id);
                Populate();
                message = "Restaurant supprimé!";
                buttons = MessageBoxButtons.OK;
                icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }
    }
}
