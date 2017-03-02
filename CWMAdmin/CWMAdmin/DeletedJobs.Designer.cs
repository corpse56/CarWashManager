namespace CWMAdmin
{
    partial class DeletedJobs
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
            this.dgwDel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwDel
            // 
            this.dgwDel.AllowUserToAddRows = false;
            this.dgwDel.AllowUserToDeleteRows = false;
            this.dgwDel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDel.Location = new System.Drawing.Point(12, 12);
            this.dgwDel.MultiSelect = false;
            this.dgwDel.Name = "dgwDel";
            this.dgwDel.ReadOnly = true;
            this.dgwDel.RowHeadersVisible = false;
            this.dgwDel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwDel.Size = new System.Drawing.Size(1142, 413);
            this.dgwDel.TabIndex = 2;
            // 
            // DeletedJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 463);
            this.Controls.Add(this.dgwDel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeletedJobs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список удалённых заданий";
            this.Load += new System.EventHandler(this.DeletedPack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwDel;
    }
}