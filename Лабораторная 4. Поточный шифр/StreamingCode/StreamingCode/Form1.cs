using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace StreamingCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Функция для создания ключевого потока
        private byte[] GetKeyStreamAESCTR(byte[] key, int lengthText)
        {
            // Создаем aes
            using(Aes aes = Aes.Create())
            {
                aes.Key = key; // Секретный ключ
                aes.Mode = CipherMode.ECB; // Режим ECB
                
                // Создаем шифрующий преобразователь
                ICryptoTransform encryptor = aes.CreateEncryptor();
                // Длина массива байт iv
                int ivLengthBytes = 12;
                // Ключевой поток
                byte[] keyStream = new byte[lengthText];
                // Создаем вектор инициализации
                byte[] iv = new byte[ivLengthBytes];
                // Количество сгенерированных байтов в ключевом потоке 
                int bytesGenerated = 0;
                // Счетчик итераций цикла, чтобы блоки байт были разными
                int count = 0;
                // Длина count в байтах
                int countLengthBytes = 4;

                // Создаем ключевой поток
                while (bytesGenerated < lengthText)
                {
                    // Создаем блок байт длиной iv + count в байтах
                    byte[] countIVBlock = new byte[ivLengthBytes + countLengthBytes];

                    // Копируем значения из iv
                    for (int i = 0; i < ivLengthBytes; ++i)
                    {
                        countIVBlock[i] = iv[i];
                    }
                    
                    // Получаем массив байт для count
                    byte[] countBytes = BitConverter.GetBytes(count);
                    // Копируем значения из countBytes
                    for (int i = 0; i < countLengthBytes; ++i)
                    {
                        countIVBlock[ivLengthBytes + i] = countBytes[i];
                    }

                    // Преобразовываем полученный блок байт
                    byte[] codeBlock = encryptor.TransformFinalBlock(countIVBlock, 0, countIVBlock.Length);

                    // Определяем сколько байт нужно скопировать, либо весь полученный блок,
                    // Либо столько байт, сколько нужно, чтобы длина keyStream была равна
                    // Длине шифруемого текста в байтах
                    int needBytesCopy = Math.Min(codeBlock.Length, lengthText - bytesGenerated);

                    // Копируем значения из countIVBlock
                    for (int i = 0; i < needBytesCopy; ++i)
                    {
                        keyStream[bytesGenerated + i] = codeBlock[i];
                    }

                    // Определяем, сколько байт сгенерировали
                    bytesGenerated += needBytesCopy;
                    count++; // Увеличиваем счетчик
                }

                return keyStream;
            }
        }

        // Функция шифрования и дешифрования текста
        private byte[] CodeDecodeText(byte[] textBytes, byte[] keyStream)
        {
            // Длина шифруемого текста
            int textBytesLength = textBytes.Length;
            // Массив с зашифрованными байтами текста
            byte[] codeBytes = new byte[textBytesLength];
            // Шифруем
            for (int i = 0; i < textBytesLength; ++i)
            {
                codeBytes[i] = (byte)(textBytes[i] ^ keyStream[i]); 
            }

            return codeBytes;
        }

        // Шифруем текст после того как нажата кнопка зашифровать
        private void _codeTextButton_Click(object sender, EventArgs e)
        {
            // Если шифруемый текст и ключ не пусты
            if (_baseText.Text != "" && _keyPasswordText.Text != "")
            {
                // Шифруемый текст
                string textBase = _baseText.Text;
                // Преобразуем текст в байты
                byte[] textBytes = Encoding.UTF8.GetBytes(textBase);
                // Длина шифруемого текста
                int textBaseLength = textBytes.Length;
                // Массив байт зашифрованного текста
                byte[] codeBytes = new byte[textBaseLength];
                // Ключ
                string keyPassword = _keyPasswordText.Text;
                byte[] keyBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] keyPasswordBytes = Encoding.UTF8.GetBytes(keyPassword);
                    keyBytes = sha256.ComputeHash(keyPasswordBytes);
                }
                // Получаем ключевой поток
                byte[] keyStream = GetKeyStreamAESCTR(keyBytes, textBaseLength);
                // Шифруем текст в textBytes
                codeBytes = CodeDecodeText(textBytes, keyStream);
                // Преобразуем в Base64 строку, чтобы показать этот результат шифрования
                _codeText.Text = Convert.ToBase64String(codeBytes);
            } else
            {
                MessageBox.Show("Шифруемый текст или ключ не должны быть пустыми.");
            }
        }

        // Дешифруем по нажатию на кнопке
        private void _descryptTextButton_Click(object sender, EventArgs e)
        {
            // Если зашифрованный текст и ключ не пусты
            if (_codeText.Text != "" && _keyPasswordText.Text != "")
            {
                // Зашифрованный текст
                string codeText = _codeText.Text;
                // Массив байтов зашифрованного текста
                byte[] codeBytes = Convert.FromBase64String(codeText);
                // Длина зашифрованных байтов текста
                int textCodeLength = codeBytes.Length;
                // Массив байтов расшифрованного текста
                byte[] descryptBytes = new byte[textCodeLength];
                // Ключ
                string key = _keyPasswordText.Text;
                byte[] keyBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] keyPasswordBytes = Encoding.UTF8.GetBytes(key);
                    keyBytes = sha256.ComputeHash(keyPasswordBytes);
                }
                // Получаем ключевой поток
                byte[] keyStream = GetKeyStreamAESCTR(keyBytes, textCodeLength);
                // Дешифруем
                descryptBytes = CodeDecodeText(codeBytes, keyStream);
                // Показываем результат расшифровки в элементе
                _descryptText.Text = Encoding.UTF8.GetString(descryptBytes);
            }
            else
            {
                MessageBox.Show("Зашифрованный текст и ключ не должны быть пустыми.");
            }
        }
    }
}












































