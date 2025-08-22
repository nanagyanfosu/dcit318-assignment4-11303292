namespace MedicalApp
{
    partial class MainForm
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
            this.btnDoctors = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDoctors
            // 
            this.btnDoctors.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDoctors.Location = new System.Drawing.Point(268, 108);
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.Size = new System.Drawing.Size(178, 53);
            this.btnDoctors.TabIndex = 0;
            this.btnDoctors.Text = "View Doctors";
            this.btnDoctors.UseVisualStyleBackColor = false;
            this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBook.Location = new System.Drawing.Point(33, 197);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(176, 59);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Book Appointment";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnManage
            // 
            this.btnManage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnManage.Location = new System.Drawing.Point(486, 197);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(188, 59);
            this.btnManage.TabIndex = 2;
            this.btnManage.Text = "Manage Appointments";
            this.btnManage.UseVisualStyleBackColor = false;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome to Nyame Ye Medical Booking System ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(734, 382);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnDoctors);
            this.Name = "MainForm";
            this.Text = "Medical Booking App";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoctors;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Label label1;
    }
}

