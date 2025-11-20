namespace StreamingCode
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
            this._keyPasswordText = new System.Windows.Forms.TextBox();
            this._baseTextLabel = new System.Windows.Forms.Label();
            this._codeTextLabel = new System.Windows.Forms.Label();
            this._descryptTextLabel = new System.Windows.Forms.Label();
            this._keyPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _codeTextButton
            // 
            this._codeTextButton.Location = new System.Drawing.Point(12, 292);
            this._codeTextButton.Name = "_codeTextButton";
            this._codeTextButton.Size = new System.Drawing.Size(158, 52);
            this._codeTextButton.TabIndex = 0;
            this._codeTextButton.Text = "Зашифровать";
            this._codeTextButton.UseVisualStyleBackColor = true;
            this._codeTextButton.Click += new System.EventHandler(this._codeTextButton_Click);
            // 
            // _descryptTextButton
            // 
            this._descryptTextButton.Location = new System.Drawing.Point(12, 350);
            this._descryptTextButton.Name = "_descryptTextButton";
            this._descryptTextButton.Size = new System.Drawing.Size(158, 47);
            this._descryptTextButton.TabIndex = 1;
            this._descryptTextButton.Text = "Расшировать";
            this._descryptTextButton.UseVisualStyleBackColor = true;
            this._descryptTextButton.Click += new System.EventHandler(this._descryptTextButton_Click);
            // 
            // _baseText
            // 
            this._baseText.Location = new System.Drawing.Point(12, 33);
            this._baseText.Multiline = true;
            this._baseText.Name = "_baseText";
            this._baseText.Size = new System.Drawing.Size(314, 145);
            this._baseText.TabIndex = 2;
            // 
            // _codeText
            // 
            this._codeText.Location = new System.Drawing.Point(332, 33);
            this._codeText.Multiline = true;
            this._codeText.Name = "_codeText";
            this._codeText.Size = new System.Drawing.Size(456, 145);
            this._codeText.TabIndex = 3;
            // 
            // _descryptText
            // 
            this._descryptText.Location = new System.Drawing.Point(332, 210);
            this._descryptText.Multiline = true;
            this._descryptText.Name = "_descryptText";
            this._descryptText.Size = new System.Drawing.Size(456, 134);
            this._descryptText.TabIndex = 4;
            // 
            // _keyPasswordText
            // 
            this._keyPasswordText.Location = new System.Drawing.Point(332, 392);
            this._keyPasswordText.Multiline = true;
            this._keyPasswordText.Name = "_keyPasswordText";
            this._keyPasswordText.Size = new System.Drawing.Size(456, 46);
            this._keyPasswordText.TabIndex = 5;
            // 
            // _baseTextLabel
            // 
            this._baseTextLabel.AutoSize = true;
            this._baseTextLabel.Location = new System.Drawing.Point(12, 14);
            this._baseTextLabel.Name = "_baseTextLabel";
            this._baseTextLabel.Size = new System.Drawing.Size(105, 16);
            this._baseTextLabel.TabIndex = 6;
            this._baseTextLabel.Text = "Введите текст:";
            // 
            // _codeTextLabel
            // 
            this._codeTextLabel.AutoSize = true;
            this._codeTextLabel.Location = new System.Drawing.Point(332, 14);
            this._codeTextLabel.Name = "_codeTextLabel";
            this._codeTextLabel.Size = new System.Drawing.Size(159, 16);
            this._codeTextLabel.TabIndex = 7;
            this._codeTextLabel.Text = "Зашифрованный текст:";
            // 
            // _descryptTextLabel
            // 
            this._descryptTextLabel.AutoSize = true;
            this._descryptTextLabel.Location = new System.Drawing.Point(332, 191);
            this._descryptTextLabel.Name = "_descryptTextLabel";
            this._descryptTextLabel.Size = new System.Drawing.Size(166, 16);
            this._descryptTextLabel.TabIndex = 8;
            this._descryptTextLabel.Text = "Расшифрованный текст:";
            // 
            // _keyPasswordLabel
            // 
            this._keyPasswordLabel.AutoSize = true;
            this._keyPasswordLabel.Location = new System.Drawing.Point(332, 373);
            this._keyPasswordLabel.Name = "_keyPasswordLabel";
            this._keyPasswordLabel.Size = new System.Drawing.Size(44, 16);
            this._keyPasswordLabel.TabIndex = 9;
            this._keyPasswordLabel.Text = "Ключ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._keyPasswordLabel);
            this.Controls.Add(this._descryptTextLabel);
            this.Controls.Add(this._codeTextLabel);
            this.Controls.Add(this._baseTextLabel);
            this.Controls.Add(this._keyPasswordText);
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
        private System.Windows.Forms.TextBox _keyPasswordText;
        private System.Windows.Forms.Label _baseTextLabel;
        private System.Windows.Forms.Label _codeTextLabel;
        private System.Windows.Forms.Label _descryptTextLabel;
        private System.Windows.Forms.Label _keyPasswordLabel;
    }
}

