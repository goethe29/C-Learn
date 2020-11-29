using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    /*
    Выполнил: Юдин Д.

    Задание #2.
    */

    /// <summary>
    /// Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
    /// а) Вывести только те слова сообщения,  которые содержат не более n букв.
    /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    /// в) Найти самое длинное слово сообщения.
    /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    /// д) *** Создать метод, который производит частотный анализ текста.
    ///     В качестве параметра в него передается массив слов и текст, 
    ///         в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
    ///         Здесь требуется использовать класс Dictionary.
    /// </summary>
    class Message
    {
        /// <summary>
        /// Takes text and returns only words without extra symbols
        /// </summary>
        /// <param name="text"> Original text</param>
        /// <returns></returns>
        static string Format(string text) 
        {
            return text.Replace(",", "").Replace(".", "").Replace(":", "").Replace(";", "").Replace("!", "").Replace("?", "").Trim();
        }

        /// <summary>
        /// Takes text and returns words only with limited letters number
        /// </summary>
        /// <param name="original"> Original text</param>
        /// <param name="n">maximum allowable numbeers of letters in words to be returned</param>
        /// <returns></returns>
        static string LimitLength(string original, int n) 
        {
            string result = "";
            string formatted = Format(original);
            string[] strings = formatted.Split(' ');

            foreach (string str in strings)
            {
                if (str.Length <= n)
                {
                    result += str + " ";
                }
            }
            return result;
        }

        /// <summary>
        /// Takes text and removes words that end on the letter you provide
        /// </summary>
        /// <param name="original">Original text</param>
        /// <param name="lastLetter">letters to search for in the words to remove</param>
        /// <returns></returns>
        static string RemoveWords(string original, char lastLetter) 
        {
            string result = original;
            string formatted = Format(original);
            string[] strings = formatted.Split(' ');

            foreach (string str in strings)
            {
                if (str[str.Length-1] == lastLetter)
                {
                    result = result.Replace(str, "").Replace("  ", " ");
                }
            }
            return result;
        }

        /// <summary>
        /// Returns longest word
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        static string LongestWord(string original) 
        {
            string formatted = Format(original);
            string[] strings = formatted.Split(' ');
            string longestWord = strings[0];

            foreach (string str in strings)
            {
                if (str.Length > longestWord.Length)
                {
                    longestWord = str;
                }
            }
            return longestWord;
        }

        /// <summary>
        /// Takes n amount of the longest words and returns as 1 StringBuilder
        /// </summary>
        /// <param name="original"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static StringBuilder LongestWordsMessage(string original, int n) 
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++) 
            {
                string longestWord = LongestWord(original);
                result.Append($"{longestWord} ");
                original = original.Replace(longestWord, "");
            }
            return result;
        }
        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу.");

            int n = 5;
            Console.WriteLine("Введите любой текст и нажмите Enter:");
            string input1 = Console.ReadLine();
            Console.WriteLine($"Отобранны только слова, количество букв в которых не больше: {n}");
            Console.WriteLine(LimitLength(input1, n));

            char ch = 'й';
            Console.WriteLine($"Удалены все слова оканчивающиеся на букву: {ch}");
            Console.WriteLine(RemoveWords(input1, ch));

            Console.WriteLine($"Самое длинное слово: {LongestWord(input1)}");

            int k = 3;
            Console.WriteLine($"Строка из {k} самых длинных слов предложения: {LongestWordsMessage(input1, k)}");

            Console.ReadLine();
        }
    }
}
