using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameThatTuneBot
{
    static class MessageTextPattern
    {

        static public string GetSelectPage(string answer1, string answer2, string answer3, string answer4)
        {
            return $"Выберите возможные варианты:\nA:{answer1};\nA:{answer2};\nA:{answer3};\nA:{answer4};";
        }
        static public string GetSelectPage(string[] answer)
        {
            Console.WriteLine("answer" + answer.Length.ToString());
            Console.WriteLine("answer" + answer[0] + answer[1] + answer[2] + answer[3]);
            if (answer.Length >= 4)
            {

                return $"Выберите возможные варианты:\n1:{answer[0]};\n2:{answer[1]};\n3:{answer[2]};\n4:{answer[3]};";
            }
            return null;
            
        }
        static public string GetResultMessage(bool typeAnswer)
        {
            return "Ваш ответ: " + (typeAnswer ? "Верен" : "Неверен");
        }
        static public string GetMainPage()
        {
            return "Выбери возможные варианты:";
        }
    }
}
