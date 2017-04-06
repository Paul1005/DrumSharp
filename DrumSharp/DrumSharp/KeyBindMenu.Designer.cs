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
            this.bassBox1 = new System.Windows.Forms.TextBox();
            this.cymbolBox1 = new System.Windows.Forms.TextBox();
            this.snareLabel1 = new System.Windows.Forms.Label();
            this.bassLabel1 = new System.Windows.Forms.Label();
            this.highHatLabel1 = new System.Windows.Forms.Label();
            this.done = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.snareLabel2 = new System.Windows.Forms.Label();
            this.snareBox2 = new System.Windows.Forms.TextBox();
            this.bassLabel2 = new System.Windows.Forms.Label();
            this.bassBox2 = new System.Windows.Forms.TextBox();
            this.highHatLabel2 = new System.Windows.Forms.Label();
            this.cymbolBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // snareBox1
            // 
            this.snareBox1.Location = new System.Drawing.Point(254, 72);
            this.snareBox1.MaxLength = 1;
            this.snareBox1.Name = "snareBox1";
            this.snareBox1.Size = new System.Drawing.Size(100, 29);
            this.snareBox1.TabIndex = 0;
            this.snareBox1.TextChanged += new System.EventHandler(this.textboxChanged);
            // 
            // bassBox1
            // 
            this.bassBox1.Location = new System.Drawing.Point(254, 172);
            this.bassBox1.MaxLength = 1;
            this.bassBox1.Name = "bassBox1";
            this.bassBox1.Size = new System.Drawing.Size(100, 29);
            this.bassBox1.TabIndex = 1;
            this.bassBox1.TextChanged += new System.EventHandler(this.textboxChanged);
            // 
            // cymbolBox1
            // 
            this.cymbolBox1.Location = new System.Drawing.Point(254, 283);
            this.cymbolBox1.MaxLength = 1;
            this.cymbolBox1.Name = "cymbolBox1";
            this.cymbolBox1.Size = new System.Drawing.Size(100, 29);
            this.cymbolBox1.TabIndex = 2;
            this.cymbolBox1.TextChanged += new System.EventHandler(this.textboxChanged);
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
            // snareBox2
            // 
            this.snareBox2.Location = new System.Drawing.Point(254, 107);
            this.snareBox2.MaxLength = 1;
            this.snareBox2.Name = "snareBox2";
            this.snareBox2.Size = new System.Drawing.Size(100, 29);
            this.snareBox2.TabIndex = 8;
            this.snareBox2.TextChanged += new System.EventHandler(this.textboxChanged);
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
            // bassBox2
            // 
            this.bassBox2.Location = new System.Drawing.Point(254, 207);
            this.bassBox2.MaxLength = 1;
            this.bassBox2.Name = "bassBox2";
            this.bassBox2.Size = new System.Drawing.Size(100, 29);
            this.bassBox2.TabIndex = 10;
            this.bassBox2.TextChanged += new System.EventHandler(this.textboxChanged);
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
            // cymbolBox2
            // 
            this.cymbolBox2.Location = new System.Drawing.Point(254, 318);
            this.cymbolBox2.MaxLength = 1;
            this.cymbolBox2.Name = "cymbolBox2";
            this.cymbolBox2.Size = new System.Drawing.Size(100, 29);
            this.cymbolBox2.TabIndex = 12;
            this.cymbolBox2.TextChanged += new System.EventHandler(this.textboxChanged);
            // 
            // KeyBindMenu
            // 
            this.AcceptButton = this.done;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(455, 502);
            this.Controls.Add(this.highHatLabel2);
            this.Controls.Add(this.cymbolBox2);
            this.Controls.Add(this.bassLabel2);
            this.Controls.Add(this.bassBox2);
            this.Controls.Add(this.snareLabel2);
            this.Controls.Add(this.snareBox2);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.done);
            this.Controls.Add(this.highHatLabel1);
            this.Controls.Add(this.bassLabel1);
            this.Controls.Add(this.snareLabel1);
            this.Controls.Add(this.cymbolBox1);
            this.Controls.Add(this.bassBox1);
            this.Controls.Add(this.snareBox1);
            this.Name = "KeyBindMenu";
            this.Text = "KeyBindMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox snareBox1;
        private System.Windows.Forms.TextBox bassBox1;
        private System.Windows.Forms.TextBox cymbolBox1;
        private System.Windows.Forms.Label snareLabel1;
        private System.Windows.Forms.Label bassLabel1;
        private System.Windows.Forms.Label highHatLabel1;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label snareLabel2;
        private System.Windows.Forms.TextBox snareBox2;
        private System.Windows.Forms.Label bassLabel2;
        private System.Windows.Forms.TextBox bassBox2;
        private System.Windows.Forms.Label highHatLabel2;
        private System.Windows.Forms.TextBox cymbolBox2;
    }
}