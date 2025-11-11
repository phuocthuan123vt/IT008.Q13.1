namespace Bai02
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
            Refresh_Button = new Button();
            SuspendLayout();
            // 
            // Refresh_Button
            // 
            Refresh_Button.AutoSize = true;
            Refresh_Button.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Refresh_Button.Location = new Point(343, 173);
            Refresh_Button.Name = "Refresh_Button";
            Refresh_Button.Size = new Size(112, 40);
            Refresh_Button.TabIndex = 0;
            Refresh_Button.Text = "Vẽ lại";
            Refresh_Button.UseVisualStyleBackColor = true;
            Refresh_Button.Click += Refresh_Button_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Refresh_Button);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Refresh_Button;
    }
}
