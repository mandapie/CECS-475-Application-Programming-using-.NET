namespace Membership_Maintenance_Form
{
    partial class AddMForm
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
            this.FNameLabel = new System.Windows.Forms.Label();
            this.LNameLabel = new System.Windows.Forms.Label();
            this.FNameBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LNameBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FNameLabel
            // 
            this.FNameLabel.AutoSize = true;
            this.FNameLabel.Location = new System.Drawing.Point(13, 13);
            this.FNameLabel.Name = "FNameLabel";
            this.FNameLabel.Size = new System.Drawing.Size(60, 13);
            this.FNameLabel.TabIndex = 0;
            this.FNameLabel.Text = "First Name:";
            // 
            // LNameLabel
            // 
            this.LNameLabel.AutoSize = true;
            this.LNameLabel.Location = new System.Drawing.Point(12, 43);
            this.LNameLabel.Name = "LNameLabel";
            this.LNameLabel.Size = new System.Drawing.Size(61, 13);
            this.LNameLabel.TabIndex = 1;
            this.LNameLabel.Text = "Last Name:";
            // 
            // FNameBox
            // 
            this.FNameBox.Location = new System.Drawing.Point(80, 13);
            this.FNameBox.Name = "FNameBox";
            this.FNameBox.Size = new System.Drawing.Size(198, 20);
            this.FNameBox.TabIndex = 2;
            this.FNameBox.TextChanged += new System.EventHandler(this.FNameBox_TextChanged);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(13, 70);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 5;
            this.EmailLabel.Text = "Email:";
            // 
            // LNameBox
            // 
            this.LNameBox.Location = new System.Drawing.Point(79, 40);
            this.LNameBox.Name = "LNameBox";
            this.LNameBox.Size = new System.Drawing.Size(199, 20);
            this.LNameBox.TabIndex = 6;
            this.LNameBox.TextChanged += new System.EventHandler(this.LNameBox_TextChanged);
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(79, 67);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(199, 20);
            this.EmailBox.TabIndex = 7;
            this.EmailBox.TextChanged += new System.EventHandler(this.EmailBox_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(122, 98);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(204, 98);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 133);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.LNameBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.FNameBox);
            this.Controls.Add(this.LNameLabel);
            this.Controls.Add(this.FNameLabel);
            this.Name = "AddMForm";
            this.Text = "Add Membership";
            this.Load += new System.EventHandler(this.AddMForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FNameLabel;
        private System.Windows.Forms.Label LNameLabel;
        private System.Windows.Forms.TextBox FNameBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox LNameBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}