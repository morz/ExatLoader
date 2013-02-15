namespace ExatLoader
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LPT1Chekbox = new System.Windows.Forms.CheckBox();
            this.LPT2Chekbox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LPT1Chekbox
            // 
            this.LPT1Chekbox.AutoCheck = false;
            this.LPT1Chekbox.AutoSize = true;
            this.LPT1Chekbox.Enabled = false;
            this.LPT1Chekbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LPT1Chekbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LPT1Chekbox.Location = new System.Drawing.Point(718, 359);
            this.LPT1Chekbox.Margin = new System.Windows.Forms.Padding(0);
            this.LPT1Chekbox.Name = "LPT1Chekbox";
            this.LPT1Chekbox.Size = new System.Drawing.Size(62, 24);
            this.LPT1Chekbox.TabIndex = 1;
            this.LPT1Chekbox.Tag = "888";
            this.LPT1Chekbox.Text = "LPT1";
            this.LPT1Chekbox.UseVisualStyleBackColor = true;
            this.LPT1Chekbox.CheckedChanged += new System.EventHandler(this.UseLpt1_CheckedChanged);
            // 
            // LPT2Chekbox
            // 
            this.LPT2Chekbox.AutoCheck = false;
            this.LPT2Chekbox.AutoSize = true;
            this.LPT2Chekbox.Enabled = false;
            this.LPT2Chekbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LPT2Chekbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LPT2Chekbox.Location = new System.Drawing.Point(718, 378);
            this.LPT2Chekbox.Margin = new System.Windows.Forms.Padding(0);
            this.LPT2Chekbox.Name = "LPT2Chekbox";
            this.LPT2Chekbox.Size = new System.Drawing.Size(62, 24);
            this.LPT2Chekbox.TabIndex = 1;
            this.LPT2Chekbox.Tag = "632";
            this.LPT2Chekbox.Text = "LPT2";
            this.LPT2Chekbox.UseVisualStyleBackColor = true;
            this.LPT2Chekbox.CheckedChanged += new System.EventHandler(this.UseLpt2_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(1, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(782, 354);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.326";
            this.openFileDialog.Filter = "\"Exat Files|*.326\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "<F3> - Открыть файл";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 419);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LPT2Chekbox);
            this.Controls.Add(this.LPT1Chekbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExatLoader for Windows";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox LPT1Chekbox;
        private System.Windows.Forms.CheckBox LPT2Chekbox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
    }
}

