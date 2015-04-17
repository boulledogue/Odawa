﻿using System;
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
            dataGridViewRestaurateurs.DataSource = RestaurateurManager.GetAll();
            dataGridViewUtilisateurs.DataSource = UtilisateurManager.GetAll();
            dataGridViewRestaurants.DataSource = RestaurantManager.GetAll();
            dataGridViewTypesCuisine.DataSource = TypeCuisineManager.GetAll();
        }
    }
}