namespace Odawa
{
    partial class FormAjoutRestaurant
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNom = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelAdresse = new System.Windows.Forms.Label();
            this.textBoxAdresse = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelZipCode = new System.Windows.Forms.Label();
            this.textBoxZipcode = new System.Windows.Forms.TextBox();
            this.labelLocalite = new System.Windows.Forms.Label();
            this.textBoxLocalite = new System.Windows.Forms.TextBox();
            this.labelRestaurateur = new System.Windows.Forms.Label();
            this.labelPremium = new System.Windows.Forms.Label();
            this.checkBoxPromotion = new System.Windows.Forms.CheckBox();
            this.saveRestaurant = new System.Windows.Forms.Button();
            this.labelTypeCuisine = new System.Windows.Forms.Label();
            this.labelHoraire = new System.Windows.Forms.Label();
            this.textBoxHoraire = new System.Windows.Forms.TextBox();
            this.comboBoxRestaurateur = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeCuisine = new System.Windows.Forms.ComboBox();
            this.odawaDS1 = new DAL.OdawaDS();
            ((System.ComponentModel.ISupportInitialize)(this.odawaDS1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Location = new System.Drawing.Point(12, 9);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(29, 13);
            this.labelNom.TabIndex = 0;
            this.labelNom.Text = "Nom";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(105, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelAdresse
            // 
            this.labelAdresse.AutoSize = true;
            this.labelAdresse.Location = new System.Drawing.Point(12, 34);
            this.labelAdresse.Name = "labelAdresse";
            this.labelAdresse.Size = new System.Drawing.Size(44, 13);
            this.labelAdresse.TabIndex = 2;
            this.labelAdresse.Text = "adresse";
            // 
            // textBoxAdresse
            // 
            this.textBoxAdresse.Location = new System.Drawing.Point(105, 35);
            this.textBoxAdresse.Name = "textBoxAdresse";
            this.textBoxAdresse.Size = new System.Drawing.Size(100, 20);
            this.textBoxAdresse.TabIndex = 3;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(12, 62);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(44, 13);
            this.labelNumero.TabIndex = 4;
            this.labelNumero.Text = "Numéro";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(105, 62);
            this.textBoxNumber.MaxLength = 3;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(43, 20);
            this.textBoxNumber.TabIndex = 5;
            // 
            // labelZipCode
            // 
            this.labelZipCode.AutoSize = true;
            this.labelZipCode.Location = new System.Drawing.Point(12, 91);
            this.labelZipCode.Name = "labelZipCode";
            this.labelZipCode.Size = new System.Drawing.Size(63, 13);
            this.labelZipCode.TabIndex = 6;
            this.labelZipCode.Text = "Code postal";
            // 
            // textBoxZipcode
            // 
            this.textBoxZipcode.Location = new System.Drawing.Point(105, 88);
            this.textBoxZipcode.MaxLength = 4;
            this.textBoxZipcode.Name = "textBoxZipcode";
            this.textBoxZipcode.Size = new System.Drawing.Size(43, 20);
            this.textBoxZipcode.TabIndex = 7;
            // 
            // labelLocalite
            // 
            this.labelLocalite.AutoSize = true;
            this.labelLocalite.Location = new System.Drawing.Point(12, 120);
            this.labelLocalite.Name = "labelLocalite";
            this.labelLocalite.Size = new System.Drawing.Size(44, 13);
            this.labelLocalite.TabIndex = 8;
            this.labelLocalite.Text = "Localité";
            // 
            // textBoxLocalite
            // 
            this.textBoxLocalite.Location = new System.Drawing.Point(105, 117);
            this.textBoxLocalite.Name = "textBoxLocalite";
            this.textBoxLocalite.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocalite.TabIndex = 9;
            // 
            // labelRestaurateur
            // 
            this.labelRestaurateur.AutoSize = true;
            this.labelRestaurateur.Location = new System.Drawing.Point(12, 151);
            this.labelRestaurateur.Name = "labelRestaurateur";
            this.labelRestaurateur.Size = new System.Drawing.Size(77, 13);
            this.labelRestaurateur.TabIndex = 10;
            this.labelRestaurateur.Text = "RestaurateurId";
            // 
            // labelPremium
            // 
            this.labelPremium.AutoSize = true;
            this.labelPremium.Location = new System.Drawing.Point(12, 242);
            this.labelPremium.Name = "labelPremium";
            this.labelPremium.Size = new System.Drawing.Size(47, 13);
            this.labelPremium.TabIndex = 12;
            this.labelPremium.Text = "Premium";
            // 
            // checkBoxPromotion
            // 
            this.checkBoxPromotion.AutoSize = true;
            this.checkBoxPromotion.Location = new System.Drawing.Point(105, 242);
            this.checkBoxPromotion.Name = "checkBoxPromotion";
            this.checkBoxPromotion.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPromotion.TabIndex = 13;
            this.checkBoxPromotion.UseVisualStyleBackColor = true;
            // 
            // saveRestaurant
            // 
            this.saveRestaurant.Location = new System.Drawing.Point(197, 259);
            this.saveRestaurant.Name = "saveRestaurant";
            this.saveRestaurant.Size = new System.Drawing.Size(75, 23);
            this.saveRestaurant.TabIndex = 14;
            this.saveRestaurant.Text = "Save";
            this.saveRestaurant.UseVisualStyleBackColor = true;
            this.saveRestaurant.Click += new System.EventHandler(this.saveRestaurant_Click);
            // 
            // labelTypeCuisine
            // 
            this.labelTypeCuisine.AutoSize = true;
            this.labelTypeCuisine.Location = new System.Drawing.Point(12, 185);
            this.labelTypeCuisine.Name = "labelTypeCuisine";
            this.labelTypeCuisine.Size = new System.Drawing.Size(74, 13);
            this.labelTypeCuisine.TabIndex = 15;
            this.labelTypeCuisine.Text = "TypeCuisineId";
            // 
            // labelHoraire
            // 
            this.labelHoraire.AutoSize = true;
            this.labelHoraire.Location = new System.Drawing.Point(12, 216);
            this.labelHoraire.Name = "labelHoraire";
            this.labelHoraire.Size = new System.Drawing.Size(50, 13);
            this.labelHoraire.TabIndex = 17;
            this.labelHoraire.Text = "HoraireId";
            // 
            // textBoxHoraire
            // 
            this.textBoxHoraire.Location = new System.Drawing.Point(105, 216);
            this.textBoxHoraire.Name = "textBoxHoraire";
            this.textBoxHoraire.Size = new System.Drawing.Size(100, 20);
            this.textBoxHoraire.TabIndex = 18;
            // 
            // comboBoxRestaurateur
            // 
            this.comboBoxRestaurateur.FormattingEnabled = true;
            this.comboBoxRestaurateur.Location = new System.Drawing.Point(105, 151);
            this.comboBoxRestaurateur.Name = "comboBoxRestaurateur";
            this.comboBoxRestaurateur.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRestaurateur.TabIndex = 19;
            this.comboBoxRestaurateur.SelectedIndexChanged += new System.EventHandler(this.comboBoxRestaurateur_SelectedIndexChanged);
            // 
            // comboBoxTypeCuisine
            // 
            this.comboBoxTypeCuisine.FormattingEnabled = true;
            this.comboBoxTypeCuisine.Location = new System.Drawing.Point(105, 185);
            this.comboBoxTypeCuisine.Name = "comboBoxTypeCuisine";
            this.comboBoxTypeCuisine.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypeCuisine.TabIndex = 20;
            // 
            // odawaDS1
            // 
            this.odawaDS1.DataSetName = "OdawaDS";
            this.odawaDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormAjoutRestaurant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 294);
            this.Controls.Add(this.comboBoxTypeCuisine);
            this.Controls.Add(this.comboBoxRestaurateur);
            this.Controls.Add(this.textBoxHoraire);
            this.Controls.Add(this.labelHoraire);
            this.Controls.Add(this.labelTypeCuisine);
            this.Controls.Add(this.saveRestaurant);
            this.Controls.Add(this.checkBoxPromotion);
            this.Controls.Add(this.labelPremium);
            this.Controls.Add(this.labelRestaurateur);
            this.Controls.Add(this.textBoxLocalite);
            this.Controls.Add(this.labelLocalite);
            this.Controls.Add(this.textBoxZipcode);
            this.Controls.Add(this.labelZipCode);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.textBoxAdresse);
            this.Controls.Add(this.labelAdresse);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelNom);
            this.Name = "FormAjoutRestaurant";
            this.Text = "FormAjoutRestaurant";
            ((System.ComponentModel.ISupportInitialize)(this.odawaDS1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelAdresse;
        private System.Windows.Forms.TextBox textBoxAdresse;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelZipCode;
        private System.Windows.Forms.TextBox textBoxZipcode;
        private System.Windows.Forms.Label labelLocalite;
        private System.Windows.Forms.TextBox textBoxLocalite;
        private System.Windows.Forms.Label labelRestaurateur;
        private System.Windows.Forms.Label labelPremium;
        private System.Windows.Forms.CheckBox checkBoxPromotion;
        private System.Windows.Forms.Button saveRestaurant;
        private System.Windows.Forms.Label labelTypeCuisine;
        private System.Windows.Forms.Label labelHoraire;
        private System.Windows.Forms.TextBox textBoxHoraire;
        private System.Windows.Forms.ComboBox comboBoxRestaurateur;
        private System.Windows.Forms.ComboBox comboBoxTypeCuisine;
        private DAL.OdawaDS odawaDS1;
    }
}