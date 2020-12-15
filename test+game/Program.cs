using System;
using System.Threading;

namespace test_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int variant;
            int best_record = 0;
            Console.WriteLine("Если вы хотите начать игру нажмите 1");
            Console.WriteLine("Если вы хотите посмотреть лучший результат нажмите 2");
            Console.WriteLine("Если вы хотите прочитать правила игры нажмите 3");
            Console.WriteLine("Если вы хотите выйти из игры нажмите 4");
            variant =int.Parse(Console.ReadLine());
            Console.Clear();
            while (variant!=4)  
            {
                if (variant == 2) Console.WriteLine("Ваш рекорд:" + best_record);
                else if (variant == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Вас приветствует игра <<БРИЛЛИАНТЫ>>!!!\nПравила игры очень просты. Вам нужно за одну минуту набрать как можно больше очков.\nДля этого поменяйте две соседние цифры местами, и если у вас выстраиваются 3 или больше одинаковых цифры в ряд или столбик, то они уничтожаются и вам прибавляются очки.\nДля того чтобы поменять цыфру местами вам нужно ввести координаты этой цифры и нажать на стрелочку(так сказать выбрать направление куда должна перейти данная цифра)\nИ ещё одно по истечению минуты вам будет надан ещё один последний ход" + "(будьте внимательны)))" + "\nЦель игры - набрать как можно больше очков.\nУДАЧИ!!!");
                    Console.ResetColor();
                }
                else if (variant == 1)
                {
                    int[,] start_field = new int[9, 9];
                    //int best_record = 0;
                    int record = 0;
                    for (int i = 0; i < start_field.GetLength(0); i++)
                        for (int j = 0; j < start_field.GetLength(1); j++)
                            start_field[i, j] = 0;
                    Random ran = new Random();
                    start_field[0, 1] = 1;
                    start_field[0, 2] = 2;
                    start_field[0, 3] = 3;
                    start_field[0, 4] = 4;
                    start_field[0, 5] = 5;
                    start_field[0, 6] = 6;
                    start_field[0, 7] = 7;
                    start_field[0, 8] = 8;
                    start_field[1, 0] = 1;
                    start_field[2, 0] = 2;
                    start_field[3, 0] = 3;
                    start_field[4, 0] = 4;
                    start_field[5, 0] = 5;
                    start_field[6, 0] = 6;
                    start_field[7, 0] = 7;
                    start_field[8, 0] = 8;
                    int field;
                    field = ran.Next(1, 5);
                    choice_field(ref start_field, ref field);

                    /*for (int i = 1; i < start_field.GetLength(0); i++)
                        for (int j = 1; j < start_field.GetLength(1); j++)
                            start_field[i, j] = ran.Next(1, 5);
                    */
                    string s = System.DateTime.Now.ToLongTimeString();
                    string m, se;
                    bool time_b;
                    if (s.Length == 8)
                    {
                        time_b = true;
                        m = s.Substring(3, 2);
                        se = s.Substring(6, 2);
                    }
                    else
                    {
                        time_b = false;
                        m = s.Substring(2, 2);
                        se = s.Substring(5, 2);
                    }
                    int min = int.Parse(m);
                    int sec = int.Parse(se);
                    //Console.WriteLine(m + " " + se);
                    //Console.WriteLine(System.DateTime.Now.ToLongTimeString());
                    int min2 = min + 1;
                    int sec2 = sec + 1;
                    vivod(ref start_field);
                    int time2 = min2 * 60 + sec2;
                    int time1 = min * 60 + sec;
                    while (time2 > time1)
                    {
                        int a_first, b_first, a_second, b_second;
                        Console.WriteLine("Введите координаты цифры которую вы хотите переместить:");
                        Console.Write("Первая координата:");
                        a_first = int.Parse(Console.ReadLine());
                        Console.Write("Вторая координата:");
                        b_first = int.Parse(Console.ReadLine());
                        a_second = a_first;
                        b_second = b_first;
                        gameplay(ref a_second, ref b_second);
                        Console.WriteLine();
                        swap(ref start_field[a_first, b_first], ref start_field[a_second, b_second]);
                        check_row(ref start_field, ref record);
                        chek_column(ref start_field, ref record);
                        vivod(ref start_field);
                        Console.ReadKey();
                        Console.Clear();
                        check_zeroes(ref start_field);
                        for (int i = 1; i < start_field.GetLength(0); i++)
                            for (int j = 0; j < start_field.GetLength(1); j++)
                                if (start_field[i, j] == 0) start_field[i, j] = ran.Next(1, 5);
                        vivod(ref start_field);
                        //Console.Clear();
                        //  ffindthree(ref start_field, ref record);
                        Console.WriteLine("Ваш текущий счет:" + record);

                        // Console.Clear();
                        s = System.DateTime.Now.ToLongTimeString();
                        if (time_b)
                        {
                            m = s.Substring(3, 2);
                            se = s.Substring(6, 2);
                        }
                        else
                        {
                            m = s.Substring(2, 2);
                            se = s.Substring(5, 2);
                        }

                        min = int.Parse(m);
                        sec = int.Parse(se);
                        time1 = min * 60 + sec;
                    }
                    if (record > best_record) best_record = record;
                    record = 0;
                }
                else
                {
                    Console.WriteLine("введите одну из высше перечисленых чисел:");
                }
                Console.WriteLine("Если вы хотите начать игру нажмите 1");
                Console.WriteLine("Если вы хотите посмотреть лучший результат нажмите 2");
                Console.WriteLine("Если вы хотите прочитать правила игры нажмите 3");
                Console.WriteLine("Если вы хотите выйти из игры нажмите 4");
                variant = int.Parse(Console.ReadLine());
                Console.Clear();
            }

            }

        static void check_zeroes(ref int[,] start_field)
        {
            int k = 7;
            while (k != 0)
            {
                k--;
                for (int i = 2; i < start_field.GetLength(0); i++)
                {
                    for (int j = 0; j < start_field.GetLength(1); j++)
                    {
                        if (start_field[i, j] == 0)
                        {
                            int t = start_field[i, j];
                            start_field[i, j] = start_field[i - 1, j];
                            start_field[i - 1, j] = t;
                        }
                    }
                }
            }
        }

        static void chek_column(ref int[,] start_field, ref int record)
        {
            for (int i = 3; i < start_field.GetLength(0) - 2; i++)
            {
                for (int j = 1; j < start_field.GetLength(1); j++)
                {
                    if (i == 3 && start_field[i, j] == start_field[i - 1, j] && start_field[i, j] == start_field[i - 2, j] && start_field[i, j] != start_field[i + 1, j])
                    {
                        start_field[i, j] = 0;
                        start_field[i - 1, j] = 0;
                        start_field[i - 2, j] = 0;
                        record += 3;
                    }
                    else if (i == 6 && start_field[i, j] == start_field[i + 1, j] && start_field[i, j] == start_field[i + 2, j] && start_field[i, j] != start_field[i - 1, j])
                    {
                        start_field[i, j] = 0;
                        start_field[i + 1, j] = 0;
                        start_field[i + 2, j] = 0;
                        record += 3;
                    }
                    else if (i != 6 && i != 3 && start_field[i, j] == start_field[i + 1, j] && start_field[i + 2, j] != start_field[i, j] && start_field[i, j] == start_field[i - 1, j] && start_field[i - 2, j] != start_field[i, j])
                    {
                        start_field[i, j] = 0;
                        start_field[i + 1, j] = 0;
                        start_field[i - 1, j] = 0;
                        record += 3;
                    }

                    else if (i == 6 && start_field[i, j] == start_field[i + 1, j] && start_field[i, j] == start_field[i - 1, j] && start_field[i, j] == start_field[i + 2, j] && start_field[i, j] != start_field[i - 2, j])
                    {
                        start_field[i, j] = 0;
                        start_field[i - 1, j] = 0;
                        start_field[i + 1, j] = 0;
                        start_field[i + 2, j] = 0;
                        record += 4;
                    }
                    else if (i != 6 && start_field[i, j] == start_field[i + 1, j] && start_field[i, j] == start_field[i - 1, j] && start_field[i, j] == start_field[i - 2, j] && start_field[i, j] != start_field[i + 2, j])
                    {
                        start_field[i, j] = 0;
                        start_field[i - 1, j] = 0;
                        start_field[i + 1, j] = 0;
                        start_field[i - 2, j] = 0;
                        record += 4;
                    }

                    else if (start_field[i, j] == start_field[i - 1, j] && start_field[i, j] == start_field[i + 1, j] && start_field[i, j] == start_field[i + 2, j] && start_field[i, j] == start_field[i - 2, j])
                    {
                        start_field[i, j] = 0;
                        start_field[i - 1, j] = 0;
                        start_field[i + 1, j] = 0;
                        start_field[i + 2, j] = 0;
                        start_field[i - 2, j] = 0;
                        record += 5;
                    }
                }
            }
        }

        static void check_row(ref int[,] start_field, ref int record)
        {
            for (int i = 1; i < start_field.GetLength(0); i++)
            {
                for (int j = 3; j < start_field.GetLength(1) - 2; j++)
                {
                    if (j == 3 && start_field[i, j] == start_field[i, j - 1] && start_field[i, j] == start_field[i, j - 2] && start_field[i, j] != start_field[i, j + 1])
                    {
                        start_field[i, j] = 0;
                        start_field[i, j - 1] = 0;
                        start_field[i, j - 2] = 0;
                        record += 3;
                    }
                    else if (j == 6 && start_field[i, j] == start_field[i, j + 1] && start_field[i, j] == start_field[i, j + 2] && start_field[i, j] != start_field[i, j - 1])
                    {
                        start_field[i, j] = 0;
                        start_field[i, j + 1] = 0;
                        start_field[i, j + 2] = 0;
                        record += 3;
                    }
                    else if (j != 6 && j != 3 && start_field[i, j] == start_field[i, j + 1] && start_field[i, j + 2] != start_field[i, j] && start_field[i, j] == start_field[i, j - 1] && start_field[i, j - 2] != start_field[i, j])
                    {
                        start_field[i, j] = 0;
                        start_field[i, j + 1] = 0;
                        start_field[i, j - 1] = 0;
                        record += 3;
                    }

                    else if (j == 6 && start_field[i, j] == start_field[i, j + 1] && start_field[i, j] == start_field[i, j - 1] && start_field[i, j] == start_field[i, j + 2] && start_field[i, j] != start_field[i, j - 2])
                    {
                        start_field[i, j] = 0;
                        start_field[i, j - 1] = 0;
                        start_field[i, j + 1] = 0;
                        start_field[i, j + 2] = 0;
                        record += 4;
                    }
                    else if (j != 6 && start_field[i, j] == start_field[i, j + 1] && start_field[i, j] == start_field[i, j - 1] && start_field[i, j] == start_field[i, j - 2] && start_field[i, j] != start_field[i, j + 2])
                    {
                        start_field[i, j] = 0;
                        start_field[i, j - 1] = 0;
                        start_field[i, j + 1] = 0;
                        start_field[i, j - 2] = 0;
                        record += 4;
                    }

                    else if (start_field[i, j] == start_field[i, j - 1] && start_field[i, j] == start_field[i, j + 1] && start_field[i, j] == start_field[i, j + 2] && start_field[i, j] == start_field[i, j - 2])
                    {
                        start_field[i, j] = 0;
                        start_field[i, j - 1] = 0;
                        start_field[i, j + 1] = 0;
                        start_field[i, j + 2] = 0;
                        start_field[i, j - 2] = 0;
                        record += 5;
                    }
                }                
            }
        }


            static void vivod(ref int[,] start_field)
        {
            for (int i = 0; i < start_field.GetLength(0); i++)
            {
                for (int j = 0; j < start_field.GetLength(1); j++)
                {
                    if (start_field[i, j] == 1 && (i != 0 && j != 0))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(start_field[i, j]);
                        Console.ResetColor();
                    }
                    else if (start_field[i, j] == 2 && (i != 0 && j != 0))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(start_field[i, j]);
                        Console.ResetColor();
                    }
                    else if (start_field[i, j] == 3 && (i != 0 && j != 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(start_field[i, j]);
                        Console.ResetColor();
                    }
                    else if (start_field[i, j] == 4 && (i != 0 && j != 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(start_field[i, j]);
                        Console.ResetColor();
                    }
                    else if (start_field[i,j] == 0 && (i != 0 && j != 0))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(start_field[i, j]);
                        Console.ResetColor();
                    }
                    else Console.Write(start_field[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void choice_field (ref int [,] start_field, ref int field)
        {
            if (field == 1)
            {
                start_field[1, 1] = 1; start_field[1, 2] = 1; start_field[1, 3] = 2; start_field[1, 4] = 3; start_field[1, 5] = 2; start_field[1, 6] = 1; start_field[1, 7] = 1; start_field[1, 8] = 4;
                start_field[2, 1] = 4; start_field[2, 2] = 3; start_field[2, 3] = 2; start_field[2, 4] = 1; start_field[2, 5] = 4; start_field[2, 6] = 4; start_field[2, 7] = 1; start_field[2, 8] = 3;
                start_field[3, 1] = 2; start_field[3, 2] = 2; start_field[3, 3] = 4; start_field[3, 4] = 3; start_field[3, 5] = 1; start_field[3, 6] = 3; start_field[3, 7] = 2; start_field[3, 8] = 1;
                start_field[4, 1] = 1; start_field[4, 2] = 3; start_field[4, 3] = 1; start_field[4, 4] = 4; start_field[4, 5] = 2; start_field[4, 6] = 2; start_field[4, 7] = 3; start_field[4, 8] = 4;
                start_field[5, 1] = 4; start_field[5, 2] = 2; start_field[5, 3] = 4; start_field[5, 4] = 1; start_field[5, 5] = 3; start_field[5, 6] = 2; start_field[5, 7] = 1; start_field[5, 8] = 3;
                start_field[6, 1] = 3; start_field[6, 2] = 3; start_field[6, 3] = 2; start_field[6, 4] = 3; start_field[6, 5] = 2; start_field[6, 6] = 1; start_field[6, 7] = 4; start_field[6, 8] = 2;
                start_field[7, 1] = 1; start_field[7, 2] = 4; start_field[7, 3] = 3; start_field[7, 4] = 1; start_field[7, 5] = 4; start_field[7, 6] = 3; start_field[7, 7] = 1; start_field[7, 8] = 1;
                start_field[8, 1] = 2; start_field[8, 2] = 4; start_field[8, 3] = 2; start_field[8, 4] = 4; start_field[8, 5] = 3; start_field[8, 6] = 4; start_field[8, 7] = 2; start_field[8, 8] = 3;
            }
            else if (field == 2)
            {
                start_field[1, 1] = 1; start_field[1, 2] = 3; start_field[1, 3] = 2; start_field[1, 4] = 1; start_field[1, 5] = 4; start_field[1, 6] = 1; start_field[1, 7] = 4; start_field[1, 8] = 4;
                start_field[2, 1] = 2; start_field[2, 2] = 2; start_field[2, 3] = 4; start_field[2, 4] = 4; start_field[2, 5] = 3; start_field[2, 6] = 4; start_field[2, 7] = 4; start_field[2, 8] = 1;
                start_field[3, 1] = 1; start_field[3, 2] = 3; start_field[3, 3] = 2; start_field[3, 4] = 1; start_field[3, 5] = 1; start_field[3, 6] = 3; start_field[3, 7] = 2; start_field[3, 8] = 2;
                start_field[4, 1] = 4; start_field[4, 2] = 1; start_field[4, 3] = 1; start_field[4, 4] = 2; start_field[4, 5] = 3; start_field[4, 6] = 3; start_field[4, 7] = 1; start_field[4, 8] = 3;
                start_field[5, 1] = 3; start_field[5, 2] = 1; start_field[5, 3] = 2; start_field[5, 4] = 3; start_field[5, 5] = 1; start_field[5, 6] = 1; start_field[5, 7] = 3; start_field[5, 8] = 1;
                start_field[6, 1] = 3; start_field[6, 2] = 4; start_field[6, 3] = 4; start_field[6, 4] = 2; start_field[6, 5] = 1; start_field[6, 6] = 2; start_field[6, 7] = 3; start_field[6, 8] = 2;
                start_field[7, 1] = 1; start_field[7, 2] = 2; start_field[7, 3] = 3; start_field[7, 4] = 1; start_field[7, 5] = 2; start_field[7, 6] = 3; start_field[7, 7] = 2; start_field[7, 8] = 1;
                start_field[8, 1] = 4; start_field[8, 2] = 4; start_field[8, 3] = 1; start_field[8, 4] = 3; start_field[8, 5] = 2; start_field[8, 6] = 4; start_field[8, 7] = 1; start_field[8, 8] = 3;
            }
            else if (field == 3)
            {
                start_field[1, 1] = 4; start_field[1, 2] = 1; start_field[1, 3] = 3; start_field[1, 4] = 2; start_field[1, 5] = 1; start_field[1, 6] = 4; start_field[1, 7] = 3; start_field[1, 8] = 2;
                start_field[2, 1] = 2; start_field[2, 2] = 3; start_field[2, 3] = 3; start_field[2, 4] = 4; start_field[2, 5] = 3; start_field[2, 6] = 2; start_field[2, 7] = 4; start_field[2, 8] = 3;
                start_field[3, 1] = 1; start_field[3, 2] = 1; start_field[3, 3] = 4; start_field[3, 4] = 1; start_field[3, 5] = 1; start_field[3, 6] = 4; start_field[3, 7] = 1; start_field[3, 8] = 2;
                start_field[4, 1] = 3; start_field[4, 2] = 2; start_field[4, 3] = 1; start_field[4, 4] = 2; start_field[4, 5] = 1; start_field[4, 6] = 3; start_field[4, 7] = 2; start_field[4, 8] = 4;
                start_field[5, 1] = 4; start_field[5, 2] = 3; start_field[5, 3] = 4; start_field[5, 4] = 4; start_field[5, 5] = 2; start_field[5, 6] = 3; start_field[5, 7] = 4; start_field[5, 8] = 1;
                start_field[6, 1] = 1; start_field[6, 2] = 2; start_field[6, 3] = 3; start_field[6, 4] = 1; start_field[6, 5] = 2; start_field[6, 6] = 4; start_field[6, 7] = 1; start_field[6, 8] = 2;
                start_field[7, 1] = 2; start_field[7, 2] = 3; start_field[7, 3] = 1; start_field[7, 4] = 4; start_field[7, 5] = 4; start_field[7, 6] = 3; start_field[7, 7] = 2; start_field[7, 8] = 4;
                start_field[8, 1] = 3; start_field[8, 2] = 1; start_field[8, 3] = 4; start_field[8, 4] = 2; start_field[8, 5] = 3; start_field[8, 6] = 1; start_field[8, 7] = 2; start_field[8, 8] = 3;
            }
            else if (field == 4)
            {
                start_field[1, 1] = 3; start_field[1, 2] = 3; start_field[1, 3] = 4; start_field[1, 4] = 3; start_field[1, 5] = 1; start_field[1, 6] = 2; start_field[1, 7] = 1; start_field[1, 8] = 4;
                start_field[2, 1] = 1; start_field[2, 2] = 2; start_field[2, 3] = 1; start_field[2, 4] = 1; start_field[2, 5] = 4; start_field[2, 6] = 3; start_field[2, 7] = 1; start_field[2, 8] = 3;
                start_field[3, 1] = 4; start_field[3, 2] = 1; start_field[3, 3] = 2; start_field[3, 4] = 3; start_field[3, 5] = 3; start_field[3, 6] = 4; start_field[3, 7] = 2; start_field[3, 8] = 4;
                start_field[4, 1] = 2; start_field[4, 2] = 4; start_field[4, 3] = 4; start_field[4, 4] = 4; start_field[4, 5] = 2; start_field[4, 6] = 1; start_field[4, 7] = 3; start_field[4, 8] = 1;
                start_field[5, 1] = 3; start_field[5, 2] = 1; start_field[5, 3] = 3; start_field[5, 4] = 1; start_field[5, 5] = 4; start_field[5, 6] = 3; start_field[5, 7] = 1; start_field[5, 8] = 3;
                start_field[6, 1] = 1; start_field[6, 2] = 3; start_field[6, 3] = 3; start_field[6, 4] = 2; start_field[6, 5] = 1; start_field[6, 6] = 2; start_field[6, 7] = 4; start_field[6, 8] = 3;
                start_field[7, 1] = 4; start_field[7, 2] = 2; start_field[7, 3] = 1; start_field[7, 4] = 4; start_field[7, 5] = 3; start_field[7, 6] = 2; start_field[7, 7] = 1; start_field[7, 8] = 2;
                start_field[8, 1] = 4; start_field[8, 2] = 2; start_field[8, 3] = 2; start_field[8, 4] = 1; start_field[8, 5] = 3; start_field[8, 6] = 1; start_field[8, 7] = 2; start_field[8, 8] = 4;
            }
            
        }

       
        public static void swap(ref int x1,ref int y1)
        {
            int dop;
            dop = x1;
            x1 = y1;
            y1 = dop;
        }
        static void gameplay(ref int x,ref int y)
        {
             
                k = Console.ReadKey();

            if (k.Key == ConsoleKey.LeftArrow)
                y--;
            else if (k.Key == ConsoleKey.RightArrow)
                y++;
            else if (k.Key == ConsoleKey.DownArrow)
                x++;
            else if (k.Key == ConsoleKey.UpArrow)
                x--;         
        }

        static ConsoleKeyInfo k = new ConsoleKeyInfo();
        static void Draw(int x,int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            
        }
    }
}
