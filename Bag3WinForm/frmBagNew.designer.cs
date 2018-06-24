namespace Bag3WinForm
{
    partial class frmBagNew
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
            this.txtWaranty = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWaranty
            // 
            this.txtWaranty.Location = new System.Drawing.Point(97, 152);
            this.txtWaranty.Name = "txtWaranty";
            this.txtWaranty.Size = new System.Drawing.Size(232, 20);
            this.txtWaranty.TabIndex = 4;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(9, 155);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 23);
            this.Label4.TabIndex = 46;
            this.Label4.Text = "Warranty";
            // 
            // frmBagNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(352, 189);
            this.Controls.Add(this.txtWaranty);
            this.Controls.Add(this.Label4);
            this.Name = "frmBagNew";
            this.Text = "New Bag";
            this.Controls.SetChildIndex(this.Label4, 0);
            this.Controls.SetChildIndex(this.txtWaranty, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TextBox txtWaranty;
        internal System.Windows.Forms.Label Label4;
    }
}
