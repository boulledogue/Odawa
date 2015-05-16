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
    public partial class FormAjoutTypeCuisine : Form
    {
        private int typeCuisineId { get; set; }

        public FormAjoutTypeCuisine()
        {
            this.typeCuisineId = -1;
            InitializeComponent();
        }

        public FormAjoutTypeCuisine(TypeCuisine typeCuisine) : this()
        {
            this.typeCuisineId = typeCuisine.id;
            textBoxTypeCuisine.DataBindings.Add("Text", typeCuisine, "type");
            
        }

        private void buttonTypeCuisine_Click(object sender, EventArgs e)
        {
            TypeCuisine typeCuisine = new TypeCuisine();
            typeCuisine.id = this.typeCuisineId;
            typeCuisine.type = textBoxTypeCuisine.Text;

            if(Validate(typeCuisine))
            {
                if (typeCuisineId == -1) TypeCuisineManager.Create(typeCuisine);
                else TypeCuisineManager.Update(typeCuisine);
                this.Dispose();
            }
        }

        private bool Validate(TypeCuisine typeCuisine)
        {
            labelTypeCuisine.ForeColor = Color.Empty;
            bool valid = true;
            string message = "";

            if(typeCuisine.type.Length <3)
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Entrez un type de au moins 3 caractères.\n";
            }

            if(!Regex.IsMatch(typeCuisine.type, @"^[a-zA-Z]+$"))
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Le type ne doit contenir que des caractères alphabétiques.\n";
            }

            if(TypeCuisineManager.GetAll().Find(x => x.type == typeCuisine.type) != null)
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Le type existe déjà.\n";
            }

            if (!valid)
            {
                string caption = "Erreur";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }

            return valid;
        }

        private void buttonCancelTypeCuisine_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
