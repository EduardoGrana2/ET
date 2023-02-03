namespace Examen_Tecnico
{
    partial class ConsultaDCF
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
            this.dgvDCF = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDCF)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDCF
            // 
            this.dgvDCF.AllowUserToAddRows = false;
            this.dgvDCF.AllowUserToDeleteRows = false;
            this.dgvDCF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDCF.Location = new System.Drawing.Point(48, 35);
            this.dgvDCF.Name = "dgvDCF";
            this.dgvDCF.ReadOnly = true;
            this.dgvDCF.Size = new System.Drawing.Size(710, 369);
            this.dgvDCF.TabIndex = 0;
            // 
            // ConsultaDCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDCF);
            this.Name = "ConsultaDCF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaDCF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultaDCF_FormClosing);
            this.Load += new System.EventHandler(this.ConsultaDCF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDCF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDCF;
    }
}