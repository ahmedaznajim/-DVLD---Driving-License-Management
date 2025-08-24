namespace DVLI
{
    partial class FormDetainLicence
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDetain = new System.Windows.Forms.Button();
            this.textBoxFine = new System.Windows.Forms.TextBox();
            this.labelFine = new System.Windows.Forms.Label();
            this.userControlLCImfo1 = new DVLI.Licence.UserControlLCImfo();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(813, 473);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 35);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonDetain
            // 
            this.buttonDetain.Location = new System.Drawing.Point(960, 473);
            this.buttonDetain.Name = "buttonDetain";
            this.buttonDetain.Size = new System.Drawing.Size(129, 35);
            this.buttonDetain.TabIndex = 6;
            this.buttonDetain.Text = "Detain";
            this.buttonDetain.UseVisualStyleBackColor = true;
            this.buttonDetain.Click += new System.EventHandler(this.buttonDetain_Click);
            // 
            // textBoxFine
            // 
            this.textBoxFine.Location = new System.Drawing.Point(620, 377);
            this.textBoxFine.Name = "textBoxFine";
            this.textBoxFine.Size = new System.Drawing.Size(65, 24);
            this.textBoxFine.TabIndex = 8;
            // 
            // labelFine
            // 
            this.labelFine.AutoSize = true;
            this.labelFine.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFine.Location = new System.Drawing.Point(446, 379);
            this.labelFine.Name = "labelFine";
            this.labelFine.Size = new System.Drawing.Size(101, 22);
            this.labelFine.TabIndex = 9;
            this.labelFine.Text = "Fine Fees:";
            // 
            // userControlLCImfo1
            // 
            this.userControlLCImfo1.ExpirationDateText = "[????]";
            this.userControlLCImfo1.Location = new System.Drawing.Point(0, 12);
            this.userControlLCImfo1.Name = "userControlLCImfo1";
            this.userControlLCImfo1.Size = new System.Drawing.Size(1075, 443);
            this.userControlLCImfo1.TabIndex = 5;
            this.userControlLCImfo1.Load += new System.EventHandler(this.userControlLCImfo1_Load);
            // 
            // FormDetainLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 525);
            this.Controls.Add(this.labelFine);
            this.Controls.Add(this.textBoxFine);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDetain);
            this.Controls.Add(this.userControlLCImfo1);
            this.Name = "FormDetainLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDetainLicence";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDetain;
        private Licence.UserControlLCImfo userControlLCImfo1;
        private System.Windows.Forms.TextBox textBoxFine;
        private System.Windows.Forms.Label labelFine;
    }
}