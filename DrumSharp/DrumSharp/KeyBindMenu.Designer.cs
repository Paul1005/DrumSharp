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
            this.snareBox = new System.Windows.Forms.TextBox();
            this.bassBox = new System.Windows.Forms.TextBox();
            this.highHatBox = new System.Windows.Forms.TextBox();
            this.snareLabel1 = new System.Windows.Forms.Label();
            this.bassLabel1 = new System.Windows.Forms.Label();
            this.highHatLabel1 = new System.Windows.Forms.Label();
            this.done = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.snareLabel2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bassLabel2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.highHatLabel2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // snareBox
            // 
            this.snareBox.Location = new System.Drawing.Point(254, 72);
            this.snareBox.MaxLength = 1;
            this.snareBox.Name = "snareBox";
            this.snareBox.Size = new System.Drawing.Size(100, 29);
            this.snareBox.TabIndex = 0;
            this.snareBox.TextChanged += new System.EventHandler(this.snareBox_TextChanged);
            // 
            // bassBox
            // 
            this.bassBox.Location = new System.Drawing.Point(254, 172);
            this.bassBox.MaxLength = 1;
            this.bassBox.Name = "bassBox";
            this.bassBox.Size = new System.Drawing.Size(100, 29);
            this.bassBox.TabIndex = 1;
            // 
            // highHatBox
            // 
            this.highHatBox.Location = new System.Drawing.Point(254, 283);
            this.highHatBox.MaxLength = 1;
            this.highHatBox.Name = "highHatBox";
            this.highHatBox.Size = new System.Drawing.Size(100, 29);
            this.highHatBox.TabIndex = 2;
            // 
            // snareLabel1
            // 
            this.snareLabel1.AutoSize = true;
            this.snareLabel1.Location = new System.Drawing.Point(78, 72);
            this.snareLabel1.Name = "snareLabel1";
            this.snareLabel1.Size = new System.Drawing.Size(127, 25);
            this.snareLabel1.TabIndex = 3;
            this.snareLabel1.Text = "Snare Key 1:";
            // 
            // bassLabel1
            // 
            this.bassLabel1.AutoSize = true;
            this.bassLabel1.Location = new System.Drawing.Point(83, 172);
            this.bassLabel1.Name = "bassLabel1";
            this.bassLabel1.Size = new System.Drawing.Size(118, 25);
            this.bassLabel1.TabIndex = 4;
            this.bassLabel1.Text = "Bass Key 1:";
            // 
            // highHatLabel1
            // 
            this.highHatLabel1.AutoSize = true;
            this.highHatLabel1.Location = new System.Drawing.Point(83, 287);
            this.highHatLabel1.Name = "highHatLabel1";
            this.highHatLabel1.Size = new System.Drawing.Size(149, 25);
            this.highHatLabel1.TabIndex = 5;
            this.highHatLabel1.Text = "High Hat Key 1:";
            // 
            // done
            // 
            this.done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.done.Location = new System.Drawing.Point(83, 403);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(84, 40);
            this.done.TabIndex = 6;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(268, 403);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(86, 40);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // snareLabel2
            // 
            this.snareLabel2.AutoSize = true;
            this.snareLabel2.Location = new System.Drawing.Point(78, 107);
            this.snareLabel2.Name = "snareLabel2";
            this.snareLabel2.Size = new System.Drawing.Size(127, 25);
            this.snareLabel2.TabIndex = 9;
            this.snareLabel2.Text = "Snare Key 2:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(254, 107);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 8;
            // 
            // bassLabel2
            // 
            this.bassLabel2.AutoSize = true;
            this.bassLabel2.Location = new System.Drawing.Point(83, 207);
            this.bassLabel2.Name = "bassLabel2";
            this.bassLabel2.Size = new System.Drawing.Size(118, 25);
            this.bassLabel2.TabIndex = 11;
            this.bassLabel2.Text = "Bass Key 2:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(254, 207);
            this.textBox2.MaxLength = 1;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 29);
            this.textBox2.TabIndex = 10;
            // 
            // highHatLabel2
            // 
            this.highHatLabel2.AutoSize = true;
            this.highHatLabel2.Location = new System.Drawing.Point(83, 322);
            this.highHatLabel2.Name = "highHatLabel2";
            this.highHatLabel2.Size = new System.Drawing.Size(149, 25);
            this.highHatLabel2.TabIndex = 13;
            this.highHatLabel2.Text = "High Hat Key 2:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(254, 318);
            this.textBox3.MaxLength = 1;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 29);
            this.textBox3.TabIndex = 12;
            // 
            // KeyBindMenu
            // 
            this.AcceptButton = this.done;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(455, 502);
            this.Controls.Add(this.highHatLabel2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.bassLabel2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.snareLabel2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.done);
            this.Controls.Add(this.highHatLabel1);
            this.Controls.Add(this.bassLabel1);
            this.Controls.Add(this.snareLabel1);
            this.Controls.Add(this.highHatBox);
            this.Controls.Add(this.bassBox);
            this.Controls.Add(this.snareBox);
            this.Name = "KeyBindMenu";
            this.Text = "KeyBindMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox snareBox;
        private System.Windows.Forms.TextBox bassBox;
        private System.Windows.Forms.TextBox highHatBox;
        private System.Windows.Forms.Label snareLabel1;
        private System.Windows.Forms.Label bassLabel1;
        private System.Windows.Forms.Label highHatLabel1;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label snareLabel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label bassLabel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label highHatLabel2;
        private System.Windows.Forms.TextBox textBox3;
    }
}