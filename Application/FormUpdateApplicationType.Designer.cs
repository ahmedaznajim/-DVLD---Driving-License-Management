namespace DVLI
{
    partial class FormUpdateApplicationType
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
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxApplicationTypeTitle = new System.Windows.Forms.TextBox();
            this.textBoxApplicationFees = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = " Application Type ID";
            // 
            // textBoxApplicationTypeTitle
            // 
            this.textBoxApplicationTypeTitle.Location = new System.Drawing.Point(141, 79);
            this.textBoxApplicationTypeTitle.Name = "textBoxApplicationTypeTitle";
            this.textBoxApplicationTypeTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxApplicationTypeTitle.TabIndex = 65;
            // 
            // textBoxApplicationFees
            // 
            this.textBoxApplicationFees.Location = new System.Drawing.Point(141, 119);
            this.textBoxApplicationFees.Name = "textBoxApplicationFees";
            this.textBoxApplicationFees.Size = new System.Drawing.Size(100, 20);
            this.textBoxApplicationFees.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Application Fees";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Application Type Title";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(138, 46);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(17, 13);
            this.labelId.TabIndex = 68;
            this.labelId.Text = "??";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(166, 161);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 69;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormUpdateApplicationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 196);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxApplicationTypeTitle);
            this.Controls.Add(this.textBoxApplicationFees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormUpdateApplicationType";
            this.Text = "FormUpdateApplicationType";
            this.Load += new System.EventHandler(this.FormUpdateApplicationType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxApplicationTypeTitle;
        private System.Windows.Forms.TextBox textBoxApplicationFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button buttonUpdate;
    }
}