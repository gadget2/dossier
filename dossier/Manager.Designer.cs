namespace dossier
{
    partial class Manager
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
            this.passiveHPLabel = new System.Windows.Forms.Label();
            this.passiveGoldLabel = new System.Windows.Forms.Label();
            this.passiveEXPLabel = new System.Windows.Forms.Label();
            this.passiveLVLLabel = new System.Windows.Forms.Label();
            this.labelHP = new System.Windows.Forms.Label();
            this.labelGold = new System.Windows.Forms.Label();
            this.labelEXP = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passiveHPLabel
            // 
            this.passiveHPLabel.AutoSize = true;
            this.passiveHPLabel.Location = new System.Drawing.Point(18, 20);
            this.passiveHPLabel.Name = "passiveHPLabel";
            this.passiveHPLabel.Size = new System.Drawing.Size(25, 13);
            this.passiveHPLabel.TabIndex = 0;
            this.passiveHPLabel.Text = "HP:";
            // 
            // passiveGoldLabel
            // 
            this.passiveGoldLabel.AutoSize = true;
            this.passiveGoldLabel.Location = new System.Drawing.Point(18, 46);
            this.passiveGoldLabel.Name = "passiveGoldLabel";
            this.passiveGoldLabel.Size = new System.Drawing.Size(35, 13);
            this.passiveGoldLabel.TabIndex = 1;
            this.passiveGoldLabel.Text = "Gold: ";
            // 
            // passiveEXPLabel
            // 
            this.passiveEXPLabel.AutoSize = true;
            this.passiveEXPLabel.Location = new System.Drawing.Point(18, 74);
            this.passiveEXPLabel.Name = "passiveEXPLabel";
            this.passiveEXPLabel.Size = new System.Drawing.Size(34, 13);
            this.passiveEXPLabel.TabIndex = 2;
            this.passiveEXPLabel.Text = "EXP: ";
            // 
            // passiveLVLLabel
            // 
            this.passiveLVLLabel.AutoSize = true;
            this.passiveLVLLabel.Location = new System.Drawing.Point(18, 100);
            this.passiveLVLLabel.Name = "passiveLVLLabel";
            this.passiveLVLLabel.Size = new System.Drawing.Size(26, 13);
            this.passiveLVLLabel.TabIndex = 3;
            this.passiveLVLLabel.Text = "LV: ";
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Location = new System.Drawing.Point(110, 19);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(0, 13);
            this.labelHP.TabIndex = 4;
            // 
            // labelGold
            // 
            this.labelGold.AutoSize = true;
            this.labelGold.Location = new System.Drawing.Point(110, 45);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(0, 13);
            this.labelGold.TabIndex = 5;
            // 
            // labelEXP
            // 
            this.labelEXP.AutoSize = true;
            this.labelEXP.Location = new System.Drawing.Point(110, 73);
            this.labelEXP.Name = "labelEXP";
            this.labelEXP.Size = new System.Drawing.Size(0, 13);
            this.labelEXP.TabIndex = 6;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(110, 99);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(0, 13);
            this.labelLevel.TabIndex = 7;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelEXP);
            this.Controls.Add(this.labelGold);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.passiveLVLLabel);
            this.Controls.Add(this.passiveEXPLabel);
            this.Controls.Add(this.passiveGoldLabel);
            this.Controls.Add(this.passiveHPLabel);
            this.Name = "Manager";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passiveHPLabel;
        private System.Windows.Forms.Label passiveGoldLabel;
        private System.Windows.Forms.Label passiveEXPLabel;
        private System.Windows.Forms.Label passiveLVLLabel;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.Label labelEXP;
        private System.Windows.Forms.Label labelLevel;
    }
}

