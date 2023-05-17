using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typograph
{
    public class TypographMethods
    {
        /// <summary>
        /// Абсурд #1
        /// Нельзя использовать букву "е" в тексте, 
        /// так как она слишком распространена и приводит к излишней усталости глаз читателя.
        /// Вместо нее используют букву ё.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceLetterE(string text)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals("е"))
                {
                    result.Append("ё");
                }
                else
                {
                    result.Append(text[i]);
                }
            }
            return result.ToString();
        }



        /// <summary>
        /// Абсурд #2
        /// Каждая русская буква в тексте будет заменяться на следующую по алфавиту ("я" заменяется на "а").
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceRussianLetters(string text)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                //1072  1103  1040  1071
                if ((1072 <= text[i] && text[i] >= 1103) || (1040 <= text[i] && text[i] >= 1071))
                {
                    if (text[i] == 1103)
                    {
                        result.Append((char)1072);
                    }
                    else if (text[i] == 1071)
                    {
                        result.Append((char)1040);
                    }
                    else
                    {
                        result.Append((char)(text[i] + 1));
                    }
                }
                else
                {
                    result.Append(text[i]);
                }
            }
            return result.ToString();
        }



        /// <summary>
        /// #3
        /// Ни в коем случае нельзя использовать в качестве кавычек, т. н. кавычки программистов «"». 
        /// В русском языке этик кавычек нет. Вместо них нужно использовать кавычки «ёлочки». 
        /// Создаются они так: «Ёлочки»
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplacingProgrammaticQuotesWithRegularOnes(string text)
        {
            int temp = 0;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '"')
                {
                    if (temp % 2 == 0)
                    {
                        result.Append('«');
                    }
                    else
                    {
                        result.Append('»');
                    }
                    temp++;
                }
                else
                {
                    result.Append(text[i]);
                }
            }
            return result.ToString();
        }



        /// <summary>
        /// #5 
        /// Дефис пробелами не отбивается и всегда пишется слитно с частями слова или цифр, которые он разделяет.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveHyphenSpacing(string text)
        {
            StringBuilder result = new StringBuilder();

            char hyphen = '-';

            for (int i = 0; i < text.Length; i++)
            {
                // Проверяем, если текущий символ - дефис
                if (text[i].Equals(hyphen))
                {
                    // Проверяем, что с обеих сторон от дефиса находятся буквы или цифры
                    if (i > 0 && i < text.Length - 1 && (char.IsLetterOrDigit(text[i - 1]) || char.IsLetterOrDigit(text[i + 1])))
                    {
                        result.Append(text[i]);
                    }
                    else
                    {
                        result.Append(' ');
                        result.Append(text[i]);
                        result.Append(' ');
                    }
                }
                else
                {
                    result.Append(text[i]);
                }
            }
            return result.ToString();
        }



        /// <summary>
        /// #7 
        /// Наиболее частой ошибкой бывает использование дефиса при указании цифрового диапазона, 
        /// например: «Copyright 2000-2006», это неправильно. 
        /// Нужно писать «Copyright 2000—2006». 
        /// Дефис используется при указании примерных значений, например: «Он поймал 2-3 рыбы».
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CanNotUseHyphenInTheDigitalRange(string text)
        {
            StringBuilder result = new StringBuilder();

            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < text.Length; i++)
            {
                if (numbers.Contains(text[i]) && !text[i].Equals('0') && (text.Length - i >= 7)
                    && numbers.Contains(text[i + 1]) && numbers.Contains(text[i + 2])
                    && text[i + 3].Equals('-') && numbers.Contains(text[i + 4]) && numbers.Contains(text[i + 5])
                    && numbers.Contains(text[i + 6]))
                {
                    result.Append(new char[] { text[i], text[i + 1], text[i + 2], '—', text[i + 4], text[i + 5], text[i + 6] });
                    i += 6;
                }
                else if (numbers.Contains(text[i]) && (text.Length - i >= 9 && !text[i].Equals('0') && !text[i + 5].Equals('0'))
                    && numbers.Contains(text[i + 1]) && numbers.Contains(text[i + 2])
                    && numbers.Contains(text[i + 3]) && text[i + 4].Equals('-') && numbers.Contains(text[i + 5])
                    && numbers.Contains(text[i + 6]) && numbers.Contains(text[i + 7]) && numbers.Contains(text[i + 8]))
                {
                    result.Append(new char[] { text[i], text[i + 1], text[i + 2], text[i + 3], '—', text[i + 5], text[i + 6], text[i + 7], text[i + 8] });
                    i += 8;
                }
                else
                {
                    result.Append(text[i]);
                }
            }
            return result.ToString();
        }



        /// <summary>
        /// #11 
        /// При указании габаритов следует использовать символ ×.
        /// Например написание «ширина × высота × длинна» даст результат: «ширина × высота × длинна».
        /// </summary>
        /// <param name="text"></param>
        public static string ReplaceDimensionsSymbol(string text)
        {
            bool correctParametrs = IsDimensionFormatValid(text);

            if (correctParametrs)
            {
                return text.Replace("x", "×");
            }
            return text;
        }

        internal static bool IsDimensionFormatValid(string text)
        {
            // Разделить строку на подстроки, используя символ × в качестве разделителя
            string[] dimensions = text.Split('×');

            // Проверить количество полученных подстрок
            if (dimensions.Length != 3)
            {
                return false; // Неверный формат - не три габарита
            }

            // Проверить, что каждая подстрока не является пустой или содержит только пробелы
            foreach (string dimension in dimensions)
            {
                if (string.IsNullOrWhiteSpace(dimension))
                {
                    return false; // Неверный формат - пустой габарит
                }
            }

            // Проверить, что символ × стоит между габаритами
            int index = text.IndexOf('×');
            if (index == -1 || index == 0 || index == text.Length - 1)
            {
                return false; // Неверный формат - символ × отсутствует или находится в начале/конце строки
            }

            return true; // Верный формат - символ × находится между габаритами
        }
    }
}
