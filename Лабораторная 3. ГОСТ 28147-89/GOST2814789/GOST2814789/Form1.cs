using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace GOST2814789
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

        // Шифруем текст при нажатии на кнопку шифрования текста
        private void _codeButton_Click(object sender, EventArgs e)
        {
            // Если шифруемый текст или пароль пуст, то не запускаем код
            if (_baseText.Text != "" && _keyPasswordText.Text != "")
            {
                // Шифруемый текст
                string text = _baseText.Text;
                // Преобразуем шифруемый текст в байты
                byte[] bytesText = Encoding.UTF8.GetBytes(text);


                int blockLength = 8; // Длина блока
                int countKeys = 8; // Количество ключей

                string password = _keyPasswordText.Text; // Получаем пароль
                int bytesTextLength = bytesText.Length; // Длина текста в байтах

                // Вычисляем количество символов, которые нужно дополнить до деления на 8
                int paddingTextLength = ((bytesTextLength + 7) / 8) * 8;
                int needPaddingTextLength = paddingTextLength - bytesTextLength;

                // Если длина текста делится на 8, то нужно количество символов
                // которое нужно добавить, равно длине блока, нужно для дешифрования
                needPaddingTextLength = (needPaddingTextLength == 0) ? blockLength : needPaddingTextLength;
                
                // Длина нового массива байт
                int bytesLength = bytesTextLength + needPaddingTextLength;
                // Количество блоков, на который делится текст
                int countBlocks = bytesLength / blockLength;

                // Новый массив байт для зашифрованных байтов
                byte[] codeBytes = new byte[bytesLength];

                uint[] keys = new uint[countKeys]; // Массив ключей
                // Применяем SHA256 для получения 256-битного ключа
                byte[] keyBytes = GetKeyGOST(password);

                keys = GetUIntKeys(keyBytes); // Разделяем на 32-битные ключи

                // Копируем байты из шифруемого текста и дополняем padding
                byte[] bytesPaddingText = new byte[bytesLength];
                for (int i = 0; i < bytesTextLength; ++i)
                {
                    bytesPaddingText[i] = bytesText[i];
                }
                for (int i = 0; i < needPaddingTextLength; ++i)
                {
                    bytesPaddingText[bytesTextLength + i] = (byte)(needPaddingTextLength);
                }

                // Шифруем каждый блок и записываем результат
                for (int i = 0; i < countBlocks; ++i)
                {
                    byte[] bytes = new byte[blockLength]; // Блок нешифрованных данных
                    // Блок зашифрованных данных
                    byte[] codeBytesBlock = new byte[blockLength];

                    // Берем блок
                    for (int j = 0; j < blockLength; ++j)
                    {
                        bytes[j] = bytesPaddingText[i * 8 + j];
                    }
                    codeBytesBlock = CodeBlock(bytes, keys); // Шифруем блок

                    // Сохраняем блок
                    for (int j = 0; j < blockLength; ++j)
                    {
                        codeBytes[i * 8 + j] = codeBytesBlock[j];
                    }
                }

                // Отображаем через Base64, чтобы не потерять байты при превращении в строку
                _codeText.Text = Convert.ToBase64String(codeBytes);
            
            } else
            {
                MessageBox.Show("Текст, который нужно зашифровать и пароль не должны быть пустыми.");
            }
            
        }
        
        // Функция получения ключа из пароля
        private byte[] GetKeyGOST(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] keyBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return keyBytes;
            }
        }

        // Функция для шифрования блока
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

            byte[] bytes = new byte[blockLength]; // Блок зашифрованных байтов
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

        // Функция для получения 32-битных ключей из 256-битного ключа
        private uint[] GetUIntKeys(byte[] keyBytes)
        {
            int countKeys = 8; // Число ключей
            uint[] keys = new uint[countKeys];

            for (int i = 0; i < countKeys; ++i)
            {
                keys[i] = BitConverter.ToUInt32(keyBytes, i * 4);
            }
            return keys;
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

            // Преобразуем эти 4 бита с помощью таблицы замены S
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
        // Расшифровывает текст при нажатии на кнопку
        private void _notCodeButton_Click(object sender, EventArgs e)
        {
            // Если текст не шифровали или пароль пуст, то код не выполняется
            if (_codeText.Text != "" && _keyPasswordText.Text != "")
            {
                // Зашифрованный текст
                string text = _codeText.Text;
                // Массив байт зашифрованного текста
                byte[] bytes = Convert.FromBase64String(text);
                string descryptText = ""; //  Результат расшифрванного текста

                int blockLength = 8; // Длина блока
                int countKeys = 8; // Количество ключей

                string password = _keyPasswordText.Text; // Пароль
                int bytesLength = bytes.Length; // Длина зашифрованного текста

                // Количество блоков зашифрованного текста
                int countBlocks = bytesLength / blockLength;

                // Массив расшифрованных байт зашифрованного текста
                byte[] bytesOriginal = new byte[bytesLength];

                uint[] keys = new uint[countKeys]; // Ключ
                byte[] keyBytes = GetKeyGOST(password); // Получаем пароль через SHA256

                keys = GetUIntKeys(keyBytes); // Разделяем ключ на 8 ключей

                // Расшифровываем зашифрованный текст
                for (int i = 0; i < countBlocks; ++i)
                {
                    byte[] bytesBlock = new byte[blockLength]; // Блок зашифрованного текста
                    // Блок расшифрованного текста 
                    byte[] bytesBlockOriginal = new byte[blockLength];
                    for (int j = 0; j < blockLength; ++j)
                    {
                        bytesBlock[j] = bytes[i * 8 + j];
                    }

                    bytesBlockOriginal = DescryptBlock(bytesBlock, keys); // Расшифровываем блок

                    // Сохраняем блок
                    for (int j = 0; j < blockLength; ++j)
                    {
                        bytesOriginal[i * 8 + j] = bytesBlockOriginal[j];
                    }
                }

                // Узнаем, сколько символов добавили в конце
                int paddingCount = bytesOriginal[bytesOriginal.Length - 1];
                // Получаем размер массива байтов без padding
                int diffCount = bytesOriginal.Length - paddingCount;
                if (diffCount > 0)
                {
                    // Получаем расшифрованный текст
                    descryptText = Encoding.UTF8.GetString(bytesOriginal, 0, diffCount);
                    _notShifrText.Text = descryptText;
                }
                else
                {
                    MessageBox.Show("Ключ при шифровании и ключ при дешифровании не совпадают.");
                }

            }
            else {
                MessageBox.Show("Должен быть зашифрованный текст и ключ не должен быть пустым.");
            }
        }

        // Функция расшифровывает блок байтов
        private byte[] DescryptBlock(byte[] bytes, uint[] keys)
        {
            int LRLength = 4; // Длина блока R и L
            int blockLength = 8; // Длина основного блока
            int rounds = 32; // Количество раундов дешифрования
            // Получаем части R и L из основного блока байт текста
            uint L = BitConverter.ToUInt32(bytes, 0);
            uint R = BitConverter.ToUInt32(bytes, 4);

            // Расшифровываем
            for (int i = 0; i < rounds; ++i)
            {
                uint V = L;
                // Получаем индекс для ключа
                int j = (i < 8) ? i : (7 - (i % 8));

                uint key = keys[j];

                L = (uint)((L + key) & 0xFFFFFFFF); // (L + Q_i) mod 2^32

                L = F(L); // F'

                L = (L << 11) | (L >> (32 - 11)); // L <<< 11

                L ^= R; // L = L (+) R

                R = V;
            }

            // Блок расшифрованного текста
            byte[] bytesBlock = new byte[blockLength];
            // Преобразуем в массивы байтов
            byte[] L_byte = BitConverter.GetBytes(L);
            byte[] R_byte = BitConverter.GetBytes(R);

            for (int i = 0; i < LRLength; ++i)
            {
                bytesBlock[i] = L_byte[i];
            }

            for (int i = 0; i < LRLength; ++i)
            {             
                bytesBlock[i + 4] = R_byte[i];
            }
            return bytesBlock;


        }



    }
}

















