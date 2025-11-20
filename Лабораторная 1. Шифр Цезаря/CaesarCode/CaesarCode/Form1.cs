using System;
using System.Windows.Forms;

namespace CaesarCode
{
    public partial class Form1 : Form
    {
        // Алфафит, который используется в программе
        char[] _alphabet = { 'а', 'б', 'в', 'г', 'д', 'е','ё', 'ж', 'з', 'и', 
                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
                                'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                'э', 'ю', 'я' };
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Кнопка, которая отвечает за шифрование сообщения с заданным ключом.
        private void startCode_Click(object sender, EventArgs e)
        {
            // Проверяем, является ли введеный ключ числовым значением
            if (int.TryParse(keyCodeText.Text, out int key) != false)
            {
                // Проверяем, что ключ больше 0
                if (key >= 1)
                {
                    codeText.Text = ""; // Очищаем поле для вывода зашифрованного текста
                    int size = _alphabet.Length;
                    // Массив букв сообщения, который будет содержать итоговое сообщение
                    char[] code = new char[startText.Text.Length];
                    {
                        for (int i = 0; i < startText.Text.Length; ++i)
                        {
                            // Текущий символ в сообщении
                            char element = startText.Text[i];
                            // Находим индекс в алфавите для этого символа
                            int index = Array.IndexOf(_alphabet, char.ToLower(element));
                            // Если этот символ в алфавите
                            if (index >= 0)
                            {
                                // Находим новый индекс для этого элемента, то есть шифруем его
                                int newIndex = (index + key) % size;
                                // Получаем другой символ для шифрования
                                char elementDecode = _alphabet[newIndex];
                                // Добавляем в итоговый массив зашифрованный символ, при этом проверяя
                                // что, если этот символ(буква), была верхнего регистра, то возвращаеи букву в верхнем регистре
                                code[i] = char.IsUpper(element) ? char.ToUpper(elementDecode) : elementDecode;
                            }
                            else
                            {
                                // Если элемент не из алфавита, то не трогаем его
                                code[i] = element;
                            }
                        }
                    }
                    // Отображаем зашифрованный текст
                    codeText.Text = new string(code);
                }
                else
                {
                    // Если ключ меньше 1, то сообщаем об этом
                    MessageBoxKeyError();
                }
            }
            else
            {
                // Сообщаем, что ключ не число
                MessageBoxKeyError();
            }
        }

        // Сообщение о том, что ключ написан неверно
        private void MessageBoxKeyError()
        {
            MessageBox.Show("Неверный формат  ключа, ключ должен быть больше или равен 1.");
        }

        // Кнопка, которая отвечает за расшифровку
        private void decodeCode_Click(object sender, EventArgs e)
        {
            // Если является числом и начальный текст не пуст
            if (int.TryParse(keyCodeText.Text, out int key) && startText.Text != "")
            {
                // Расшифровываем текст с заданным ключом
                decodeText.Text = Decode(codeText.Text, key);
            }
        }

        // Кнопка, отвечающая за взлом текста
        private void hackCode_Click(object sender, EventArgs e)
        {
           HackBrute();
        }

        // Функция взлома
        private void HackBrute()
        {
            string decode = ""; // Расшированный текст с каким-то ключом
            string resultDecode = ""; // Итог, все варианты текста
            resultDecode = "Возможные варианты:\n";
            // Проходим по всем возможным ключам
            for (int key = 1; key <= _alphabet.Length; ++key)
            {
                // Расшифруем текст
                decode = Decode(codeText.Text, key);
                resultDecode += ($"Ключ {key} = " + decode + ";\n");
            }
            MessageBox.Show(resultDecode, "Взломанный шрифт.");
        }
        // Функция для расшифровки текста
        private string Decode(string text, int key)
        {
            // Расшифрованный текст
            char[] decode = new char[text.Length];
            // Проходим по всем элементам 
            for (int i = 0; i < text.Length; ++i)
            {
                // Текущий элемент зашифрованного текста
                char element = text[i];
                // Находим индекс этого символа в алфавите
                int index = Array.IndexOf(_alphabet, char.ToLower(element));
                if (index >= 0) // Если такой символ в алфавите есть
                {
                    // Считаем индекс символа до шифрования
                    int newIndex = (index - key + _alphabet.Length) % _alphabet.Length;
                    // Получаем этот символ алфавита
                    char elementDecode = _alphabet[newIndex];
                    // Если символ был в верхнем регистре, то возвращаем верхний регистр
                    decode[i] = char.IsUpper(element) ? char.ToUpper(elementDecode) : elementDecode;
                }
                else
                {
                    // Если данный символ не относится к содержимому алфавита
                    decode[i] = element;
                }
            }
            // Возвращаем расшифрованный текст
            return new string(decode);
        } 
    } 
}













































































