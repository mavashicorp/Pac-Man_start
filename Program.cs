﻿

            Console.CursorVisible = false;//отключам курсор ввода
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},//внешняя стена
                {'#',' ','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','O','#'},
                {'#',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#','#',' ',' ',' ',' ','O',' ',' ',' ',' ',' ','O',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#',' ',' ',' ',' ','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','O',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ','#',' ',' ','#','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#','#','#','#',' ',' ',' ',' ','#',' ','#',' ',' ',' ','O',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ','O',' ',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            };

            int userX = 6; int userY = 6;//координаты игрока
            char[] bag = new char[1];



            while (true)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Сумка: ");

                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(0, 0);//устанавливаем позицию карты
                //нужно учитывать что система координат в консоли считается слева направо и сверху в низ


                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }


                Console.SetCursorPosition(userY, userX);//позиция игрока. Меняем местами координаты XY
                Console.Write('@');//персонаж

                ConsoleKeyInfo charKey = Console.ReadKey();//реализация управления персонажем. В переменную получаем сторону движения
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != '#')
                        {
                            userX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '#')
                        {
                            userY++;
                        }
                        break;
                }

                if (map[userX, userY] == 'O')//ищем золото
                {
                    map[userX, userY] = '*';//что будет после сбора золота
                    char[] tempBag = new char[bag.Length + 1];//создаем второй массив который больше прошлого на 1
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 1] = 'O';
                    bag = tempBag;
                }

                //Console.ReadKey();//что бы замедлить вывод на экран
                Console.Clear();//что бы карта не зарисовывала персонажа

                //конец while
            }

