namespace DrumSharp
{
    partial class KeyBindMenu
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
            this.snareBox1 = new System.Windows.Forms.TextBox();
            this.snareBox2 = new System.Windows.Forms.TextBox();
            this.bassBox1 = new System.Windows.Forms.TextBox();
            this.bassBox2 = new System.Windows.Forms.TextBox();
            this.highHatBox1 = new System.Windows.Forms.TextBox();
            this.highHatBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // snareBox1
            // 
            this.snareBox1.Location = new System.Drawing.Point(271, 70);
            this.snareBox1.Name = "snareBox1";
            this.snareBox1.Size = new System.Drawing.Size(100, 29);
            this.snareBox1.TabIndex = 0;
            // 
            // snareBox2
            // 
            this.snareBox2.Location = new System.Drawing.Point(271, 106);
            this.snareBox2.Name = "snareBox2";
            this.snareBox2.Size = new System.Drawing.Size(100, 29);
            this.snareBox2.TabIndex = 1;
            // 
            // bassBox1
            // 
            this.bassBox1.Location = new System.Drawing.Point(271, 202);
            this.bassBox1.Name = "bassBox1";
            this.bassBox1.Size = new System.Drawing.Size(100, 29);
            this.bassBox1.TabIndex = 2;
            // 
            // bassBox2
            // 
            this.bassBox2.Location = new System.Drawing.Point(271, 237);
            this.bassBox2.Name = "bassBox2";
            this.bassBox2.Size = new System.Drawing.Size(100, 29);
            this.bassBox2.TabIndex = 3;
            // 
            // highHatBox1
            // 
            this.highHatBox1.Location = new System.Drawing.Point(271, 338);
            this.highHatBox1.Name = "highHatBox1";
            this.highHatBox1.Size = new System.Drawing.Size(100, 29);
            this.highHatBox1.TabIndex = 4;
            // 
            // highHatBox2
            // 
            this.highHatBox2.Location = new System.Drawing.Point(271, 374);
            this.highHatBox2.Name = "highHatBox2";
            this.highHatBox2.Size = new System.Drawing.Size(100, 29);
            this.highHatBox2.TabIndex = 5;
            // 
            // KeyBindMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 567);
            this.Controls.Add(this.highHatBox2);
            this.Controls.Add(this.highHatBox1);
            this.Controls.Add(this.bassBox2);
            this.Controls.Add(this.bassBox1);
            this.Controls.Add(this.snareBox2);
            this.Controls.Add(this.snareBox1);
            this.Name = "KeyBindMenu";
            this.Text = "KeyBindMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox snareBox1;
        private System.Windows.Forms.TextBox snareBox2;
        private System.Windows.Forms.TextBox bassBox1;
        private System.Windows.Forms.TextBox bassBox2;
        private System.Windows.Forms.TextBox highHatBox1;
        private System.Windows.Forms.TextBox highHatBox2;
    }
}