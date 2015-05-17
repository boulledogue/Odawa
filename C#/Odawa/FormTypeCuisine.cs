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
    public partial class FormTypeCuisine : Form
    {
        private int typeCuisineId { get; set; }

        public FormTypeCuisine()
        {
            this.typeCuisineId = -1;
            InitializeComponent();
        }

        public FormTypeCuisine(TypeCuisine typeCuisine) : this()
        {
            this.typeCuisineId = typeCuisine.id;
            textBoxTypeCuisine.DataBindings.Add("Text", typeCuisine, "type");
            richTextBoxDescType.DataBindings.Add("Text", typeCuisine, "description");            
        }

        private void buttonTypeCuisine_Click(object sender, EventArgs e)
        {
            TypeCuisine t = new TypeCuisine();
            t.id = this.typeCuisineId;
            t.type = textBoxTypeCuisine.Text;
            if (richTextBoxDescType.Text.Length == 0) t.description = "Aucune description pour ce type de cuisine.";
            else t.description = richTextBoxDescType.Text;

            if(Validate(t))
            {                
                if (typeCuisineId == -1) TypeCuisineManager.Create(t);
                else TypeCuisineManager.Update(t);
                this.Dispose();
            }
        }

        private bool Validate(TypeCuisine t)
        {
            labelTypeCuisine.ForeColor = Color.Empty;
            labelDescriptionType.ForeColor = Color.Empty;
            bool valid = true;
            string message = "";

            if(t.type.Length <3)
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Le nom du type doit au moins faire 3 caractères.\n";
            }

            if(!Regex.IsMatch(t.type, @"^[a-zA-Z]+$"))
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Le nom du type ne doit contenir que des caractères alphabétiques.\n";
            }

            if(TypeCuisineManager.GetAll().Find(x => x.type == t.type) != null && this.typeCuisineId == -1)
            {
                labelTypeCuisine.ForeColor = Color.Red;
                valid = false;
                message += "Le type existe déjà.\n";
            }

            if (t.description.Length > 0 && t.description.Length < 10)
            {
                labelDescriptionType.ForeColor = Color.Red;
                valid = false;
                message += "La description doit être vide ou faire au moins 10 caractères.\n";
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
