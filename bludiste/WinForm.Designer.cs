namespace bludiste
{
    partial class WinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Impact", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(208, 79);
            label1.Name = "label1";
            label1.Size = new Size(191, 45);
            label1.TabIndex = 1;
            label1.Text = "VYHRÁL JSI";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Info;
            button1.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(242, 180);
            button1.Name = "button1";
            button1.Size = new Size(122, 62);
            button1.TabIndex = 2;
            button1.Text = "HRÁT ZNOVA";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Info;
            button2.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(242, 299);
            button2.Name = "button2";
            button2.Size = new Size(122, 62);
            button2.TabIndex = 3;
            button2.Text = "MENU";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // WinForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(612, 549);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "WinForm";
            Text = "WinForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
    }
}