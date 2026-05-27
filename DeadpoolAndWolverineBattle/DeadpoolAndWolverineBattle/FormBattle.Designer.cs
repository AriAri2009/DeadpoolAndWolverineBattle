namespace DeadpoolAndWolverineBattle
{
    partial class FormBattle
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            pic_D = new PictureBox();
            pic_W = new PictureBox();
            lbl_pDead = new Label();
            lbl_pWol = new Label();
            label4 = new Label();
            btn_Pelear = new Button();
            txt_Desarrollo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pic_D).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_W).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Muthiara -Demo Version-", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(414, 41);
            label1.Name = "label1";
            label1.Size = new Size(345, 47);
            label1.TabIndex = 0;
            label1.Text = "Deadpool VS Wolverine";
            // 
            // pic_D
            // 
            pic_D.Image = Properties.Resources.QuietoDeadpool;
            pic_D.Location = new Point(176, 160);
            pic_D.Name = "pic_D";
            pic_D.Size = new Size(343, 357);
            pic_D.SizeMode = PictureBoxSizeMode.Zoom;
            pic_D.TabIndex = 1;
            pic_D.TabStop = false;
            // 
            // pic_W
            // 
            pic_W.Image = Properties.Resources.QuietoWolverineOriginal;
            pic_W.Location = new Point(585, 160);
            pic_W.Name = "pic_W";
            pic_W.Size = new Size(343, 357);
            pic_W.SizeMode = PictureBoxSizeMode.Zoom;
            pic_W.TabIndex = 2;
            pic_W.TabStop = false;
            // 
            // lbl_pDead
            // 
            lbl_pDead.AutoSize = true;
            lbl_pDead.Font = new Font("Modern No. 20", 13.7999992F);
            lbl_pDead.Location = new Point(250, 113);
            lbl_pDead.Name = "lbl_pDead";
            lbl_pDead.Size = new Size(189, 25);
            lbl_pDead.TabIndex = 3;
            lbl_pDead.Text = "Deadpool HP: 1000";
            // 
            // lbl_pWol
            // 
            lbl_pWol.AutoSize = true;
            lbl_pWol.Font = new Font("Modern No. 20", 13.7999992F);
            lbl_pWol.Location = new Point(665, 113);
            lbl_pWol.Name = "lbl_pWol";
            lbl_pWol.Size = new Size(198, 25);
            lbl_pWol.TabIndex = 4;
            lbl_pWol.Text = "Wolverine HP: 1000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Modern No. 20", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(366, 554);
            label4.Name = "label4";
            label4.Size = new Size(361, 22);
            label4.TabIndex = 6;
            label4.Text = "Cuando estes listo para pelear ¡dale al botón!";
            // 
            // btn_Pelear
            // 
            btn_Pelear.Font = new Font("Modern No. 20", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Pelear.Location = new Point(438, 606);
            btn_Pelear.Name = "btn_Pelear";
            btn_Pelear.Size = new Size(259, 54);
            btn_Pelear.TabIndex = 7;
            btn_Pelear.Text = "¡Pelea!";
            btn_Pelear.UseVisualStyleBackColor = true;
            btn_Pelear.Click += btn_Pelear_Click;
            // 
            // txt_Desarrollo
            // 
            txt_Desarrollo.Location = new Point(975, 144);
            txt_Desarrollo.Multiline = true;
            txt_Desarrollo.Name = "txt_Desarrollo";
            txt_Desarrollo.ScrollBars = ScrollBars.Vertical;
            txt_Desarrollo.Size = new Size(283, 467);
            txt_Desarrollo.TabIndex = 8;
            txt_Desarrollo.Text = "                              ";
            // 
            // FormBattle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(1294, 766);
            Controls.Add(txt_Desarrollo);
            Controls.Add(btn_Pelear);
            Controls.Add(label4);
            Controls.Add(lbl_pWol);
            Controls.Add(lbl_pDead);
            Controls.Add(pic_W);
            Controls.Add(pic_D);
            Controls.Add(label1);
            Name = "FormBattle";
            Text = "    ";
            ((System.ComponentModel.ISupportInitialize)pic_D).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_W).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pic_D;
        private PictureBox pic_W;
        private Label lbl_pDead;
        private Label lbl_pWol;
        private Label label4;
        private Button btn_Pelear;
        private TextBox txt_Desarrollo;
    }
}
