namespace Odawa
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAdmins = new System.Windows.Forms.TabPage();
            this.buttonAddAdmin = new System.Windows.Forms.Button();
            this.buttonModAdmin = new System.Windows.Forms.Button();
            this.buttonDelAdmin = new System.Windows.Forms.Button();
            this.dataGridViewAdministrateurs = new System.Windows.Forms.DataGridView();
            this.tabRestaurateurs = new System.Windows.Forms.TabPage();
            this.buttonModRestaurateur = new System.Windows.Forms.Button();
            this.buttonDelRestaurateur = new System.Windows.Forms.Button();
            this.buttonAddRestaurateur = new System.Windows.Forms.Button();
            this.dataGridViewRestaurateurs = new System.Windows.Forms.DataGridView();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.buttonModUser = new System.Windows.Forms.Button();
            this.buttonDelUser = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.dataGridViewUtilisateurs = new System.Windows.Forms.DataGridView();
            this.tabRestos = new System.Windows.Forms.TabPage();
            this.buttonAddResto = new System.Windows.Forms.Button();
            this.buttonModResto = new System.Windows.Forms.Button();
            this.buttonDelResto = new System.Windows.Forms.Button();
            this.dataGridViewRestaurants = new System.Windows.Forms.DataGridView();
            this.tabTypes = new System.Windows.Forms.TabPage();
            this.buttonAddType = new System.Windows.Forms.Button();
            this.buttonModType = new System.Windows.Forms.Button();
            this.buttonDelType = new System.Windows.Forms.Button();
            this.dataGridViewTypesCuisine = new System.Windows.Forms.DataGridView();
            this.buttonViewReservations = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabAdmins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdministrateurs)).BeginInit();
            this.tabRestaurateurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRestaurateurs)).BeginInit();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUtilisateurs)).BeginInit();
            this.tabRestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRestaurants)).BeginInit();
            this.tabTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTypesCuisine)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAdmins);
            this.tabControl1.Controls.Add(this.tabRestaurateurs);
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Controls.Add(this.tabRestos);
            this.tabControl1.Controls.Add(this.tabTypes);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 478);
            this.tabControl1.TabIndex = 1;
            // 
            // tabAdmins
            // 
            this.tabAdmins.Controls.Add(this.buttonAddAdmin);
            this.tabAdmins.Controls.Add(this.buttonModAdmin);
            this.tabAdmins.Controls.Add(this.buttonDelAdmin);
            this.tabAdmins.Controls.Add(this.dataGridViewAdministrateurs);
            this.tabAdmins.Location = new System.Drawing.Point(4, 22);
            this.tabAdmins.Name = "tabAdmins";
            this.tabAdmins.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmins.Size = new System.Drawing.Size(790, 452);
            this.tabAdmins.TabIndex = 0;
            this.tabAdmins.Text = "Administrateurs";
            this.tabAdmins.UseVisualStyleBackColor = true;
            // 
            // buttonAddAdmin
            // 
            this.buttonAddAdmin.Location = new System.Drawing.Point(547, 419);
            this.buttonAddAdmin.Name = "buttonAddAdmin";
            this.buttonAddAdmin.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAdmin.TabIndex = 4;
            this.buttonAddAdmin.Text = "Ajouter";
            this.buttonAddAdmin.UseVisualStyleBackColor = true;
            this.buttonAddAdmin.Click += new System.EventHandler(this.buttonAddAdmin_Click);
            // 
            // buttonModAdmin
            // 
            this.buttonModAdmin.Location = new System.Drawing.Point(628, 419);
            this.buttonModAdmin.Name = "buttonModAdmin";
            this.buttonModAdmin.Size = new System.Drawing.Size(75, 23);
            this.buttonModAdmin.TabIndex = 3;
            this.buttonModAdmin.Text = "Modifier";
            this.buttonModAdmin.UseVisualStyleBackColor = true;
            this.buttonModAdmin.Click += new System.EventHandler(this.buttonModAdmin_Click);
            // 
            // buttonDelAdmin
            // 
            this.buttonDelAdmin.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonDelAdmin.Location = new System.Drawing.Point(709, 419);
            this.buttonDelAdmin.Name = "buttonDelAdmin";
            this.buttonDelAdmin.Size = new System.Drawing.Size(75, 23);
            this.buttonDelAdmin.TabIndex = 2;
            this.buttonDelAdmin.Text = "Supprimer";
            this.buttonDelAdmin.UseVisualStyleBackColor = true;
            this.buttonDelAdmin.Click += new System.EventHandler(this.buttonDelAdmin_Click);
            // 
            // dataGridViewAdministrateurs
            // 
            this.dataGridViewAdministrateurs.AllowUserToAddRows = false;
            this.dataGridViewAdministrateurs.AllowUserToDeleteRows = false;
            this.dataGridViewAdministrateurs.AllowUserToResizeRows = false;
            this.dataGridViewAdministrateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdministrateurs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAdministrateurs.MultiSelect = false;
            this.dataGridViewAdministrateurs.Name = "dataGridViewAdministrateurs";
            this.dataGridViewAdministrateurs.ReadOnly = true;
            this.dataGridViewAdministrateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAdministrateurs.Size = new System.Drawing.Size(781, 410);
            this.dataGridViewAdministrateurs.TabIndex = 1;
            // 
            // tabRestaurateurs
            // 
            this.tabRestaurateurs.Controls.Add(this.buttonModRestaurateur);
            this.tabRestaurateurs.Controls.Add(this.buttonDelRestaurateur);
            this.tabRestaurateurs.Controls.Add(this.buttonAddRestaurateur);
            this.tabRestaurateurs.Controls.Add(this.dataGridViewRestaurateurs);
            this.tabRestaurateurs.Location = new System.Drawing.Point(4, 22);
            this.tabRestaurateurs.Name = "tabRestaurateurs";
            this.tabRestaurateurs.Padding = new System.Windows.Forms.Padding(3);
            this.tabRestaurateurs.Size = new System.Drawing.Size(790, 452);
            this.tabRestaurateurs.TabIndex = 1;
            this.tabRestaurateurs.Text = "Restaurateurs";
            this.tabRestaurateurs.UseVisualStyleBackColor = true;
            // 
            // buttonModRestaurateur
            // 
            this.buttonModRestaurateur.Location = new System.Drawing.Point(628, 419);
            this.buttonModRestaurateur.Name = "buttonModRestaurateur";
            this.buttonModRestaurateur.Size = new System.Drawing.Size(75, 23);
            this.buttonModRestaurateur.TabIndex = 7;
            this.buttonModRestaurateur.Text = "Modifier";
            this.buttonModRestaurateur.UseVisualStyleBackColor = true;
            this.buttonModRestaurateur.Click += new System.EventHandler(this.buttonModRestaurateur_Click);
            // 
            // buttonDelRestaurateur
            // 
            this.buttonDelRestaurateur.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonDelRestaurateur.Location = new System.Drawing.Point(709, 419);
            this.buttonDelRestaurateur.Name = "buttonDelRestaurateur";
            this.buttonDelRestaurateur.Size = new System.Drawing.Size(75, 23);
            this.buttonDelRestaurateur.TabIndex = 6;
            this.buttonDelRestaurateur.Text = "Supprimer";
            this.buttonDelRestaurateur.UseVisualStyleBackColor = true;
            this.buttonDelRestaurateur.Click += new System.EventHandler(this.buttonDelRestaurateur_Click);
            // 
            // buttonAddRestaurateur
            // 
            this.buttonAddRestaurateur.Location = new System.Drawing.Point(547, 419);
            this.buttonAddRestaurateur.Name = "buttonAddRestaurateur";
            this.buttonAddRestaurateur.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRestaurateur.TabIndex = 5;
            this.buttonAddRestaurateur.Text = "Ajouter";
            this.buttonAddRestaurateur.UseVisualStyleBackColor = true;
            this.buttonAddRestaurateur.Click += new System.EventHandler(this.buttonAddRestaurateur_Click);
            // 
            // dataGridViewRestaurateurs
            // 
            this.dataGridViewRestaurateurs.AllowUserToAddRows = false;
            this.dataGridViewRestaurateurs.AllowUserToDeleteRows = false;
            this.dataGridViewRestaurateurs.AllowUserToResizeRows = false;
            this.dataGridViewRestaurateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRestaurateurs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRestaurateurs.MultiSelect = false;
            this.dataGridViewRestaurateurs.Name = "dataGridViewRestaurateurs";
            this.dataGridViewRestaurateurs.ReadOnly = true;
            this.dataGridViewRestaurateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRestaurateurs.Size = new System.Drawing.Size(781, 410);
            this.dataGridViewRestaurateurs.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.buttonModUser);
            this.tabUsers.Controls.Add(this.buttonDelUser);
            this.tabUsers.Controls.Add(this.buttonAddUser);
            this.tabUsers.Controls.Add(this.dataGridViewUtilisateurs);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(790, 452);
            this.tabUsers.TabIndex = 2;
            this.tabUsers.Text = "Utilisateurs";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // buttonModUser
            // 
            this.buttonModUser.Location = new System.Drawing.Point(628, 419);
            this.buttonModUser.Name = "buttonModUser";
            this.buttonModUser.Size = new System.Drawing.Size(75, 23);
            this.buttonModUser.TabIndex = 10;
            this.buttonModUser.Text = "Modifier";
            this.buttonModUser.UseVisualStyleBackColor = true;
            this.buttonModUser.Click += new System.EventHandler(this.buttonModUser_Click);
            // 
            // buttonDelUser
            // 
            this.buttonDelUser.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonDelUser.Location = new System.Drawing.Point(709, 419);
            this.buttonDelUser.Name = "buttonDelUser";
            this.buttonDelUser.Size = new System.Drawing.Size(75, 23);
            this.buttonDelUser.TabIndex = 9;
            this.buttonDelUser.Text = "Supprimer";
            this.buttonDelUser.UseVisualStyleBackColor = true;
            this.buttonDelUser.Click += new System.EventHandler(this.buttonDelUser_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(547, 419);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 8;
            this.buttonAddUser.Text = "Ajouter";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // dataGridViewUtilisateurs
            // 
            this.dataGridViewUtilisateurs.AllowUserToAddRows = false;
            this.dataGridViewUtilisateurs.AllowUserToDeleteRows = false;
            this.dataGridViewUtilisateurs.AllowUserToResizeRows = false;
            this.dataGridViewUtilisateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUtilisateurs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewUtilisateurs.Name = "dataGridViewUtilisateurs";
            this.dataGridViewUtilisateurs.ReadOnly = true;
            this.dataGridViewUtilisateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUtilisateurs.Size = new System.Drawing.Size(781, 410);
            this.dataGridViewUtilisateurs.TabIndex = 0;
            // 
            // tabRestos
            // 
            this.tabRestos.Controls.Add(this.buttonViewReservations);
            this.tabRestos.Controls.Add(this.buttonAddResto);
            this.tabRestos.Controls.Add(this.buttonModResto);
            this.tabRestos.Controls.Add(this.buttonDelResto);
            this.tabRestos.Controls.Add(this.dataGridViewRestaurants);
            this.tabRestos.Location = new System.Drawing.Point(4, 22);
            this.tabRestos.Name = "tabRestos";
            this.tabRestos.Size = new System.Drawing.Size(790, 452);
            this.tabRestos.TabIndex = 3;
            this.tabRestos.Text = "Restaurants";
            this.tabRestos.UseVisualStyleBackColor = true;
            // 
            // buttonAddResto
            // 
            this.buttonAddResto.Location = new System.Drawing.Point(547, 419);
            this.buttonAddResto.Name = "buttonAddResto";
            this.buttonAddResto.Size = new System.Drawing.Size(75, 23);
            this.buttonAddResto.TabIndex = 12;
            this.buttonAddResto.Text = "Ajouter";
            this.buttonAddResto.UseVisualStyleBackColor = true;
            this.buttonAddResto.Click += new System.EventHandler(this.buttonAddResto_Click);
            // 
            // buttonModResto
            // 
            this.buttonModResto.Location = new System.Drawing.Point(628, 419);
            this.buttonModResto.Name = "buttonModResto";
            this.buttonModResto.Size = new System.Drawing.Size(75, 23);
            this.buttonModResto.TabIndex = 11;
            this.buttonModResto.Text = "Modifier";
            this.buttonModResto.UseVisualStyleBackColor = true;
            this.buttonModResto.Click += new System.EventHandler(this.buttonModResto_Click);
            // 
            // buttonDelResto
            // 
            this.buttonDelResto.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonDelResto.Location = new System.Drawing.Point(709, 419);
            this.buttonDelResto.Name = "buttonDelResto";
            this.buttonDelResto.Size = new System.Drawing.Size(75, 23);
            this.buttonDelResto.TabIndex = 10;
            this.buttonDelResto.Text = "Supprimer";
            this.buttonDelResto.UseVisualStyleBackColor = true;
            this.buttonDelResto.Click += new System.EventHandler(this.buttonDelResto_Click);
            // 
            // dataGridViewRestaurants
            // 
            this.dataGridViewRestaurants.AllowUserToAddRows = false;
            this.dataGridViewRestaurants.AllowUserToDeleteRows = false;
            this.dataGridViewRestaurants.AllowUserToResizeRows = false;
            this.dataGridViewRestaurants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRestaurants.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRestaurants.Name = "dataGridViewRestaurants";
            this.dataGridViewRestaurants.ReadOnly = true;
            this.dataGridViewRestaurants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRestaurants.Size = new System.Drawing.Size(781, 410);
            this.dataGridViewRestaurants.TabIndex = 0;
            // 
            // tabTypes
            // 
            this.tabTypes.Controls.Add(this.buttonAddType);
            this.tabTypes.Controls.Add(this.buttonModType);
            this.tabTypes.Controls.Add(this.buttonDelType);
            this.tabTypes.Controls.Add(this.dataGridViewTypesCuisine);
            this.tabTypes.Location = new System.Drawing.Point(4, 22);
            this.tabTypes.Name = "tabTypes";
            this.tabTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabTypes.Size = new System.Drawing.Size(790, 452);
            this.tabTypes.TabIndex = 4;
            this.tabTypes.Text = "Types cuisine";
            this.tabTypes.UseVisualStyleBackColor = true;
            // 
            // buttonAddType
            // 
            this.buttonAddType.Location = new System.Drawing.Point(547, 419);
            this.buttonAddType.Name = "buttonAddType";
            this.buttonAddType.Size = new System.Drawing.Size(75, 23);
            this.buttonAddType.TabIndex = 13;
            this.buttonAddType.Text = "Ajouter";
            this.buttonAddType.UseVisualStyleBackColor = true;
            this.buttonAddType.Click += new System.EventHandler(this.buttonAddType_Click);
            // 
            // buttonModType
            // 
            this.buttonModType.Location = new System.Drawing.Point(628, 419);
            this.buttonModType.Name = "buttonModType";
            this.buttonModType.Size = new System.Drawing.Size(75, 23);
            this.buttonModType.TabIndex = 12;
            this.buttonModType.Text = "Modifier";
            this.buttonModType.UseVisualStyleBackColor = true;
            this.buttonModType.Click += new System.EventHandler(this.buttonModType_Click);
            // 
            // buttonDelType
            // 
            this.buttonDelType.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonDelType.Location = new System.Drawing.Point(709, 419);
            this.buttonDelType.Name = "buttonDelType";
            this.buttonDelType.Size = new System.Drawing.Size(75, 23);
            this.buttonDelType.TabIndex = 11;
            this.buttonDelType.Text = "Supprimer";
            this.buttonDelType.UseVisualStyleBackColor = true;
            this.buttonDelType.Click += new System.EventHandler(this.buttonDelType_Click);
            // 
            // dataGridViewTypesCuisine
            // 
            this.dataGridViewTypesCuisine.AllowUserToAddRows = false;
            this.dataGridViewTypesCuisine.AllowUserToDeleteRows = false;
            this.dataGridViewTypesCuisine.AllowUserToResizeRows = false;
            this.dataGridViewTypesCuisine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTypesCuisine.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTypesCuisine.MultiSelect = false;
            this.dataGridViewTypesCuisine.Name = "dataGridViewTypesCuisine";
            this.dataGridViewTypesCuisine.ReadOnly = true;
            this.dataGridViewTypesCuisine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTypesCuisine.Size = new System.Drawing.Size(781, 410);
            this.dataGridViewTypesCuisine.TabIndex = 0;
            // 
            // buttonViewReservations
            // 
            this.buttonViewReservations.Location = new System.Drawing.Point(3, 419);
            this.buttonViewReservations.Name = "buttonViewReservations";
            this.buttonViewReservations.Size = new System.Drawing.Size(134, 23);
            this.buttonViewReservations.TabIndex = 13;
            this.buttonViewReservations.Text = "Consulter réservations";
            this.buttonViewReservations.UseVisualStyleBackColor = true;
            this.buttonViewReservations.Click += new System.EventHandler(this.buttonViewReservations_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 517);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Odawa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAdmins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdministrateurs)).EndInit();
            this.tabRestaurateurs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRestaurateurs)).EndInit();
            this.tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUtilisateurs)).EndInit();
            this.tabRestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRestaurants)).EndInit();
            this.tabTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTypesCuisine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdmins;
        private System.Windows.Forms.DataGridView dataGridViewAdministrateurs;
        private System.Windows.Forms.TabPage tabRestaurateurs;
        private System.Windows.Forms.DataGridView dataGridViewRestaurateurs;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.DataGridView dataGridViewUtilisateurs;
        private System.Windows.Forms.TabPage tabRestos;
        private System.Windows.Forms.DataGridView dataGridViewRestaurants;
        private System.Windows.Forms.TabPage tabTypes;
        private System.Windows.Forms.DataGridView dataGridViewTypesCuisine;
        private System.Windows.Forms.Button buttonAddAdmin;
        private System.Windows.Forms.Button buttonModAdmin;
        private System.Windows.Forms.Button buttonDelAdmin;
        private System.Windows.Forms.Button buttonModRestaurateur;
        private System.Windows.Forms.Button buttonDelRestaurateur;
        private System.Windows.Forms.Button buttonAddRestaurateur;
        private System.Windows.Forms.Button buttonModUser;
        private System.Windows.Forms.Button buttonDelUser;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonAddResto;
        private System.Windows.Forms.Button buttonModResto;
        private System.Windows.Forms.Button buttonDelResto;
        private System.Windows.Forms.Button buttonAddType;
        private System.Windows.Forms.Button buttonModType;
        private System.Windows.Forms.Button buttonDelType;
        private System.Windows.Forms.Button buttonViewReservations;

    }
}

