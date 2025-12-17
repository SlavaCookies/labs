namespace Hash
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
            this._textLabel = new System.Windows.Forms.Label();
            this._baseText = new System.Windows.Forms.TextBox();
            this._hashLabel = new System.Windows.Forms.Label();
            this._hashText = new System.Windows.Forms.TextBox();
            this._blockh0Text = new System.Windows.Forms.TextBox();
            this._hashButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _textLabel
            // 
            this._textLabel.AutoSize = true;
            this._textLabel.Location = new System.Drawing.Point(37, 30);
            this._textLabel.Name = "_textLabel";
            this._textLabel.Size = new System.Drawing.Size(48, 16);
            this._textLabel.TabIndex = 0;
            this._textLabel.Text = "Текст:";
            this._textLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // _baseText
            // 
            this._baseText.Location = new System.Drawing.Point(40, 49);
            this._baseText.Multiline = true;
            this._baseText.Name = "_baseText";
            this._baseText.Size = new System.Drawing.Size(616, 84);
            this._baseText.TabIndex = 1;
            // 
            // _hashLabel
            // 
            this._hashLabel.AutoSize = true;
            this._hashLabel.Location = new System.Drawing.Point(37, 136);
            this._hashLabel.Name = "_hashLabel";
            this._hashLabel.Size = new System.Drawing.Size(82, 16);
            this._hashLabel.TabIndex = 2;
            this._hashLabel.Text = "Хэш текста:";
            // 
            // _hashText
            // 
            this._hashText.Location = new System.Drawing.Point(40, 155);
            this._hashText.Multiline = true;
            this._hashText.Name = "_hashText";
            this._hashText.Size = new System.Drawing.Size(616, 139);
            this._hashText.TabIndex = 3;
            // 
            // _blockh0Text
            // 
            this._blockh0Text.Location = new System.Drawing.Point(40, 316);
            this._blockh0Text.Multiline = true;
            this._blockh0Text.Name = "_blockh0Text";
            this._blockh0Text.Size = new System.Drawing.Size(616, 44);
            this._blockh0Text.TabIndex = 5;
            this._blockh0Text.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // _hashButton
            // 
            this._hashButton.Location = new System.Drawing.Point(40, 366);
            this._hashButton.Name = "_hashButton";
            this._hashButton.Size = new System.Drawing.Size(175, 53);
            this._hashButton.TabIndex = 6;
            this._hashButton.Text = "Создать Хэш";
            this._hashButton.UseVisualStyleBackColor = true;
            this._hashButton.Click += new System.EventHandler(this._hashButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Первый блок текста H_0:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._hashButton);
            this.Controls.Add(this._blockh0Text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._hashText);
            this.Controls.Add(this._hashLabel);
            this.Controls.Add(this._baseText);
            this.Controls.Add(this._textLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _textLabel;
        private System.Windows.Forms.TextBox _baseText;
        private System.Windows.Forms.Label _hashLabel;
        private System.Windows.Forms.TextBox _hashText;
        private System.Windows.Forms.TextBox _blockh0Text;
        private System.Windows.Forms.Button _hashButton;
        private System.Windows.Forms.Label label1;
    }
}

