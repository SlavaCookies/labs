using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RSALB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Приватный ключ, первое простое число
        private BigInteger _privateKeyP = 0;
        // Приватный ключ, второе простое число
        private BigInteger _privateKeyQ = 0;
        // Приватный ключ
        private BigInteger _privateKeyD = 0;

        // Тест Миллера-Рабина
        private static bool IsProbablyPrime(BigInteger number, int rounds)
        {
            // Если число отрицательное, четное или делится на 5, то тогда это простое число
            if (number < 2 || number.IsEven || number % 5 == 0)
            {
                return false;
            }

            // number - 1 = d * 2^s
            BigInteger d = number - 1;
            int s = 0;
            while (d.IsEven)
            {
                d /= 2;
                s++;
            }

            using (var rng = RandomNumberGenerator.Create())
            {
                for (int i = 0; i < rounds; i++)
                {
                    // Выбираем случайного "свидетеля"
                    BigInteger numberNew = GetRandomBigInteger(number, rng);
                    // x = numberNew^d mod number
                    BigInteger x = BigInteger.ModPow(numberNew, d, number);

                    // Проверяем тривиальные случаи для x
                    if (x == 1 || x == number - 1)
                        continue; // Возможно простое, проверяем дальше
                    
                    // Возводим в квадрат s-1 раз
                    // Проверяем x^2, x^4, ..., x^(2^(s-1))
                    for (int j = 0; j < s - 1; j++)
                    {
                        x = BigInteger.ModPow(x, 2, number);
                        if (x == number - 1)
                            break;
                        if (x == 1)
                            return false;
                    }

                    if (x != number - 1)
                        return false;
                }
            }
            return true; // Вероятно, это простое число
        }

        // Создаем случайное большое число
        private static BigInteger GetRandomBigInteger(BigInteger bound, RandomNumberGenerator rng)
        {
            // Преобразовываем число в массив байтов
            byte[] bytes = bound.ToByteArray();
            BigInteger result;
            // Пока полученное число не будет больше или равно изначальному
            do
            {
                rng.GetBytes(bytes); // Перезапись массива байтов случайными байтами
                result = new BigInteger(bytes);
            } while (result >= bound);
            return result;
        }
        // Создаем случайное простое число
        private static BigInteger GeneratePrime(int lengthBits)
        {
            // Генератор чисел
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            // Размер числа в байтах
            byte[] bytes = new byte[lengthBits / 8];
            // Пока не нашли простое число
            while (true)
            {
                rng.GetBytes(bytes); // Генерация числа
                BigInteger potentialPrime = new BigInteger(bytes);

                // Старший байт превращаем в 1 для размера
                potentialPrime |= BigInteger.One << (lengthBits - 1);
                // Младший байт превращаем в 1 для нечетности
                potentialPrime |= BigInteger.One;

                // Проверяем тестом Миллера-Рабина
                if (IsProbablyPrime(potentialPrime, 5))
                {
                    return potentialPrime;
                }
            }
        }

        // Шифруем текст
        private void _codeTextButton_Click(object sender, EventArgs e)
        {
            // Если нужные данные правильно введены
            if (_baseText.Text != "" && int.TryParse(_lengthPrimeText.Text, out int lengthPrime)
                && lengthPrime > 0 && _keyPasswordNText.Text != "" && _keyPasswordEText.Text != "")
            {
                // Превращаем текст в байты
                byte[] bytesBaseText = Encoding.UTF8.GetBytes(_baseText.Text);
                // Берем первый публичный ключ N
                BigInteger publicKeyN = BigInteger.Parse(_keyPasswordNText.Text);
                // Берем второй публичный ключ E 
                BigInteger publicKeyE = BigInteger.Parse(_keyPasswordEText.Text);

                // Новое число, гарантировано положительное
                byte[] bytesMText = new byte[bytesBaseText.Length + 1];
                bytesMText[0] = 0x00; // Гарантируем положительное число


                // Копируем байты из bytesBaseText в bytesMText
                for (int i = 0; i < bytesBaseText.Length; ++i)
                {
                    bytesMText[i + 1] = bytesBaseText[i];
                }

                // Реверсим в big-endian для BigInteger
                Array.Reverse(bytesMText);

                BigInteger MText = new BigInteger(bytesMText);

                // Проверяем длины текста и ключа
                if (MText >= publicKeyN)
                {
                    MessageBox.Show("Сообщение длинное для данного ключа");
                    return;
                }

                // Шифруем
                BigInteger CText = BigInteger.ModPow(MText, publicKeyE, publicKeyN);
                _codeText.Text = CText.ToString("X");
            } else
            {
                MessageBox.Show("Шифруемый текст не должен быть пустым, длина простых" +
                    " чисел должна быть указана правильно.");
            }
        }

        // Дешифруем текст
        private void _descryptTextButton_Click(object sender, EventArgs e)
        {
            // Если есть зашифрованный текст
            if (_codeText.Text != "")
            {
                // Зашифрованный текст
                BigInteger CText = BigInteger.Parse(_codeText.Text,
                    System.Globalization.NumberStyles.HexNumber);
                // Берем публичный ключ N
                BigInteger publicKeyN = BigInteger.Parse(_keyPasswordNText.Text);
                // Расшифровываем
                BigInteger MText = BigInteger.ModPow(CText, _privateKeyD, publicKeyN);
                // Получаем байты полученного текста
                byte[] bytesMText = MText.ToByteArray();

                // Преобразовывавем обратно в big-endian, особенности BigInteger
                Array.Reverse(bytesMText);

                // Убираем нулевой байт в начале, добавленный при шифровании
                if (bytesMText[0] == 0x00)
                {
                    // Создаем новый массив байт без нуля в начале
                    byte[] bytes = new byte[bytesMText.Length - 1];
                    for (int i = 0; i < bytes.Length; ++i)
                    {
                        bytes[i] = bytesMText[i + 1];
                    }
                    _descryptText.Text = Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    _descryptText.Text = Encoding.UTF8.GetString(bytesMText);
                }
            }
            else
            {
                MessageBox.Show("Должен быть зашифрованный текст.");
            }
        }

        private void _keyPasswordLabel_Click(object sender, EventArgs e)
        {

        }

        // Функция для нахождения d, части приватного ключа из (p,q,d) 
        private static BigInteger ModInverse(BigInteger firstNumber, BigInteger secondNumber)
        {
            // Сохраняем значение phi(n) = p * q
            BigInteger secondNumberCopy = secondNumber;
            BigInteger s = 1; // Коэффициент при e в s*e + t*phi = gcd(e, phi)
            BigInteger t = 0; // Коэффициент при phi

            if (secondNumber == 1)
                return 0;
            
            // Вычисляем d
            while (firstNumber > 1)
            {
                BigInteger quotient = firstNumber / secondNumber;
                BigInteger temp = secondNumber; // Сохраняем phi

                // secondNumber, это remainder здесь
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
                temp = t;

                // Обновляем коэффициенты t и s
                t = s - quotient * t;
                s = temp;
            }

            // Если коэффициент получилсчя отрицательным, то нормализуем его прибавив phi
            if (s < 0)
                s += secondNumberCopy;

            return s;
        }


        // Генеруем публичный и приватный ключ
        private void _getKeysPasswordButton_Click(object sender, EventArgs e)
        {
            // Если длина простых чисел правильна
            if (int.TryParse(_lengthPrimeText.Text, out int lengthPrime) && lengthPrime > 0)
            {
                // Значит, что это простое число
                bool isNormalPrime = false;

                BigInteger firstPrime = 0; // Первое простое число p
                BigInteger secondPrime = 0; // Второе простое число q
                BigInteger multPrime = 0; // Произвдение простых чисел n
                BigInteger phiPrime = 0; // Функция phi(n) = (p - 1) * (q - 1)
                BigInteger d = 0; // Часть приватного ключа (p,q,d)
                BigInteger ePhiPrime = 65537; // Взаимнопростое число

                // Пока не нашли простые числа
                while (!isNormalPrime)
                {
                    // Генерируем первое простое число
                    firstPrime = GeneratePrime(lengthPrime);
                    // Генерируем второе простое число
                    secondPrime = GeneratePrime(lengthPrime);

                    // Убедимся, что простые числа разные
                    if (firstPrime == secondPrime)
                        continue;

                    // Считаем n
                    multPrime = firstPrime * secondPrime;
                    // Считаем phi(n)
                    phiPrime = (firstPrime - 1) * (secondPrime - 1);

                    // Проверяем, что наибольший общий делитель это число равное 1
                    if (BigInteger.GreatestCommonDivisor(ePhiPrime, phiPrime) == 1)
                    {
                        isNormalPrime = true; // Эти числа являются простыми
                    }
                }

                // Вычисляем d как модульную инверсию e по модулю phi
                d = ModInverse(ePhiPrime, phiPrime);

                // Присваиваем значения в нужные поля
                _privateKeyP = firstPrime;
                _privateKeyQ = secondPrime;
                _privateKeyD = d;
                _keyPasswordNText.Text = multPrime.ToString();
                _keyPasswordEText.Text = ePhiPrime.ToString();


            }
            else
            {
                MessageBox.Show("Длина простых чисел должна быть указана правильно.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}













































































































































