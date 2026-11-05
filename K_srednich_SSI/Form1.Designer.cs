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
            label1 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label4 = new Label();
            RTB2 = new RichTextBox();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(651, 282);
            label1.Name = "label1";
            label1.Size = new Size(175, 15);
            label1.TabIndex = 2;
            label1.Text = "Liczba zadeklarowanych iteracji:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(844, 282);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 4;
            label3.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(755, 369);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(674, 369);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(674, 408);
            button3.Name = "button3";
            button3.Size = new Size(76, 25);
            button3.TabIndex = 7;
            button3.Text = "+1 iteracja";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(655, 310);
            label2.Name = "label2";
            label2.Size = new Size(151, 15);
            label2.TabIndex = 8;
            label2.Text = "Liczba wykonanych iteracji:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(825, 310);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 9;
            label4.Text = "0";
            // 
            // RTB2
            // 
            RTB2.Location = new Point(668, 128);
            RTB2.Name = "RTB2";
            RTB2.Size = new Size(184, 138);
            RTB2.TabIndex = 10;
            RTB2.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(910, 510);
            Controls.Add(RTB2);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(RTB1);
            Controls.Add(PB1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PB1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PB1;
        private RichTextBox RTB1;
        private Label label1;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label4;
        private RichTextBox RTB2;
    }
}
