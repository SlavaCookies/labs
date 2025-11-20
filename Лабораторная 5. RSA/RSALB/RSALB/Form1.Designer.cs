namespace RSALB
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
            this._codeTextButton = new System.Windows.Forms.Button();
            this._descryptTextButton = new System.Windows.Forms.Button();
            this._baseText = new System.Windows.Forms.TextBox();
            this._codeText = new System.Windows.Forms.TextBox();
            this._descryptText = new System.Windows.Forms.TextBox();
            this._keyPasswordNText = new System.Windows.Forms.TextBox();
            this._baseTextLabel = new System.Windows.Forms.Label();
            this._codeTextLabel = new System.Windows.Forms.Label();
            this._descryptTextLabel = new System.Windows.Forms.Label();
            this._keyPasswordNLabel = new System.Windows.Forms.Label();
            this._getKeysPasswordButton = new System.Windows.Forms.Button();
            this._keyPasswordEText = new System.Windows.Forms.TextBox();
            this._keyPasswordELabel = new System.Windows.Forms.Label();
            this._lengthPrimeText = new System.Windows.Forms.TextBox();
            this._lengthPrimeLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _codeTextButton
            // 
            this._codeTextButton.Location = new System.Drawing.Point(12, 300);
            this._codeTextButton.Name = "_codeTextButton";
            this._codeTextButton.Size = new System.Drawing.Size(183, 56);
            this._codeTextButton.TabIndex = 0;
            this._codeTextButton.Text = "Зашифровать";
            this._codeTextButton.UseVisualStyleBackColor = true;
            this._codeTextButton.Click += new System.EventHandler(this._codeTextButton_Click);
            // 
            // _descryptTextButton
            // 
            this._descryptTextButton.Location = new System.Drawing.Point(12, 371);
            this._descryptTextButton.Name = "_descryptTextButton";
            this._descryptTextButton.Size = new System.Drawing.Size(183, 57);
            this._descryptTextButton.TabIndex = 1;
            this._descryptTextButton.Text = "Расшифровать";
            this._descryptTextButton.UseVisualStyleBackColor = true;
            this._descryptTextButton.Click += new System.EventHandler(this._descryptTextButton_Click);
            // 
            // _baseText
            // 
            this._baseText.Location = new System.Drawing.Point(12, 41);
            this._baseText.Multiline = true;
            this._baseText.Name = "_baseText";
            this._baseText.Size = new System.Drawing.Size(336, 161);
            this._baseText.TabIndex = 2;
            // 
            // _codeText
            // 
            this._codeText.Location = new System.Drawing.Point(354, 41);
            this._codeText.Multiline = true;
            this._codeText.Name = "_codeText";
            this._codeText.Size = new System.Drawing.Size(421, 161);
            this._codeText.TabIndex = 3;
            // 
            // _descryptText
            // 
            this._descryptText.Location = new System.Drawing.Point(354, 222);
            this._descryptText.Multiline = true;
            this._descryptText.Name = "_descryptText";
            this._descryptText.Size = new System.Drawing.Size(421, 134);
            this._descryptText.TabIndex = 4;
            // 
            // _keyPasswordNText
            // 
            this._keyPasswordNText.Location = new System.Drawing.Point(201, 388);
            this._keyPasswordNText.Multiline = true;
            this._keyPasswordNText.Name = "_keyPasswordNText";
            this._keyPasswordNText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._keyPasswordNText.Size = new System.Drawing.Size(288, 40);
            this._keyPasswordNText.TabIndex = 5;
            // 
            // _baseTextLabel
            // 
            this._baseTextLabel.AutoSize = true;
            this._baseTextLabel.Location = new System.Drawing.Point(12, 22);
            this._baseTextLabel.Name = "_baseTextLabel";
            this._baseTextLabel.Size = new System.Drawing.Size(105, 16);
            this._baseTextLabel.TabIndex = 6;
            this._baseTextLabel.Text = "Введите текст:";
            // 
            // _codeTextLabel
            // 
            this._codeTextLabel.AutoSize = true;
            this._codeTextLabel.Location = new System.Drawing.Point(351, 22);
            this._codeTextLabel.Name = "_codeTextLabel";
            this._codeTextLabel.Size = new System.Drawing.Size(159, 16);
            this._codeTextLabel.TabIndex = 7;
            this._codeTextLabel.Text = "Зашифрованный текст:";
            // 
            // _descryptTextLabel
            // 
            this._descryptTextLabel.AutoSize = true;
            this._descryptTextLabel.Location = new System.Drawing.Point(351, 203);
            this._descryptTextLabel.Name = "_descryptTextLabel";
            this._descryptTextLabel.Size = new System.Drawing.Size(166, 16);
            this._descryptTextLabel.TabIndex = 8;
            this._descryptTextLabel.Text = "Расшифрованный текст:";
            // 
            // _keyPasswordNLabel
            // 
            this._keyPasswordNLabel.AutoSize = true;
            this._keyPasswordNLabel.Location = new System.Drawing.Point(201, 371);
            this._keyPasswordNLabel.Name = "_keyPasswordNLabel";
            this._keyPasswordNLabel.Size = new System.Drawing.Size(57, 16);
            this._keyPasswordNLabel.TabIndex = 9;
            this._keyPasswordNLabel.Text = "Ключ N:";
            this._keyPasswordNLabel.Click += new System.EventHandler(this._keyPasswordLabel_Click);
            // 
            // _getKeysPasswordButton
            // 
            this._getKeysPasswordButton.Location = new System.Drawing.Point(12, 222);
            this._getKeysPasswordButton.Name = "_getKeysPasswordButton";
            this._getKeysPasswordButton.Size = new System.Drawing.Size(130, 44);
            this._getKeysPasswordButton.TabIndex = 10;
            this._getKeysPasswordButton.Text = "Получить ключи";
            this._getKeysPasswordButton.UseVisualStyleBackColor = true;
            this._getKeysPasswordButton.Click += new System.EventHandler(this._getKeysPasswordButton_Click);
            // 
            // _keyPasswordEText
            // 
            this._keyPasswordEText.Location = new System.Drawing.Point(495, 388);
            this._keyPasswordEText.Multiline = true;
            this._keyPasswordEText.Name = "_keyPasswordEText";
            this._keyPasswordEText.Size = new System.Drawing.Size(293, 40);
            this._keyPasswordEText.TabIndex = 11;
            // 
            // _keyPasswordELabel
            // 
            this._keyPasswordELabel.AutoSize = true;
            this._keyPasswordELabel.Location = new System.Drawing.Point(495, 371);
            this._keyPasswordELabel.Name = "_keyPasswordELabel";
            this._keyPasswordELabel.Size = new System.Drawing.Size(56, 16);
            this._keyPasswordELabel.TabIndex = 12;
            this._keyPasswordELabel.Text = "Ключ E;";
            // 
            // _lengthPrimeText
            // 
            this._lengthPrimeText.Location = new System.Drawing.Point(148, 238);
            this._lengthPrimeText.Multiline = true;
            this._lengthPrimeText.Name = "_lengthPrimeText";
            this._lengthPrimeText.Size = new System.Drawing.Size(197, 28);
            this._lengthPrimeText.TabIndex = 13;
            this._lengthPrimeText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // _lengthPrimeLength
            // 
            this._lengthPrimeLength.AutoSize = true;
            this._lengthPrimeLength.Location = new System.Drawing.Point(145, 219);
            this._lengthPrimeLength.Name = "_lengthPrimeLength";
            this._lengthPrimeLength.Size = new System.Drawing.Size(200, 16);
            this._lengthPrimeLength.TabIndex = 14;
            this._lengthPrimeLength.Text = "Длина простых чисел в битах:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._lengthPrimeLength);
            this.Controls.Add(this._lengthPrimeText);
            this.Controls.Add(this._keyPasswordELabel);
            this.Controls.Add(this._keyPasswordEText);
            this.Controls.Add(this._getKeysPasswordButton);
            this.Controls.Add(this._keyPasswordNLabel);
            this.Controls.Add(this._descryptTextLabel);
            this.Controls.Add(this._codeTextLabel);
            this.Controls.Add(this._baseTextLabel);
            this.Controls.Add(this._keyPasswordNText);
            this.Controls.Add(this._descryptText);
            this.Controls.Add(this._codeText);
            this.Controls.Add(this._baseText);
            this.Controls.Add(this._descryptTextButton);
            this.Controls.Add(this._codeTextButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _codeTextButton;
        private System.Windows.Forms.Button _descryptTextButton;
        private System.Windows.Forms.TextBox _baseText;
        private System.Windows.Forms.TextBox _codeText;
        private System.Windows.Forms.TextBox _descryptText;
        private System.Windows.Forms.TextBox _keyPasswordNText;
        private System.Windows.Forms.Label _baseTextLabel;
        private System.Windows.Forms.Label _codeTextLabel;
        private System.Windows.Forms.Label _descryptTextLabel;
        private System.Windows.Forms.Label _keyPasswordNLabel;
        private System.Windows.Forms.Button _getKeysPasswordButton;
        private System.Windows.Forms.TextBox _keyPasswordEText;
        private System.Windows.Forms.Label _keyPasswordELabel;
        private System.Windows.Forms.TextBox _lengthPrimeText;
        private System.Windows.Forms.Label _lengthPrimeLength;
    }
}

