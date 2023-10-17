using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ConsoleApp2
{
    class Program
    {
        static List<int> ids = new List<int>() {};
        static List<DateTime> dates = new List<DateTime>();
        static List<string> notes = new List<string>();
        static void Main()
        {
            Clear();
            int pos = 1;
            while (true) {
                WriteLine("Вас приветствует ежедневник: \n Создать задачу\n Сохраненные задачи\n Выйти");
                SetCursorPosition(0, pos);
                WriteLine(">");
                ConsoleKeyInfo a = ReadKey(true);
                if (a.Key == ConsoleKey.UpArrow)
                {
                    if (pos == 1) pos = 4;
                    Clear();
                    pos--;
                }
                else if (a.Key == ConsoleKey.DownArrow){
                    if (pos == 3) pos = 0;
                    Clear();
                    pos++;
                }
                else if(a.Key == ConsoleKey.Enter){
                    Start(pos, a );
                    break;
                }
            }
        }
        static void Start(int pos, ConsoleKeyInfo a)
        {
            Clear();
            switch (pos){
                case 1:
                    EnteringDate(pos);
                    break;
                case 2:
                    EnteringDate(pos);
                    break;
                case 3: break;
            }
            if (a.Key == ConsoleKey.Escape) Main();
        }
        static void EnteringDate(int pos)
        {
            DateTime d = DateTime.Today;
            WriteLine(d);
            while (true)
            {
                ConsoleKeyInfo b = ReadKey(true);
                SetCursorPosition(0, 0);
                if (b.Key == ConsoleKey.RightArrow) d = d.AddDays(1);
                if (b.Key == ConsoleKey.LeftArrow) d = d.AddDays(-1);
                if (b.Key == ConsoleKey.Escape) Main();
                if (b.Key == ConsoleKey.Enter) if (pos == 1) MakeMessage(d); else ReturnMessage(d);
                WriteLine(d.ToString());
            }
        }
        static void MakeMessage(DateTime d)
        {
            Clear();
            if (dates.Contains(d) == false)
            {
                WriteLine("Напишите ваш текст текст");
                string cursed = ReadLine();
                ids.Add(ids.Count + 1); dates.Add(d); notes.Add(cursed);
                WriteLine("Ваша заметка успешно создана под датой: " + d); ReadKey();
                Main();
            }
            else WriteLine("На эту дату невозможно сделать заметку, попробуйте другую"); EnteringDate(1);
        }
        static void ReturnMessage(DateTime d)
        {
            Clear();
            if (dates.Contains(d) == true) { 
                WriteLine("Номер заметки: " + ids[dates.BinarySearch(d)] + "\nДата: " + d + "\nТекст вашей заметки: \n" + notes[dates.BinarySearch(d)] + "\n\nESC - Выйти в главное меню");
                ReadKey(true);
                Main();
            }
            else {
                WriteLine("По дате " + d +  " нет информации");
                ReadKey();
                Clear();
                EnteringDate(2);
            }
        }
    }
}
