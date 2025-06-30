namespace Viztangent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            Heading = new Label();
            submitButton = new Button();
            panel1 = new Panel();
            userInput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(19, 66);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(225, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Heading
            // 
            Heading.Anchor = AnchorStyles.None;
            Heading.AutoSize = true;
            Heading.BackColor = Color.Transparent;
            Heading.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            Heading.ForeColor = SystemColors.ControlLightLight;
            Heading.Location = new Point(300, 9);
            Heading.Name = "Heading";
            Heading.Size = new Size(513, 54);
            Heading.TabIndex = 1;
            Heading.Text = "Define Your Area of Interest";
            Heading.TextAlign = ContentAlignment.TopCenter;
            // 
            // submitButton
            // 
            submitButton.Anchor = AnchorStyles.None;
            submitButton.BackColor = Color.DodgerBlue;
            submitButton.FlatAppearance.BorderColor = Color.Black;
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitButton.ForeColor = SystemColors.ControlLightLight;
            submitButton.Location = new Point(791, 394);
            submitButton.Margin = new Padding(0);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(86, 53);
            submitButton.TabIndex = 5;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.AutoScroll = true;
            panel1.Location = new Point(272, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(603, 310);
            panel1.TabIndex = 6;
            // 
            // userInput
            // 
            userInput.Anchor = AnchorStyles.None;
            userInput.Location = new Point(272, 394);
            userInput.Multiline = true;
            userInput.Name = "userInput";
            userInput.Size = new Size(516, 53);
            userInput.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.BackGroundImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(944, 481);
            Controls.Add(userInput);
            Controls.Add(panel1);
            Controls.Add(submitButton);
            Controls.Add(Heading);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Viztangent";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label Heading;
        private Button submitButton;
        private Panel panel1;
        private TextBox userInput;
    }
}
