using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ADFGVX
{
    public partial class Form1 : Form
    {
        private string[] _symbols = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
        "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
        private List<string> _symbolsForFillMatrix = new List<string>();
        private Dictionary<int, string> _index = new Dictionary<int, string> { { 0, "A" }, { 1, "D" }, { 2, "F" }, { 3, "G" }, { 4, "V" }, { 5, "X" } };
        private Dictionary<string, int> _indexRev = new Dictionary<string, int> { { "A", 0 }, { "D", 1 }, { "F", 2 }, { "G", 3 }, { "V", 4 }, { "X", 5 } };

        private string[][] _matrixSymbols;
        public Form1()
        {
            _symbolsForFillMatrix = _symbols.ToList();
            _matrixSymbols = fillMatrix();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string[][] fillMatrix()
        {
            string[][] matrixSymbols = new string[6][];
            for (int i = 0; i < matrixSymbols.Length; ++i)
            {
                matrixSymbols[i] = new string[6];
            }
            Random random = new Random();
            for (int i = 0; i < matrixSymbols.Length; ++i)
            {
                for (int j = 0; j < matrixSymbols[0].Length; ++j)
                {
                    int randSymbol = random.Next(_symbolsForFillMatrix.Count);
                    string symbol = _symbolsForFillMatrix[randSymbol];
                    _symbolsForFillMatrix.RemoveAt(randSymbol);
                    matrixSymbols[i][j] = symbol;
                }
            }

            return matrixSymbols;
        }

        private void toCreateShifr_Click(object sender, EventArgs e)
        {
            string text = textBasic.Text.ToUpper();
            string textIsShifr = "";
            string secret = secretWord.Text.ToUpper();
            if (text != "" && secret != "")
            {
                string resultShifrText = "";
                for (int i = 0; i < text.Length; ++i)
                {
                    for (int j = 0; j < _matrixSymbols.Length; ++j)
                    {
                        for (int k = 0; k < _matrixSymbols[0].Length; ++k)
                        {
                            if (text[i].ToString() == _matrixSymbols[j][k])
                            {
                                textIsShifr += (_index[j] + _index[k]);
                            }
                        }
                    }
                }
                if (textIsShifr != "")
                {
                    List<List<string>> matrixWithSecretWord = new List<List<string>>();
                    List<string> listSecret = new List<string>();
                    for (int i = 0; i < secret.Length; ++i)
                    {
                        listSecret.Add(secret[i].ToString());
                    }
                    matrixWithSecretWord.Add(new List<string>(listSecret));
                    listSecret.Clear();
                    for (int i = 0; i < textIsShifr.Length; ++i)
                    {

                        listSecret.Add(textIsShifr[i].ToString());
                        if (listSecret.Count == secret.Length)
                        {
                            matrixWithSecretWord.Add(new List<string>(listSecret));
                            listSecret.Clear();
                        }
                    }

                    if (listSecret.Count != 0)
                    {
                        int different = secret.Length - listSecret.Count;
                        for (int i = 0; i < different; ++i)
                        {
                            listSecret.Add("Z");
                        }
                        matrixWithSecretWord.Add(new List<string>(listSecret));
                    }

                    var sortedColumnsSecret = matrixWithSecretWord[0]
                        .Select((letter, index) => new { Letter = letter, Index = index })
                        .OrderBy(x => x.Letter)
                        .ThenBy(x => x.Index)
                        .ToList();

                    List<List<string>> sortedMatrix = new List<List<string>>();
                    for (int i = 0; i < matrixWithSecretWord.Count; ++i)
                    {
                        sortedMatrix.Add(new List<string>());
                        foreach (var column in sortedColumnsSecret)
                        {
                            sortedMatrix[i].Add(matrixWithSecretWord[i][column.Index]);
                        }
                    }

                    for (int i = 0; i < sortedMatrix[1].Count; ++i)
                    {
                        for (int j = 1; j < sortedMatrix.Count; ++j)
                        {
                            resultShifrText += sortedMatrix[j][i];
                        }
                    }
                    textShifr.Text = resultShifrText;
                    printMatrix(_matrixSymbols);
                }
            }
        }

        private void printMatrix(string[][] matrixSymbols)
        {
            string matrixText = "";
            for (int i = 0; i < matrixSymbols.Length; ++i)
            {
                for (int j = 0; j < matrixSymbols[0].Length; ++j)
                {
                    matrixText += matrixSymbols[i][j];
                }
                matrixText += "\r\n";
            }
            matrixSymbolsText.Text = matrixText;
        }

        private void toNotShifr_Click(object sender, EventArgs e)
        {
            if (textShifr.Text != "")
            {
                string text = textShifr.Text;
                List<List<string>> matrixSymbols = new List<List<string>>();
                List<string> listSecret = new List<string>();
                string secret = secretWord.Text;
                string shifrIsText = "";
                string textIsNotShifr = "";
                foreach (char s in secret)
                {
                    listSecret.Add(s.ToString());
                }

                var sortedColumns = listSecret
                    .Select((letter, index) => new { Letter = letter, Index = index })
                    .OrderBy(x => x.Letter)
                    .ThenBy(x => x.Index)
                    .ToList();
                matrixSymbols.Add(new List<string>(listSecret));
                int numberRows = text.Length / secret.Length;
                int count = listSecret.Count;
                for (int i = 0; i < numberRows; ++i)
                {
                    List<string> list = new string[count].ToList();
                    matrixSymbols.Add(list);
                    int index = i;
                    foreach (var column in sortedColumns)
                    {
                        matrixSymbols[i + 1][column.Index] = text[index].ToString();
                        index += numberRows;
                    }
                }

                for (int i = 1; i < matrixSymbols.Count; ++i)
                {
                    for (int j = 0; j < matrixSymbols[0].Count; ++j)
                    {
                        shifrIsText += matrixSymbols[i][j];
                    }
                }

                for (int i = 0; i < shifrIsText.Length; i += 2)
                {
                    if (shifrIsText[i] != 'Z')
                    {
                        int indexRow = _indexRev[shifrIsText[i].ToString()];
                        int indexColumn = _indexRev[shifrIsText[i + 1].ToString()];
                        textIsNotShifr += _matrixSymbols[indexRow][indexColumn];
                    }
                }

                notShifrText.Text = textIsNotShifr;
            }
        }
    }
}






































