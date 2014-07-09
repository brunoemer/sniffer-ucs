namespace SnifferRedes2
{
    partial class UserControlDiagrama
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelIPEsquerda = new System.Windows.Forms.Label();
            this.labellabelIPDireita = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(135, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 474);
            this.panel1.TabIndex = 1;
            // 
            // labelIPEsquerda
            // 
            this.labelIPEsquerda.Location = new System.Drawing.Point(0, 311);
            this.labelIPEsquerda.Name = "labelIPEsquerda";
            this.labelIPEsquerda.Size = new System.Drawing.Size(129, 22);
            this.labelIPEsquerda.TabIndex = 4;
            // 
            // labellabelIPDireita
            // 
            this.labellabelIPDireita.Location = new System.Drawing.Point(488, 311);
            this.labellabelIPDireita.Name = "labellabelIPDireita";
            this.labellabelIPDireita.Size = new System.Drawing.Size(126, 22);
            this.labellabelIPDireita.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SnifferRedes2.Properties.Resources.computador;
            this.pictureBox2.Location = new System.Drawing.Point(488, 191);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(126, 113);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SnifferRedes2.Properties.Resources.computador;
            this.pictureBox1.Location = new System.Drawing.Point(0, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // UserControlDiagrama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labellabelIPDireita);
            this.Controls.Add(this.labelIPEsquerda);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "UserControlDiagrama";
            this.Size = new System.Drawing.Size(625, 480);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelIPEsquerda;
        private System.Windows.Forms.Label labellabelIPDireita;
    }
}
