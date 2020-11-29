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

            for (int i = 1; i <= n; i++) 
            {
                if (original == "")
                {
                    break;
                }
                string longestWord = LongestWord(original);
                result.Append($"{longestWord} ");
                original = original.Replace(longestWord, "");
            }
            return result;
        }

        static Dictionary<string, int> CalculateFrequency(string[] words, string text) 
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();
            
            foreach (string str in words)
            {
                try
                {
                    frequency.Add(str, 0);
                }
                catch (ArgumentException)
                {
                    // do nothing
                }

                while (text.Contains(str))
                {
                    frequency[str] = frequency[str] + 1;
                    text = text.Remove(text.IndexOf(str), str.Length);
                }
            }
            return frequency;
        }

        static string Print(string[] words) 
        {
            string result = "";
            foreach (string str in words)
            {
                result += str + " ";
            }
            return result;
        }

        static string Print(Dictionary<string, int> myDictionary)
        {
            string result = "";
            foreach (KeyValuePair<string, int> kvp in myDictionary)
            {
                result += ($"\nKey = {kvp.Key}, Frequency = {kvp.Value}");
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

            
            Console.WriteLine("\nА теперь протестируем частотный Dictionary.");
            string[] keys = { "стол", "кот", "книга", "кот" };
            Console.WriteLine($"Даны следующие ключи: {Print(keys)}");
            Console.WriteLine("Введите любой текст и нажмите Enter:");
            string input2 = Console.ReadLine();
            Dictionary<string, int> wordFrequency = CalculateFrequency(keys, input2); 
            Console.WriteLine($"\nЧастотное вхождение: {Print(wordFrequency)}");

            Console.ReadLine();
        }
    }
}
