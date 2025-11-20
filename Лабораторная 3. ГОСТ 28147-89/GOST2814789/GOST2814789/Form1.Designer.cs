namespace GOST2814789
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
            this._codeButton = new System.Windows.Forms.Button();
            this._notCodeButton = new System.Windows.Forms.Button();
            this._baseText = new System.Windows.Forms.TextBox();
            this._codeText = new System.Windows.Forms.TextBox();
            this._notShifrText = new System.Windows.Forms.TextBox();
            this._keyPasswordText = new System.Windows.Forms.TextBox();
            this._baseTextLabel = new System.Windows.Forms.Label();
            this._codeTextLabel = new System.Windows.Forms.Label();
            this._notShifrTextLabel = new System.Windows.Forms.Label();
            this._keyPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _codeButton
            // 
            this._codeButton.Location = new System.Drawing.Point(12, 273);
            this._codeButton.Name = "_codeButton";
            this._codeButton.Size = new System.Drawing.Size(149, 52);
            this._codeButton.TabIndex = 0;
            this._codeButton.Text = "Зашифровать";
            this._codeButton.UseVisualStyleBackColor = true;
            this._codeButton.Click += new System.EventHandler(this._codeButton_Click);
            // 
            // _notCodeButton
            // 
            this._notCodeButton.Location = new System.Drawing.Point(12, 331);
            this._notCodeButton.Name = "_notCodeButton";
            this._notCodeButton.Size = new System.Drawing.Size(149, 54);
            this._notCodeButton.TabIndex = 1;
            this._notCodeButton.Text = "Расшифровать";
            this._notCodeButton.UseVisualStyleBackColor = true;
            this._notCodeButton.Click += new System.EventHandler(this._notCodeButton_Click);
            // 
            // _baseText
            // 
            this._baseText.Location = new System.Drawing.Point(24, 25);
            this._baseText.Multiline = true;
            this._baseText.Name = "_baseText";
            this._baseText.Size = new System.Drawing.Size(335, 146);
            this._baseText.TabIndex = 2;
            // 
            // _codeText
            // 
            this._codeText.Location = new System.Drawing.Point(365, 25);
            this._codeText.Multiline = true;
            this._codeText.Name = "_codeText";
            this._codeText.Size = new System.Drawing.Size(409, 146);
            this._codeText.TabIndex = 3;
            // 
            // _notShifrText
            // 
            this._notShifrText.Location = new System.Drawing.Point(365, 214);
            this._notShifrText.Multiline = true;
            this._notShifrText.Name = "_notShifrText";
            this._notShifrText.Size = new System.Drawing.Size(409, 124);
            this._notShifrText.TabIndex = 4;
            // 
            // _keyPasswordText
            // 
            this._keyPasswordText.Location = new System.Drawing.Point(365, 386);
            this._keyPasswordText.Multiline = true;
            this._keyPasswordText.Name = "_keyPasswordText";
            this._keyPasswordText.Size = new System.Drawing.Size(409, 36);
            this._keyPasswordText.TabIndex = 5;
            // 
            // _baseTextLabel
            // 
            this._baseTextLabel.AutoSize = true;
            this._baseTextLabel.Location = new System.Drawing.Point(21, 6);
            this._baseTextLabel.Name = "_baseTextLabel";
            this._baseTextLabel.Size = new System.Drawing.Size(105, 16);
            this._baseTextLabel.TabIndex = 6;
            this._baseTextLabel.Text = "Введите текст:";
            // 
            // _codeTextLabel
            // 
            this._codeTextLabel.AutoSize = true;
            this._codeTextLabel.Location = new System.Drawing.Point(362, 6);
            this._codeTextLabel.Name = "_codeTextLabel";
            this._codeTextLabel.Size = new System.Drawing.Size(159, 16);
            this._codeTextLabel.TabIndex = 7;
            this._codeTextLabel.Text = "Зашифрованный текст:";
            // 
            // _notShifrTextLabel
            // 
            this._notShifrTextLabel.AutoSize = true;
            this._notShifrTextLabel.Location = new System.Drawing.Point(362, 195);
            this._notShifrTextLabel.Name = "_notShifrTextLabel";
            this._notShifrTextLabel.Size = new System.Drawing.Size(166, 16);
            this._notShifrTextLabel.TabIndex = 8;
            this._notShifrTextLabel.Text = "Расшифрованный текст:";
            // 
            // _keyPasswordLabel
            // 
            this._keyPasswordLabel.AutoSize = true;
            this._keyPasswordLabel.Location = new System.Drawing.Point(362, 367);
            this._keyPasswordLabel.Name = "_keyPasswordLabel";
            this._keyPasswordLabel.Size = new System.Drawing.Size(59, 16);
            this._keyPasswordLabel.TabIndex = 9;
            this._keyPasswordLabel.Text = "Пароль:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._keyPasswordLabel);
            this.Controls.Add(this._notShifrTextLabel);
            this.Controls.Add(this._codeTextLabel);
            this.Controls.Add(this._baseTextLabel);
            this.Controls.Add(this._keyPasswordText);
            this.Controls.Add(this._notShifrText);
            this.Controls.Add(this._codeText);
            this.Controls.Add(this._baseText);
            this.Controls.Add(this._notCodeButton);
            this.Controls.Add(this._codeButton);
            this.Name = "Form1";
            this.Text = "GOST2414789";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _codeButton;
        private System.Windows.Forms.Button _notCodeButton;
        private System.Windows.Forms.TextBox _baseText;
        private System.Windows.Forms.TextBox _codeText;
        private System.Windows.Forms.TextBox _notShifrText;
        private System.Windows.Forms.TextBox _keyPasswordText;
        private System.Windows.Forms.Label _baseTextLabel;
        private System.Windows.Forms.Label _codeTextLabel;
        private System.Windows.Forms.Label _notShifrTextLabel;
        private System.Windows.Forms.Label _keyPasswordLabel;
    }
}

