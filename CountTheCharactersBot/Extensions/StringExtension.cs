using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTheCharactersBot.Extensions
{
    public static class StringExtension
    {
        public static string GetStringLengthText(string str)
        {
            return $"Количество символов: {str.Length}";
        }
        public static string GetSumText(string str)
        {
            try
            {
                int sum = 0;
                string currentNumber = null;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        sum += int.Parse(currentNumber);
                        currentNumber = null;
                    }
                    else
                    {
                        currentNumber += str[i];
                    }
                }
                sum += int.Parse(currentNumber);

                return $"Сумма чисел: {sum}";
            }
            catch (Exception)
            {
                return "Ошибка: неверный формат. Пишите числа через пробел. Пример: 56 9 108 -45";
            }
            
        }
    }
}
