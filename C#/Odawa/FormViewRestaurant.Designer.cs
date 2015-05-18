namespace Odawa
{
    partial class FormViewRestaurant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewRestaurant));
            this.labelRestaurateur = new System.Windows.Forms.Label();
            this.dataGridViewRestOwned = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelResto = new System.Windows.Forms.Button();
            this.buttonModResto = new System.Windows.Forms.Button();
            this.buttonAddResto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRestOwned)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRestaurateur
            // 
            this.labelRestaurateur.AutoSize = true;
            this.labelRestaurateur.Location = new System.Drawing.Point(13, 13);
            this.labelRestaurateur.Name = "labelRestaurateur";
            this.labelRestaurateur.Size = new System.Drawing.Size(90, 13);
            this.labelRestaurateur.TabIndex = 0;
            this.labelRestaurateur.Text = "labelRestaurateur";
            // 
            // dataGridViewRestOwned
            // 
            this.dataGridViewRestOwned.AllowUserToAddRows = false;
            this.dataGridViewRestOwned.AllowUserToDeleteRows = false;
            this.dataGridViewRestOwned.AllowUserToOrderColumns = true;
            this.dataGridViewRestOwned.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRestOwned.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRestOwned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRestOwned.Location = new System.Drawing.Point(13, 42);
            this.dataGridViewRestOwned.MultiSelect = false;
            this.dataGridViewRestOwned.Name = "dataGridViewRestOwned";
            this.dataGridViewRestOwned.ReadOnly = true;
            this.dataGridViewRestOwned.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRestOwned.Size = new System.Drawing.Size(661, 267);
            this.dataGridViewRestOwned.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(599, 318);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Fermer";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonDelResto
            // 
            this.buttonDelResto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelResto.Location = new System.Drawing.Point(518, 318);
            this.buttonDelResto.Name = "buttonDelResto";
            this.buttonDelResto.Size = new System.Drawing.Size(75, 23);
            this.buttonDelResto.TabIndex = 3;
            this.buttonDelResto.Text = "Supprimer";
            this.buttonDelResto.UseVisualStyleBackColor = true;
            this.buttonDelResto.Click += new System.EventHandler(this.buttonDelResto_Click);
            // 
            // buttonModResto
            // 
            this.buttonModResto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModResto.Location = new System.Drawing.Point(437, 318);
            this.buttonModResto.Name = "buttonModResto";
            this.buttonModResto.Size = new System.Drawing.Size(75, 23);
            this.buttonModResto.TabIndex = 4;
            this.buttonModResto.Text = "Modifier";
            this.buttonModResto.UseVisualStyleBackColor = true;
            this.buttonModResto.Click += new System.EventHandler(this.buttonModResto_Click);
            // 
            // buttonAddResto
            // 
            this.buttonAddResto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddResto.Location = new System.Drawing.Point(356, 318);
            this.buttonAddResto.Name = "buttonAddResto";
            this.buttonAddResto.Size = new System.Drawing.Size(75, 23);
            this.buttonAddResto.TabIndex = 5;
            this.buttonAddResto.Text = "Ajouter";
            this.buttonAddResto.UseVisualStyleBackColor = true;
            this.buttonAddResto.Click += new System.EventHandler(this.buttonAddResto_Click);
            // 
            // FormViewRestaurant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 353);
            this.Controls.Add(this.buttonAddResto);
            this.Controls.Add(this.buttonModResto);
            this.Controls.Add(this.buttonDelResto);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridViewRestOwned);
            this.Controls.Add(this.labelRestaurateur);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormViewRestaurant";
            this.Text = "Restaurants";
            this.Load += new System.EventHandler(this.FormViewRestaurant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRestOwned)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRestaurateur;
        private System.Windows.Forms.DataGridView dataGridViewRestOwned;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDelResto;
        private System.Windows.Forms.Button buttonModResto;
        private System.Windows.Forms.Button buttonAddResto;
    }
}