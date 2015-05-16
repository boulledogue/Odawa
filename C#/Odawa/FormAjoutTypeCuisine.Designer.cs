namespace Odawa
{
    partial class FormAjoutTypeCuisine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjoutTypeCuisine));
            this.labelTypeCuisine = new System.Windows.Forms.Label();
            this.textBoxTypeCuisine = new System.Windows.Forms.TextBox();
            this.buttonTypeCuisine = new System.Windows.Forms.Button();
            this.buttonCancelTypeCuisine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTypeCuisine
            // 
            this.labelTypeCuisine.AutoSize = true;
            this.labelTypeCuisine.Location = new System.Drawing.Point(29, 43);
            this.labelTypeCuisine.Name = "labelTypeCuisine";
            this.labelTypeCuisine.Size = new System.Drawing.Size(37, 13);
            this.labelTypeCuisine.TabIndex = 0;
            this.labelTypeCuisine.Text = "Type :";
            // 
            // textBoxTypeCuisine
            // 
            this.textBoxTypeCuisine.Location = new System.Drawing.Point(93, 43);
            this.textBoxTypeCuisine.Name = "textBoxTypeCuisine";
            this.textBoxTypeCuisine.Size = new System.Drawing.Size(160, 20);
            this.textBoxTypeCuisine.TabIndex = 1;
            // 
            // buttonTypeCuisine
            // 
            this.buttonTypeCuisine.Location = new System.Drawing.Point(178, 83);
            this.buttonTypeCuisine.Name = "buttonTypeCuisine";
            this.buttonTypeCuisine.Size = new System.Drawing.Size(75, 23);
            this.buttonTypeCuisine.TabIndex = 2;
            this.buttonTypeCuisine.Text = "Sauver";
            this.buttonTypeCuisine.UseVisualStyleBackColor = true;
            this.buttonTypeCuisine.Click += new System.EventHandler(this.buttonTypeCuisine_Click);
            // 
            // buttonCancelTypeCuisine
            // 
            this.buttonCancelTypeCuisine.Location = new System.Drawing.Point(93, 83);
            this.buttonCancelTypeCuisine.Name = "buttonCancelTypeCuisine";
            this.buttonCancelTypeCuisine.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelTypeCuisine.TabIndex = 3;
            this.buttonCancelTypeCuisine.Text = "Annuler";
            this.buttonCancelTypeCuisine.UseVisualStyleBackColor = true;
            this.buttonCancelTypeCuisine.Click += new System.EventHandler(this.buttonCancelTypeCuisine_Click);
            // 
            // FormAjoutTypeCuisine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.buttonCancelTypeCuisine);
            this.Controls.Add(this.buttonTypeCuisine);
            this.Controls.Add(this.textBoxTypeCuisine);
            this.Controls.Add(this.labelTypeCuisine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAjoutTypeCuisine";
            this.Text = "Ajouter / Modifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTypeCuisine;
        private System.Windows.Forms.TextBox textBoxTypeCuisine;
        private System.Windows.Forms.Button buttonTypeCuisine;
        private System.Windows.Forms.Button buttonCancelTypeCuisine;
    }
}