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
    public partial class FormViewReservation : Form
    {
        private int idRestaurant { get; set; }
        public FormViewReservation(int id)
        {
            this.idRestaurant = id;
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormViewReservation_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void Populate()
        {
            Restaurant r = RestaurantManager.GetAll().Find(x => x.id == this.idRestaurant);
            Binding myBinding = new Binding("Text", r, "nom");
            labelRestaurant.DataBindings.Add(myBinding);
            radioButtonAll.Checked = true;
            dataGridViewReservations.Columns["id"].Visible = false;
            dataGridViewReservations.Columns["idRestaurant"].Visible = false;
            dataGridViewReservations.Columns["typeService"].Visible = false;
            dataGridViewReservations.Columns["nom"].HeaderText = "Nom";
            dataGridViewReservations.Columns["prenom"].HeaderText = "Prénom";
            dataGridViewReservations.Columns["date"].HeaderText = "Date";
            dataGridViewReservations.Columns["nbPersonnes"].HeaderText = "Nb de personnes";
            dataGridViewReservations.Columns["email"].HeaderText = "Email";
            dataGridViewReservations.Columns["phone"].HeaderText = "Téléphone";
            dataGridViewReservations.Columns["status"].HeaderText = "Status";
            dataGridViewReservations.Columns["encodedDateTime"].HeaderText = "Encodé le";
        }

        private void radioButtonMidi_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewReservations.DataSource = ReservationManager.GetAll().Where(x => x.idRestaurant == this.idRestaurant).Where(x => x.typeService == false).ToList();
        }

        private void radioButtonSoir_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewReservations.DataSource = ReservationManager.GetAll().Where(x => x.idRestaurant == this.idRestaurant).Where(x => x.typeService == true).ToList();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewReservations.DataSource = ReservationManager.GetAll().Where(x => x.idRestaurant == this.idRestaurant).ToList();
        }
    }
}
