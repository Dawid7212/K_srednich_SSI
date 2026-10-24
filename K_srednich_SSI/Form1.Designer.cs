namespace K_srednich_SSI
{
    partial class Form1
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
            PB1 = new PictureBox();
            RTB1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)PB1).BeginInit();
            SuspendLayout();
            // 
            // PB1
            // 
            PB1.BackColor = SystemColors.ControlLightLight;
            PB1.Location = new Point(10, 14);
            PB1.Margin = new Padding(3, 2, 3, 2);
            PB1.Name = "PB1";
            PB1.Size = new Size(613, 479);
            PB1.TabIndex = 0;
            PB1.TabStop = false;
            PB1.Paint += NarysujPunkty;
            // 
            // RTB1
            // 
            RTB1.Location = new Point(668, 14);
            RTB1.Margin = new Padding(3, 2, 3, 2);
            RTB1.Name = "RTB1";
            RTB1.Size = new Size(184, 109);
            RTB1.TabIndex = 1;
            RTB1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(910, 510);
            Controls.Add(RTB1);
            Controls.Add(PB1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PB1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PB1;
        private RichTextBox RTB1;
    }
}
