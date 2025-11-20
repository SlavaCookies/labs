namespace ADFGVX
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.toCreateShifr = new System.Windows.Forms.Button();
            this.toNotShifr = new System.Windows.Forms.Button();
            this.labelBasicText = new System.Windows.Forms.Label();
            this.textBasic = new System.Windows.Forms.TextBox();
            this.textShifr = new System.Windows.Forms.TextBox();
            this.labelShifr = new System.Windows.Forms.Label();
            this.matrixSymbolsText = new System.Windows.Forms.TextBox();
            this.matrixSymbolsLabel = new System.Windows.Forms.Label();
            this.secretWord = new System.Windows.Forms.TextBox();
            this.secretWordLabel = new System.Windows.Forms.Label();
            this.notShifrText = new System.Windows.Forms.TextBox();
            this.notShifrLabel = new System.Windows.Forms.Label();
            this._labelCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toCreateShifr
            // 
            this.toCreateShifr.BackColor = System.Drawing.Color.Lime;
            this.toCreateShifr.ForeColor = System.Drawing.Color.Black;
            this.toCreateShifr.Location = new System.Drawing.Point(23, 243);
            this.toCreateShifr.Name = "toCreateShifr";
            this.toCreateShifr.Size = new System.Drawing.Size(157, 49);
            this.toCreateShifr.TabIndex = 0;
            this.toCreateShifr.Text = "Зашифровать";
            this.toCreateShifr.UseVisualStyleBackColor = false;
            this.toCreateShifr.Click += new System.EventHandler(this.toCreateShifr_Click);
            // 
            // toNotShifr
            // 
            this.toNotShifr.BackColor = System.Drawing.Color.Red;
            this.toNotShifr.Location = new System.Drawing.Point(23, 309);
            this.toNotShifr.Name = "toNotShifr";
            this.toNotShifr.Size = new System.Drawing.Size(157, 52);
            this.toNotShifr.TabIndex = 1;
            this.toNotShifr.Text = "Расшифровать";
            this.toNotShifr.UseVisualStyleBackColor = false;
            this.toNotShifr.Click += new System.EventHandler(this.toNotShifr_Click);
            // 
            // labelBasicText
            // 
            this.labelBasicText.AutoSize = true;
            this.labelBasicText.Location = new System.Drawing.Point(45, 9);
            this.labelBasicText.Name = "labelBasicText";
            this.labelBasicText.Size = new System.Drawing.Size(303, 16);
            this.labelBasicText.TabIndex = 2;
            this.labelBasicText.Text = "Введите текст, который нужно зашифровать:";
            // 
            // textBasic
            // 
            this.textBasic.Location = new System.Drawing.Point(48, 44);
            this.textBasic.Multiline = true;
            this.textBasic.Name = "textBasic";
            this.textBasic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBasic.Size = new System.Drawing.Size(346, 159);
            this.textBasic.TabIndex = 3;
            // 
            // textShifr
            // 
            this.textShifr.Location = new System.Drawing.Point(400, 44);
            this.textShifr.Multiline = true;
            this.textShifr.Name = "textShifr";
            this.textShifr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textShifr.Size = new System.Drawing.Size(339, 159);
            this.textShifr.TabIndex = 4;
            // 
            // labelShifr
            // 
            this.labelShifr.AutoSize = true;
            this.labelShifr.Location = new System.Drawing.Point(397, 25);
            this.labelShifr.Name = "labelShifr";
            this.labelShifr.Size = new System.Drawing.Size(159, 16);
            this.labelShifr.TabIndex = 5;
            this.labelShifr.Text = "Зашифрованный текст:";
            // 
            // matrixSymbolsText
            // 
            this.matrixSymbolsText.Location = new System.Drawing.Point(542, 233);
            this.matrixSymbolsText.Multiline = true;
            this.matrixSymbolsText.Name = "matrixSymbolsText";
            this.matrixSymbolsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.matrixSymbolsText.Size = new System.Drawing.Size(197, 128);
            this.matrixSymbolsText.TabIndex = 6;
            this.matrixSymbolsText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // matrixSymbolsLabel
            // 
            this.matrixSymbolsLabel.AutoSize = true;
            this.matrixSymbolsLabel.Location = new System.Drawing.Point(539, 214);
            this.matrixSymbolsLabel.Name = "matrixSymbolsLabel";
            this.matrixSymbolsLabel.Size = new System.Drawing.Size(135, 16);
            this.matrixSymbolsLabel.TabIndex = 7;
            this.matrixSymbolsLabel.Text = "Матрица символов:";
            // 
            // secretWord
            // 
            this.secretWord.Location = new System.Drawing.Point(400, 379);
            this.secretWord.Multiline = true;
            this.secretWord.Name = "secretWord";
            this.secretWord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.secretWord.Size = new System.Drawing.Size(339, 41);
            this.secretWord.TabIndex = 8;
            // 
            // secretWordLabel
            // 
            this.secretWordLabel.AutoSize = true;
            this.secretWordLabel.Location = new System.Drawing.Point(397, 364);
            this.secretWordLabel.Name = "secretWordLabel";
            this.secretWordLabel.Size = new System.Drawing.Size(180, 16);
            this.secretWordLabel.TabIndex = 9;
            this.secretWordLabel.Text = "Введите секретное слово:";
            // 
            // notShifrText
            // 
            this.notShifrText.Location = new System.Drawing.Point(241, 233);
            this.notShifrText.Multiline = true;
            this.notShifrText.Name = "notShifrText";
            this.notShifrText.Size = new System.Drawing.Size(295, 128);
            this.notShifrText.TabIndex = 10;
            // 
            // notShifrLabel
            // 
            this.notShifrLabel.AutoSize = true;
            this.notShifrLabel.Location = new System.Drawing.Point(238, 214);
            this.notShifrLabel.Name = "notShifrLabel";
            this.notShifrLabel.Size = new System.Drawing.Size(166, 16);
            this.notShifrLabel.TabIndex = 11;
            this.notShifrLabel.Text = "Расшифрованный текст:";
            // 
            // _labelCode
            // 
            this._labelCode.AutoSize = true;
            this._labelCode.Location = new System.Drawing.Point(45, 25);
            this._labelCode.Name = "_labelCode";
            this._labelCode.Size = new System.Drawing.Size(235, 16);
            this._labelCode.TabIndex = 12;
            this._labelCode.Text = "(Только латинские буквы и цифры)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._labelCode);
            this.Controls.Add(this.notShifrLabel);
            this.Controls.Add(this.notShifrText);
            this.Controls.Add(this.secretWordLabel);
            this.Controls.Add(this.secretWord);
            this.Controls.Add(this.matrixSymbolsLabel);
            this.Controls.Add(this.matrixSymbolsText);
            this.Controls.Add(this.labelShifr);
            this.Controls.Add(this.textShifr);
            this.Controls.Add(this.textBasic);
            this.Controls.Add(this.labelBasicText);
            this.Controls.Add(this.toNotShifr);
            this.Controls.Add(this.toCreateShifr);
            this.Name = "Form1";
            this.Text = "Шифр ADFGVX";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toCreateShifr;
        private System.Windows.Forms.Button toNotShifr;
        private System.Windows.Forms.Label labelBasicText;
        private System.Windows.Forms.TextBox textBasic;
        private System.Windows.Forms.TextBox textShifr;
        private System.Windows.Forms.Label labelShifr;
        private System.Windows.Forms.TextBox matrixSymbolsText;
        private System.Windows.Forms.Label matrixSymbolsLabel;
        private System.Windows.Forms.TextBox secretWord;
        private System.Windows.Forms.Label secretWordLabel;
        private System.Windows.Forms.TextBox notShifrText;
        private System.Windows.Forms.Label notShifrLabel;
        private System.Windows.Forms.Label _labelCode;
    }
}

