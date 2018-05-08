namespace KiyoskWall
{
    partial class ReservePerMeal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReserved = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.btnQuickReserved = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeleteReserved = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteReserved)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnDeleteReserved);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnQuickReserved);
            this.panel1.Controls.Add(this.lblReserved);
            this.panel1.Controls.Add(this.lbDate);
            this.panel1.Controls.Add(this.btnNextDay);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.lbl3);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.pic3);
            this.panel1.Controls.Add(this.pic2);
            this.panel1.Controls.Add(this.pic1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1264, 788);
            this.panel1.TabIndex = 0;
            // 
            // lblReserved
            // 
            this.lblReserved.AllowDrop = true;
            this.lblReserved.BackColor = System.Drawing.Color.Transparent;
            this.lblReserved.Font = new System.Drawing.Font("B Mitra", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblReserved.Location = new System.Drawing.Point(820, 595);
            this.lblReserved.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReserved.Name = "lblReserved";
            this.lblReserved.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReserved.Size = new System.Drawing.Size(302, 115);
            this.lblReserved.TabIndex = 16;
            this.lblReserved.Text = "label1";
            this.lblReserved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDate
            // 
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("B Mitra", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbDate.Location = new System.Drawing.Point(373, 28);
            this.lbDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbDate.Size = new System.Drawing.Size(634, 122);
            this.lbDate.TabIndex = 15;
            this.lbDate.Text = "تاریخ";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextDay
            // 
            this.btnNextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextDay.BackgroundImage = global::KiyoskWall.Resource1.lunch;
            this.btnNextDay.Font = new System.Drawing.Font("B Titr", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNextDay.Location = new System.Drawing.Point(113, 28);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(131, 87);
            this.btnNextDay.TabIndex = 14;
            this.btnNextDay.Text = "روز بعد";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.BackgroundImage = global::KiyoskWall.Resource1.lunch;
            this.btnPrevious.Font = new System.Drawing.Font("B Titr", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrevious.Location = new System.Drawing.Point(1078, 35);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(134, 80);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Text = "روز قبل";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lbl3
            // 
            this.lbl3.AllowDrop = true;
            this.lbl3.BackColor = System.Drawing.Color.Transparent;
            this.lbl3.Font = new System.Drawing.Font("B Mitra", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl3.Location = new System.Drawing.Point(66, 191);
            this.lbl3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl3.Size = new System.Drawing.Size(302, 115);
            this.lbl3.TabIndex = 6;
            this.lbl3.Text = "label3";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbl2
            // 
            this.lbl2.AllowDrop = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("B Mitra", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl2.Location = new System.Drawing.Point(474, 191);
            this.lbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl2.Size = new System.Drawing.Size(302, 115);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "label2";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbl1
            // 
            this.lbl1.AllowDrop = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("B Mitra", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl1.Location = new System.Drawing.Point(899, 191);
            this.lbl1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl1.Size = new System.Drawing.Size(302, 115);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "label1";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pic3
            // 
            this.pic3.BackColor = System.Drawing.Color.Transparent;
            this.pic3.Location = new System.Drawing.Point(66, 331);
            this.pic3.Margin = new System.Windows.Forms.Padding(25);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(302, 204);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic3.TabIndex = 3;
            this.pic3.TabStop = false;
            this.pic3.Click += new System.EventHandler(this.pic3_Click);
            // 
            // pic2
            // 
            this.pic2.BackColor = System.Drawing.Color.Transparent;
            this.pic2.Location = new System.Drawing.Point(474, 331);
            this.pic2.Margin = new System.Windows.Forms.Padding(25);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(302, 204);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 2;
            this.pic2.TabStop = false;
            this.pic2.Click += new System.EventHandler(this.pic2_Click);
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.Color.Transparent;
            this.pic1.Location = new System.Drawing.Point(899, 331);
            this.pic1.Margin = new System.Windows.Forms.Padding(25);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(302, 204);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 1;
            this.pic1.TabStop = false;
            this.pic1.Click += new System.EventHandler(this.pic1_Click);
            // 
            // btnQuickReserved
            // 
            this.btnQuickReserved.BackgroundImage = global::KiyoskWall.Resource1.lunch;
            this.btnQuickReserved.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnQuickReserved.FlatAppearance.BorderSize = 0;
            this.btnQuickReserved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReserved.Font = new System.Drawing.Font("B Mitra", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnQuickReserved.Location = new System.Drawing.Point(430, 612);
            this.btnQuickReserved.Name = "btnQuickReserved";
            this.btnQuickReserved.Size = new System.Drawing.Size(346, 83);
            this.btnQuickReserved.TabIndex = 17;
            this.btnQuickReserved.Text = "رزرو سریع";
            this.btnQuickReserved.UseVisualStyleBackColor = true;
            this.btnQuickReserved.Click += new System.EventHandler(this.btnQuickReserved_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::KiyoskWall.Resource1.lunch;
            this.button1.Font = new System.Drawing.Font("B Mitra", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(66, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 83);
            this.button1.TabIndex = 18;
            this.button1.Text = "بستن";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteReserved
            // 
            this.btnDeleteReserved.Image = global::KiyoskWall.Resource1.Close_Box_Red;
            this.btnDeleteReserved.Location = new System.Drawing.Point(1127, 625);
            this.btnDeleteReserved.Name = "btnDeleteReserved";
            this.btnDeleteReserved.Size = new System.Drawing.Size(54, 52);
            this.btnDeleteReserved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDeleteReserved.TabIndex = 19;
            this.btnDeleteReserved.TabStop = false;
            this.btnDeleteReserved.Visible = false;
            this.btnDeleteReserved.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ReservePerMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KiyoskWall.Resource1.blue;
            this.ClientSize = new System.Drawing.Size(1264, 788);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReservePerMeal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReservePerMeal";
            this.Load += new System.EventHandler(this.ReservePerMeal_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteReserved)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lblReserved;
        private System.Windows.Forms.Button btnQuickReserved;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox btnDeleteReserved;
    }
}