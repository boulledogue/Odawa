namespace Odawa
{
    partial class FormViewReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewReservation));
            this.labelRestaurant = new System.Windows.Forms.Label();
            this.dataGridViewReservations = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.radioButtonSoir = new System.Windows.Forms.RadioButton();
            this.radioButtonMidi = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRestaurant
            // 
            this.labelRestaurant.AutoSize = true;
            this.labelRestaurant.Location = new System.Drawing.Point(13, 13);
            this.labelRestaurant.Name = "labelRestaurant";
            this.labelRestaurant.Size = new System.Drawing.Size(81, 13);
            this.labelRestaurant.TabIndex = 0;
            this.labelRestaurant.Text = "labelRestaurant";
            // 
            // dataGridViewReservations
            // 
            this.dataGridViewReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservations.Location = new System.Drawing.Point(13, 42);
            this.dataGridViewReservations.Name = "dataGridViewReservations";
            this.dataGridViewReservations.Size = new System.Drawing.Size(661, 267);
            this.dataGridViewReservations.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(598, 318);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Fermer";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // radioButtonSoir
            // 
            this.radioButtonSoir.AutoSize = true;
            this.radioButtonSoir.Location = new System.Drawing.Point(630, 13);
            this.radioButtonSoir.Name = "radioButtonSoir";
            this.radioButtonSoir.Size = new System.Drawing.Size(43, 17);
            this.radioButtonSoir.TabIndex = 3;
            this.radioButtonSoir.TabStop = true;
            this.radioButtonSoir.Text = "Soir";
            this.radioButtonSoir.UseVisualStyleBackColor = true;
            this.radioButtonSoir.CheckedChanged += new System.EventHandler(this.radioButtonSoir_CheckedChanged);
            // 
            // radioButtonMidi
            // 
            this.radioButtonMidi.AutoSize = true;
            this.radioButtonMidi.Location = new System.Drawing.Point(568, 13);
            this.radioButtonMidi.Name = "radioButtonMidi";
            this.radioButtonMidi.Size = new System.Drawing.Size(44, 17);
            this.radioButtonMidi.TabIndex = 4;
            this.radioButtonMidi.TabStop = true;
            this.radioButtonMidi.Text = "Midi";
            this.radioButtonMidi.UseVisualStyleBackColor = true;
            this.radioButtonMidi.CheckedChanged += new System.EventHandler(this.radioButtonMidi_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(489, 13);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(58, 17);
            this.radioButtonAll.TabIndex = 5;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Toutes";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // FormViewReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 353);
            this.Controls.Add(this.radioButtonAll);
            this.Controls.Add(this.radioButtonMidi);
            this.Controls.Add(this.radioButtonSoir);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridViewReservations);
            this.Controls.Add(this.labelRestaurant);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormViewReservation";
            this.Text = "Réservations";
            this.Load += new System.EventHandler(this.FormViewReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRestaurant;
        private System.Windows.Forms.DataGridView dataGridViewReservations;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RadioButton radioButtonSoir;
        private System.Windows.Forms.RadioButton radioButtonMidi;
        private System.Windows.Forms.RadioButton radioButtonAll;
    }
}