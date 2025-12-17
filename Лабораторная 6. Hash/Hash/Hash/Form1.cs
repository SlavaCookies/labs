using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Hash
{
    public partial class Form1 : Form
    {
        // Таблица замен RFC 4357
        private static readonly byte[,] S_boxes_RFC4357 = new byte[8, 16]
        {
            { 9, 6, 3, 2, 8, 11, 1, 7, 10, 4, 14, 15, 12, 0, 13, 5 },
            { 3, 7, 14, 9, 8, 10, 15, 0, 5, 2, 6, 12, 11, 4, 13, 1 },
            { 14, 4, 6, 2, 11, 3, 13, 8, 12, 15, 5, 10, 0, 7, 1, 9 },
            { 14, 7, 10, 12, 13, 1, 3, 9, 0, 2, 11, 4, 15, 8, 5, 6 },
            { 11, 5, 1, 9, 8, 13, 15, 0, 14, 4, 2, 3, 12, 7, 10, 6 },
            { 3, 10, 13, 12, 1, 2, 0, 11, 7, 5, 9, 4, 8, 15, 14, 6 },
            { 1, 13, 2, 9, 7, 10, 6, 0, 8, 12, 4, 5, 15, 3, 11, 14 },
            { 11, 10, 15, 5, 0, 12, 14, 8, 6, 2, 3, 9, 1, 7, 13, 4 }
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Функция для получения 256 битов из blockH0 через SHA256
        private byte[] _getKey(string blockH0)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(blockH0));
                return bytes;
            }
        }

        // Функция для получени 8 подключей из ключа 256 бит
        private uint[] _getKeys(byte[] keyBytes)
        {
            int countKeys = 8; // Число подключей из основного ключа
            uint[] keys = new uint[countKeys];
            for (int i = 0; i < countKeys; ++i)
            {
                keys[i] = BitConverter.ToUInt32(keyBytes, i * 4);
            }
            return keys;
        }

        // Функция для шифрования блока block с ключами keys по алгоритму ГОСТ-28147-89
        private byte[] CodeBlock(byte[] block, uint[] keys)
        {
            int blockLength = 8; // Длина блока
            int LRLength = 4; // Длина левой и правой части блока L и R
            int rounds = 32; // Количество раундов шифрования 

            // Получаем L и R из блока
            uint L = BitConverter.ToUInt32(block, 0);
            uint R = BitConverter.ToUInt32(block, 4);

            for (int i = 0; i < rounds; ++i)
            {
                uint V = R;
                int j = (i < 24) ? i % 8 : (31 - i) % 8; // Считаем индекс ключа

                uint key = keys[j];

                R = (uint)((R + key) & 0xFFFFFFFF); // (R + Q_i) mod 2^32

                R = F(R); // F'

                R = (R << 11) | (R >> (32 - 11)); // R <<< 11

                R ^= L; // R = R (+) L

                L = V;
            }

            byte[] bytes = new byte[blockLength]; // Блок зашифрованных данных
            // Преобразуем L и R в массивы байт
            byte[] L_byte = BitConverter.GetBytes(L);
            byte[] R_byte = BitConverter.GetBytes(R);

            // Соединяем в один массив
            for (int i = 0; i < LRLength; ++i)
            {
                bytes[i] = L_byte[i];
            }

            for (int i = 0; i < LRLength; ++i)
            {
                bytes[i + LRLength] = R_byte[i];
            }

            return bytes;
        }

        // Нелинейная функция преобразования F'
        private uint F(uint RL)
        {
            int countParts = 8; // Число частей из R(L)
            byte[] parts = new byte[countParts];

            // Разделяем R(L) на 8 частей по 4 бита
            for (int i = 0; i < countParts; ++i)
            {
                parts[i] = (byte)((RL >> (4 * i)) & 0x0F);
            }

            // Преобразуем эти 4 бита с помощью таблицы замен S
            for (int i = 0; i < countParts; ++i)
            {
                parts[i] = S_boxes_RFC4357[i, parts[i]];
            }

            // Собираем все части по 4 бит обратно в 4 байт
            uint resultR = 0;
            for (int i = 0; i < countParts; ++i)
            {
                resultR |= (uint)(parts[i] << (4 * i));
            }

            return resultR;
        } 
        // Создает Хэш по нажатии на кнопку
        private void _hashButton_Click(object sender, EventArgs e)
        {
            // Если текст, который нужно преобразовать в Хэш не пуст и текст для H_0 не пуст
            if (_baseText.Text != "" && _blockh0Text.Text != "")
            {
                string text = _baseText.Text; // Текст, для преобразования в Хэш
                // Текст преобразовывается в байты
                byte[] bytesText = Encoding.UTF8.GetBytes(text);

                int blockLength = 32; // Длина блока открытого текста ключа
                int blockHBytesLength = 8; // Блина блока H_i

                string blockH0 = _blockh0Text.Text; // Текст для первого блока H_0

                int bytesTextLength = bytesText.Length; // Длина всего текста в байтах
                // Вычисляем количество символов, которые нужно дополнить до деления на 32
                int paddingTextLength = ((bytesTextLength + 31) / 32) * 32;
                int needPaddingTextLength = paddingTextLength - bytesTextLength;

                // Если длина символов равна 32, то нужное количество символов, которое
                // нужно добавить, равно длине блока
                needPaddingTextLength = (needPaddingTextLength == 0) ? blockLength : needPaddingTextLength;

                // Вычисляем длину текста в байтах с дополнением
                int bytesLength = bytesTextLength + needPaddingTextLength;
                // Количество блоков символов по 32
                int countBlocks = bytesLength / blockLength;

                // Массив байтов превращенных в Хэш
                byte[] codeBytes = new byte[(bytesLength / 32) * 8];

                // Получаем блок символов 256 бит
                byte[] blockH0Bytes = _getKey(blockH0);
                // Массив символов для 8 байт из 32 байт
                byte[] blockH0BytesNeed = new byte[blockHBytesLength];
                // Берем первые 8 байт из blockH0Bytes
                for (int i = 0; i < blockHBytesLength; ++i)
                {
                    blockH0BytesNeed[i] = blockH0Bytes[i];
                }

                // Массив символов с открытым текстом с дополнением
                byte[] bytesPaddingText = new byte[bytesLength];
                // Копируем байты из массива text
                for (int i = 0; i < bytesTextLength; ++i)
                {
                    bytesPaddingText[i] = bytesText[i];
                }
                // Дополняем paading
                for (int i = 0; i < needPaddingTextLength; ++i)
                {
                    bytesPaddingText[i + bytesTextLength] = (byte)(needPaddingTextLength);
                }

                // Блок H_i-1
                byte[] blockH = new byte[blockHBytesLength];
                blockH = blockH0BytesNeed; // Сохраняем H_0 как предыдущий

                for (int i = 0; i < countBlocks; ++i)
                {
                    // Блок отыртого текста длиной 32 байт
                    byte[] keyBlockText = new byte[blockLength];
                    // Блок символов, который получится после шифрования H_i-1 с ключом M_i-
                    byte[] hashBytes = new byte[blockHBytesLength];
                    // Блок H_i
                    byte[] newHashBytes = new byte[blockHBytesLength];

                    // Получаем блок 32 байт M_i
                    for (int j = 0; j < blockLength; ++j)
                    {
                        keyBlockText[j] = bytesPaddingText[i * 32 + j];
                    }
                    // Получаем 8 ключей из блока 32 байт M_i
                    uint[] keysByte = _getKeys(keyBlockText);
                    hashBytes = CodeBlock(blockH, keysByte); // Шифруем

                    // Применяем XOR для шифрованного блока и H_i-1
                    for (int j = 0; j < blockHBytesLength; ++j)
                    {
                        newHashBytes[j] = (byte)(hashBytes[j] ^ blockH[j]);
                    }                    blockH = newHashBytes; // Меняем H_i-1 на H_i
                }

                // Выводим полученный Хэш в виде текста Base64 в поле Text
                _hashText.Text = Convert.ToBase64String(blockH);
            } else
            {
                MessageBox.Show("Текст, который преобразуется в Хэш или" +
                    " текст для блока H_0 не должныть быть пустыми.");
            }
        }
    }
}
































































