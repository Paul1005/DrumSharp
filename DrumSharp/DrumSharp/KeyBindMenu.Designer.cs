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
            this.doneButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // snareBox1
            // 
            this.snareBox1.Location = new System.Drawing.Point(271, 70);
            this.snareBox1.MaxLength = 1;
            this.snareBox1.Name = "snareBox1";
            this.snareBox1.Size = new System.Drawing.Size(100, 29);
            this.snareBox1.TabIndex = 0;
            this.snareBox1.Enter += new System.EventHandler(this.textBox_Enter);
            this.snareBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxKeydown);
            // 
            // snareBox2
            // 
            this.snareBox2.Location = new System.Drawing.Point(271, 106);
            this.snareBox2.MaxLength = 1;
            this.snareBox2.Name = "snareBox2";
            this.snareBox2.Size = new System.Drawing.Size(100, 29);
            this.snareBox2.TabIndex = 1;
            this.snareBox2.Enter += new System.EventHandler(this.textBox_Enter);
            this.snareBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxKeydown);
            // 
            // bassBox1
            // 
            this.bassBox1.Location = new System.Drawing.Point(271, 202);
            this.bassBox1.MaxLength = 1;
            this.bassBox1.Name = "bassBox1";
            this.bassBox1.Size = new System.Drawing.Size(100, 29);
            this.bassBox1.TabIndex = 2;
            this.bassBox1.Enter += new System.EventHandler(this.textBox_Enter);
            this.bassBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxKeydown);
            // 
            // bassBox2
            // 
            this.bassBox2.Location = new System.Drawing.Point(271, 237);
            this.bassBox2.MaxLength = 1;
            this.bassBox2.Name = "bassBox2";
            this.bassBox2.Size = new System.Drawing.Size(100, 29);
            this.bassBox2.TabIndex = 3;
            this.bassBox2.Enter += new System.EventHandler(this.textBox_Enter);
            this.bassBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxKeydown);
            // 
            // highHatBox1
            // 
            this.highHatBox1.Location = new System.Drawing.Point(271, 338);
            this.highHatBox1.MaxLength = 1;
            this.highHatBox1.Name = "highHatBox1";
            this.highHatBox1.Size = new System.Drawing.Size(100, 29);
            this.highHatBox1.TabIndex = 4;
            this.highHatBox1.Enter += new System.EventHandler(this.textBox_Enter);
            this.highHatBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxKeydown);
            // 
            // highHatBox2
            // 
            this.highHatBox2.Location = new System.Drawing.Point(271, 374);
            this.highHatBox2.MaxLength = 1;
            this.highHatBox2.Name = "highHatBox2";
            this.highHatBox2.Size = new System.Drawing.Size(100, 29);
            this.highHatBox2.TabIndex = 5;
            this.highHatBox2.Enter += new System.EventHandler(this.textBox_Enter);
            this.highHatBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxKeydown);
            // 
            // doneButton
            // 
            this.doneButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.doneButton.Location = new System.Drawing.Point(169, 467);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(96, 44);
            this.doneButton.TabIndex = 6;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Snare Key 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Snare Key 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bass Key 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bass Key 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "HighHat Key 1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "HighHat Key 1:";
            // 
            // KeyBindMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 567);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doneButton);
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
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}