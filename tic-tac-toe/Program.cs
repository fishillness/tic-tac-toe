using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    class Program
    {
        //Метод рисующий крестик
        static void DrawCross(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i - j == x - y || i + j == y + x + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }
        }
        //Метод рисующий нолик
        static void DrawRectangle(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i == x || i == x + size || j == y || j == y + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }
        }
        //Метод рисующий поле
        static void DrawField(int width, int height, int cellSize)
        {
            for (int y = 0; y <= height; y += cellSize)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            for (int x = 0; x <= width; x += cellSize)
            {
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(i % 3 * cellSize + cellSize / 2, i / 3 * cellSize + 1);
                Console.Write(i + 1);
            }
        }
        static void Main(string[] args)
        {
            //Базовые настройки и отрисовка поля
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);

            int width = 33;
            int height = 33;
            int cellSize = 11;

            DrawField(width, height, cellSize);

            int input;
            int c1, c2, c3, c4, c5, c6, c7, c8, c9; 
            c1 = c2 = c3 = c4 = c5 = c6 = c7 = c8 = c9 = -1;
            int win = -1;

            //Главный цикл игры
            for (int i = 0; i < 9; i++)
            {
                //Пользовательский ввод
                Console.SetCursorPosition(35, 0);
                Console.Write("                                             ");
                Console.SetCursorPosition(35, 0);
                Console.Write("Введите номер клетки: ");

                bool errorInputRepeat = false;
                bool errorInputWrong = false;
                errorInputWrong = !int.TryParse(Console.ReadLine(), out input);


                Console.SetCursorPosition(35, 2);
                Console.Write("                                                   ");
                //Проверка корректности ввода

                if (input < 1 || input > 9) errorInputWrong = true;

                if (input == 1 && c1 >= 0) errorInputRepeat = true;
                if (input == 2 && c2 >= 0) errorInputRepeat = true;
                if (input == 3 && c3 >= 0) errorInputRepeat = true;
                if (input == 4 && c4 >= 0) errorInputRepeat = true;
                if (input == 5 && c5 >= 0) errorInputRepeat = true;
                if (input == 6 && c6 >= 0) errorInputRepeat = true;
                if (input == 7 && c7 >= 0) errorInputRepeat = true;
                if (input == 8 && c8 >= 0) errorInputRepeat = true;
                if (input == 9 && c9 >= 0) errorInputRepeat = true;

                if (errorInputRepeat == true)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.Write("Эта клетка уже занята. Введите снова.");
                    i--;
                    continue;
                }
                if (errorInputWrong == true)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.Write("Неверный формат ввода. Введите число от 1 до 9.");
                    i--;
                    continue;
                }

                if (input == 1) c1 = i % 2;
                if (input == 2) c2 = i % 2;
                if (input == 3) c3 = i % 2;
                if (input == 4) c4 = i % 2;
                if (input == 5) c5 = i % 2;
                if (input == 6) c6 = i % 2;
                if (input == 7) c7 = i % 2;
                if (input == 8) c8 = i % 2;
                if (input == 9) c9 = i % 2;

                //Вывод истории ходов
                Console.SetCursorPosition(35, 4 + i);
                if (i % 2 == 0)
                    Console.WriteLine($"{i + 1}. Крестик на поле {input}");
                else
                    Console.WriteLine($"{i + 1}. Нолик на поле {input}");


                // Определение куда поставить фигуру 
                int x = (input - 1) % 3 * cellSize + 2;
                int y = (input - 1) / 3 * cellSize + 2;
                // Определение какую фигуру рисовать и отрисовка
                if (i % 2 == 0)
                    DrawCross(x, y, 7);
                else
                    DrawRectangle(x, y, 7);
                //Определение кто победил
                if (c1 == c2 && c2 == c3 && c1 != -1) win = c1;
                if (c4 == c5 && c5 == c6 && c4 != -1) win = c4;
                if (c7 == c8 && c8 == c9 && c7 != -1) win = c7;
                if (c1 == c4 && c4 == c7 && c1 != -1) win = c1;
                if (c2 == c5 && c5 == c8 && c2 != -1) win = c2;
                if (c3 == c6 && c6 == c9 && c3 != -1) win = c3;
                if (c1 == c5 && c5 == c9 && c1 != -1) win = c1;
                if (c3 == c5 && c5 == c7 && c3 != -1) win = c3;

                if (win == 0)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победили крестики!");
                    break;
                }
                if (win == 1)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победили нолики!");
                    break;
                }
            }

            Console.SetCursorPosition(35, 3);
            if (win == -1) Console.WriteLine("Ничья");

            Console.ReadLine();
        }
    }
}
