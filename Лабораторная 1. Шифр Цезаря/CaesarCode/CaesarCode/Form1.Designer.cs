namespace CaesarCode
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
            this.startCode = new System.Windows.Forms.Button();
            this.decodeCode = new System.Windows.Forms.Button();
            this.startText = new System.Windows.Forms.TextBox();
            this.codeText = new System.Windows.Forms.TextBox();
            this.keyCodeText = new System.Windows.Forms.TextBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.keyCode = new System.Windows.Forms.Label();
            this.decodeText = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.hackCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startCode
            // 
            this.startCode.Location = new System.Drawing.Point(74, 344);
            this.startCode.Name = "startCode";
            this.startCode.Size = new System.Drawing.Size(162, 74);
            this.startCode.TabIndex = 0;
            this.startCode.Text = "Зашифровать";
            this.startCode.UseVisualStyleBackColor = true;
            this.startCode.Click += new System.EventHandler(this.startCode_Click);
            // 
            // decodeCode
            // 
            this.decodeCode.Location = new System.Drawing.Point(253, 344);
            this.decodeCode.Name = "decodeCode";
            this.decodeCode.Size = new System.Drawing.Size(161, 74);
            this.decodeCode.TabIndex = 1;
            this.decodeCode.Text = "Расшифровать";
            this.decodeCode.UseVisualStyleBackColor = true;
            this.decodeCode.Click += new System.EventHandler(this.decodeCode_Click);
            // 
            // startText
            // 
            this.startText.Location = new System.Drawing.Point(57, 43);
            this.startText.Multiline = true;
            this.startText.Name = "startText";
            this.startText.Size = new System.Drawing.Size(662, 48);
            this.startText.TabIndex = 2;
            // 
            // codeText
            // 
            this.codeText.Location = new System.Drawing.Point(57, 125);
            this.codeText.Multiline = true;
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(662, 53);
            this.codeText.TabIndex = 3;
            // 
            // keyCodeText
            // 
            this.keyCodeText.Location = new System.Drawing.Point(217, 295);
            this.keyCodeText.Name = "keyCodeText";
            this.keyCodeText.Size = new System.Drawing.Size(100, 22);
            this.keyCodeText.TabIndex = 4;
            this.keyCodeText.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startLabel.Location = new System.Drawing.Point(64, 24);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(133, 18);
            this.startLabel.TabIndex = 5;
            this.startLabel.Text = "Начальный текст:";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeLabel.Location = new System.Drawing.Point(64, 106);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(172, 18);
            this.codeLabel.TabIndex = 6;
            this.codeLabel.Text = "Зашифрованный текст:";
            // 
            // keyCode
            // 
            this.keyCode.AutoSize = true;
            this.keyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.keyCode.Location = new System.Drawing.Point(54, 295);
            this.keyCode.Name = "keyCode";
            this.keyCode.Size = new System.Drawing.Size(143, 18);
            this.keyCode.TabIndex = 7;
            this.keyCode.Text = "Ключ шифрования:";
            // 
            // decodeText
            // 
            this.decodeText.Location = new System.Drawing.Point(57, 226);
            this.decodeText.Multiline = true;
            this.decodeText.Name = "decodeText";
            this.decodeText.Size = new System.Drawing.Size(662, 43);
            this.decodeText.TabIndex = 8;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCode.Location = new System.Drawing.Point(71, 207);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(180, 18);
            this.labelCode.TabIndex = 9;
            this.labelCode.Text = "Расшифрованный текст:";
            // 
            // hackCode
            // 
            this.hackCode.Location = new System.Drawing.Point(434, 344);
            this.hackCode.Name = "hackCode";
            this.hackCode.Size = new System.Drawing.Size(143, 74);
            this.hackCode.TabIndex = 10;
            this.hackCode.Text = "Взломать";
            this.hackCode.UseVisualStyleBackColor = true;
            this.hackCode.Click += new System.EventHandler(this.hackCode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hackCode);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.decodeText);
            this.Controls.Add(this.keyCode);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.keyCodeText);
            this.Controls.Add(this.codeText);
            this.Controls.Add(this.startText);
            this.Controls.Add(this.decodeCode);
            this.Controls.Add(this.startCode);
            this.Name = "Form1";
            this.Text = "Шифр Цезаря";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startCode;
        private System.Windows.Forms.Button decodeCode;
        private System.Windows.Forms.TextBox startText;
        private System.Windows.Forms.TextBox codeText;
        private System.Windows.Forms.TextBox keyCodeText;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label keyCode;
        private System.Windows.Forms.TextBox decodeText;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Button hackCode;
    }
}

