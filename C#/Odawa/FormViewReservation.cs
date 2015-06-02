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
        //Propriété du form, garde l'id du restaurant sélectionné en mémoire
        private int idRestaurant { get; set; }

        //constructeur du form avec paramètre (int -> idrestaurant)
        public FormViewReservation(int id)
        {
            this.idRestaurant = id;
            InitializeComponent();
        }

        //Bouton Fermer
        private void buttonClose_Click(object sender, EventArgs e)
        {
            //Fermeture du form
            this.Dispose();
        }

        //Initialisation du grid au chargement du form
        private void FormViewReservation_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void Populate()
        {
            //Récupération du restaurant sur base de l'id
            Restaurant r = RestaurantManager.GetAll().Find(x => x.id == this.idRestaurant);
            //Binding du label avec le nom du restaurant
            Binding myBinding = new Binding("Text", r, "nom");
            labelRestaurant.DataBindings.Add(myBinding);
            //Sélectionne le radioButton 'All'
            radioButtonAll.Checked = true;
            //Masquage des colonnes inutiles
            dataGridViewReservations.Columns["id"].Visible = false;
            dataGridViewReservations.Columns["idRestaurant"].Visible = false;
            dataGridViewReservations.Columns["typeService"].Visible = false;
            //Renommage des colonnes affichées
            dataGridViewReservations.Columns["nom"].HeaderText = "Nom";
            dataGridViewReservations.Columns["prenom"].HeaderText = "Prénom";
            dataGridViewReservations.Columns["date"].HeaderText = "Date";
            dataGridViewReservations.Columns["nbPersonnes"].HeaderText = "Nb de personnes";
            dataGridViewReservations.Columns["email"].HeaderText = "Email";
            dataGridViewReservations.Columns["phone"].HeaderText = "Téléphone";
            dataGridViewReservations.Columns["status"].HeaderText = "Status";
            dataGridViewReservations.Columns["encodedDateTime"].HeaderText = "Encodé le";
        }

        //Handler qui gère le radioButton 'All' (Activé au chargement)
        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            //Remplit le grid avec toutes les réservations pour ce restaurant triées par date
            dataGridViewReservations.DataSource = ReservationManager.GetAll().Where(x => x.idRestaurant == this.idRestaurant).OrderBy(x => x.date).ToList();
        }

        //Handler qui gère le radioButton 'Midi'
        private void radioButtonMidi_CheckedChanged(object sender, EventArgs e)
        {
            //Remplit le grid avec les réservations du midi pour ce restaurant triées par date
            dataGridViewReservations.DataSource = ReservationManager.GetAll().Where(x => x.idRestaurant == this.idRestaurant).Where(x => x.typeService == false).OrderBy(x => x.date).ToList();
        }

        //Handler qui gère le radioButton 'Soir'
        private void radioButtonSoir_CheckedChanged(object sender, EventArgs e)
        {
            //Remplit le grid avec les réservations du soir pour ce restaurant triées par date
            dataGridViewReservations.DataSource = ReservationManager.GetAll().Where(x => x.idRestaurant == this.idRestaurant).Where(x => x.typeService == true).OrderBy(x => x.date).ToList();
        }
    }
}
