﻿namespace BiblioTechProject.UI.Consultas
{
    partial class FrmConsultaUsuarios
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
            this.filtrarComboBox = new System.Windows.Forms.ComboBox();
            this.filtrarLabel = new System.Windows.Forms.Label();
            this.filtrarTextBox = new System.Windows.Forms.TextBox();
            this.usuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.filtrarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filtrarComboBox
            // 
            this.filtrarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filtrarComboBox.FormattingEnabled = true;
            this.filtrarComboBox.Items.AddRange(new object[] {
            "Todo",
            "Id",
            "Nombre"});
            this.filtrarComboBox.Location = new System.Drawing.Point(87, 36);
            this.filtrarComboBox.Name = "filtrarComboBox";
            this.filtrarComboBox.Size = new System.Drawing.Size(121, 21);
            this.filtrarComboBox.TabIndex = 0;
            this.filtrarComboBox.SelectedIndexChanged += new System.EventHandler(this.filtrarComboBox_SelectedIndexChanged);
            // 
            // filtrarLabel
            // 
            this.filtrarLabel.AutoSize = true;
            this.filtrarLabel.Location = new System.Drawing.Point(31, 39);
            this.filtrarLabel.Name = "filtrarLabel";
            this.filtrarLabel.Size = new System.Drawing.Size(50, 13);
            this.filtrarLabel.TabIndex = 1;
            this.filtrarLabel.Text = "Filtrar por";
            // 
            // filtrarTextBox
            // 
            this.filtrarTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrarTextBox.Location = new System.Drawing.Point(214, 36);
            this.filtrarTextBox.Name = "filtrarTextBox";
            this.filtrarTextBox.Size = new System.Drawing.Size(285, 20);
            this.filtrarTextBox.TabIndex = 2;
            // 
            // usuariosDataGridView
            // 
            this.usuariosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuariosDataGridView.Location = new System.Drawing.Point(34, 73);
            this.usuariosDataGridView.Name = "usuariosDataGridView";
            this.usuariosDataGridView.Size = new System.Drawing.Size(546, 150);
            this.usuariosDataGridView.TabIndex = 3;
            // 
            // filtrarButton
            // 
            this.filtrarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filtrarButton.Location = new System.Drawing.Point(505, 34);
            this.filtrarButton.Name = "filtrarButton";
            this.filtrarButton.Size = new System.Drawing.Size(75, 23);
            this.filtrarButton.TabIndex = 4;
            this.filtrarButton.Text = "Filtrar";
            this.filtrarButton.UseVisualStyleBackColor = true;
            this.filtrarButton.Click += new System.EventHandler(this.filtrarButton_Click);
            // 
            // FrmConsultaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 261);
            this.Controls.Add(this.filtrarButton);
            this.Controls.Add(this.usuariosDataGridView);
            this.Controls.Add(this.filtrarTextBox);
            this.Controls.Add(this.filtrarLabel);
            this.Controls.Add(this.filtrarComboBox);
            this.Name = "FrmConsultaUsuarios";
            this.Text = "BiblioTech - Consulta de Usuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConsultaUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.FrmConsultaUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox filtrarComboBox;
        private System.Windows.Forms.Label filtrarLabel;
        private System.Windows.Forms.TextBox filtrarTextBox;
        private System.Windows.Forms.DataGridView usuariosDataGridView;
        private System.Windows.Forms.Button filtrarButton;
    }
}