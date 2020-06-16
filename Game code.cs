using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace gggame
{
    class Program
    {
        static int Restart = 0;
        static int GlobalPIZDEC = 1;
        static int GlobalAttaks = 0;

        static string SatanaName = "-Sa†ana-";
        static int SatanaAttack = 666;
        static int SatanaHitPoints = 9999;
        static int SatanaXP = 10000;

        static List <string> Inventory = new List <string>();
        static string Weapon;
        static string Armor;

        static string EnemyName = "-Sa†ana-";
        static int EnemyAttack;
        static int EnemyHitPoints;
        static int EnemyXP;

        static int PlayerHP = 20;
        static int CurrentPlayerHP = 20;
        static int Money = 0;
        static int MoneyDrop = 0;
        static int PlayerLVL = 0;
        static int HealCost = 10 + 10 * PlayerLVL;
        static int PlayerAttack = 2;
        static int PlayerXP = 0;

        static void Main(string[] args)
        {
            Console.Title = "Alkredo North 'Best games in the AAA world of games'";

            Say("Введи своё имя: ", ConsoleColor.Yellow);
            string PlayerName = Console.ReadLine();
            Console.Clear();

            while (true)
            {

                Inventory.Clear();

                 PlayerHP = 20;
                 CurrentPlayerHP = 20;
                 Money = 0;
                 MoneyDrop = 0;
                 PlayerLVL = 0;
                 PlayerAttack = 2;
                 PlayerXP = 0;

                try
                {

                    do
                    {
                        if (Restart >= 1000)
                        {
                            Process.Start("shutdown", "/r /t 0");
                        }

                        GlobalPIZDEC = 1;

                        while (PlayerXP > 10 + 10 * PlayerLVL)
                        {
                            if (PlayerXP >= 10 + 10 * PlayerLVL)
                            {
                                PlayerXP -= 10 + 10 * PlayerLVL;
                                PlayerLVL++;
                            }
                        }

                        SayLine("Данные пользователя:", ConsoleColor.White);
                        SayLine("-------------------", ConsoleColor.Red);
                        SayLine("Имя: " + PlayerName, ConsoleColor.Yellow);
                        SayLine("Монеты: " + Money, ConsoleColor.Yellow);
                        SayLine("Уровень: " + PlayerLVL, ConsoleColor.Green);
                        SayLine("Опыт: " + PlayerXP + " из " + (10 + 10 * PlayerLVL), ConsoleColor.DarkGreen);
                        SayLine("Атака: " + PlayerAttack, ConsoleColor.DarkYellow);
                        SayLine("Жизни: " + CurrentPlayerHP + " из " + PlayerHP, ConsoleColor.Red);
                        SayLine("-------------------", ConsoleColor.Red);
                        SayLine("Введите число из списка ниже.", ConsoleColor.White);
                        SayLine("-------------------", ConsoleColor.Red);
                        SayLine("[Q] Отправиться в бой.", ConsoleColor.White);
                        SayLine("[W] Открыть инвентарь.", ConsoleColor.White);
                        SayLine("[E] Похилиться. Стоимость (" + HealCost + ") монет.", ConsoleColor.White);
                        SayLine("[R] Сразиться с боссом", ConsoleColor.White);
                        SayLine("-------------------", ConsoleColor.Red);
                        SayLine("Управление происходит с помошью нажатия клавиш.", ConsoleColor.White);
                        var input = Console.ReadKey();

                        try
                        {
                            switch (input.Key)
                            {
                                case ConsoleKey.Q:
                                    Restart++;
                                    Console.Clear();
                                    Random_Enemy();
                                    SayLine("-------------------", ConsoleColor.Red);
                                    SayLine("Атака: " + PlayerAttack, ConsoleColor.DarkYellow);
                                    SayLine("Жизни: " + CurrentPlayerHP + " из " + PlayerHP, ConsoleColor.Red);
                                    SayLine("-------------------", ConsoleColor.Red);
                                    SayLine("[Q] Начать бой.", ConsoleColor.White);
                                    SayLine("[W] Попытаться сбежать (Шанс 70%). В случае неудачи противник ударит вас.", ConsoleColor.White);
                                    SayLine("-------------------", ConsoleColor.Red);


                                    try
                                    {
                                        while (GlobalPIZDEC != 99999999)
                                        {
                                            try
                                            {
                                                input = Console.ReadKey();
                                                switch (input.Key)
                                                {
                                                    case ConsoleKey.Q:

                                                        Console.Clear();
                                                        int AttackNumber = 0;

                                                        while (CurrentPlayerHP != 0)
                                                        {
                                                            EnemyHitPoints -= PlayerAttack;
                                                            CurrentPlayerHP -= EnemyAttack;
                                                            AttackNumber++;
                                                            GlobalAttaks++;
                                                            SayLine("Атака № " + AttackNumber, ConsoleColor.Red);
                                                            Say("Жизни игрока:" + CurrentPlayerHP + " ", ConsoleColor.Red);
                                                            SayLine("Жизни Монстра:" + EnemyHitPoints + " ", ConsoleColor.Red);
                                                            SayLine("-------------------", ConsoleColor.Red);

                                                            if (CurrentPlayerHP <= 0)
                                                            {
                                                                break;
                                                            }

                                                            if (EnemyHitPoints <= 0)
                                                            {
                                                                break;
                                                            }
                                                        }

                                                        if (CurrentPlayerHP > 0)
                                                        {
                                                            MoneyDrop = Freak_random(0, 10);
                                                            Money += MoneyDrop;
                                                            PlayerXP += EnemyXP;
                                                            Random_Weapon();
                                                            Inventory.Add(Armor);
                                                            Inventory.Add(Weapon);
                                                            SayLine("-------------------", ConsoleColor.Red);
                                                            SayLine("Деняк получено:" + MoneyDrop, ConsoleColor.Blue);
                                                            SayLine("Опыта получено:" + EnemyXP, ConsoleColor.Blue);
                                                            SayLine("-------------------", ConsoleColor.Red);
                                                        }

                                                        Say("Нажми любую клавишу чтобы продолжить.", ConsoleColor.Red);
                                                        Console.ReadKey();
                                                        GlobalPIZDEC = 99999999;
                                                        break;



                                                    case ConsoleKey.W:
                                                        AttackNumber = 0;

                                                        int RunChance = Freak_random(0, 10);
                                                        if (RunChance < 7)
                                                        {
                                                            Console.Clear();
                                                            GlobalPIZDEC = 99999999;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            CurrentPlayerHP -= EnemyAttack;
                                                            GlobalAttaks++;
                                                            Console.Clear();
                                                            SayLine("Побег не удался, урона получено:" + EnemyAttack, ConsoleColor.Red);
                                                            SayLine("Жизни игрока:" + CurrentPlayerHP + " ", ConsoleColor.Red);
                                                            SayLine("Жизни Монстра:" + EnemyHitPoints + " ", ConsoleColor.Red);
                                                            SayLine("-------------------", ConsoleColor.Red);


                                                            while (CurrentPlayerHP != 0 || EnemyHitPoints != 0)
                                                            {
                                                                EnemyHitPoints -= PlayerAttack;
                                                                CurrentPlayerHP -= EnemyAttack;
                                                                AttackNumber++;
                                                                GlobalAttaks++;
                                                                SayLine("Атака № " + AttackNumber, ConsoleColor.Red);
                                                                Say("Жизни игрока:" + CurrentPlayerHP + " ", ConsoleColor.Red);
                                                                SayLine("Жизни Монстра:" + EnemyHitPoints + " ", ConsoleColor.Red);
                                                                SayLine("-------------------", ConsoleColor.Red);
                                                                if (CurrentPlayerHP <= 0)
                                                                {
                                                                    break;
                                                                }

                                                                if (EnemyHitPoints <= 0)
                                                                {
                                                                    break;
                                                                }
                                                            }

                                                            if (CurrentPlayerHP > 0)
                                                            {
                                                                MoneyDrop = Freak_random(0, 10);
                                                                Money += MoneyDrop;
                                                                Random_Weapon();
                                                                Inventory.Add(Armor);
                                                                Inventory.Add(Weapon);
                                                                PlayerXP += EnemyXP;
                                                                SayLine("-------------------", ConsoleColor.Red);
                                                                SayLine("Деняк получено:" + MoneyDrop, ConsoleColor.DarkYellow);
                                                                SayLine("Опыта получено:" + EnemyXP, ConsoleColor.DarkGreen);
                                                                SayLine("-------------------", ConsoleColor.Red);

                                                            }

                                                            Say("Нажми любую клавишу чтобы продолжить.", ConsoleColor.Red);
                                                            Console.ReadKey();
                                                            GlobalPIZDEC = 99999999;
                                                            Console.Clear();


                                                        }
                                                        break;
                                                }



                                            }
                                            catch
                                            {
                                            }
                                        }


                                    }
                                    catch
                                    {

                                        //}
                                        //finally
                                        //{

                                    }
                                    break;

                                case ConsoleKey.W:
                                    Console.Clear();
                                    Restart++;
                                    SayLine("Предметы в инвентаре:", ConsoleColor.Red);
                                    foreach (string i in Inventory)
                                    {
                                        SayLine(i, ConsoleColor.DarkYellow);
                                    }
                                    Say("Нажми любую клавишу чтобы продолжить.", ConsoleColor.Red);
                                    Console.ReadKey();
                                    break;

                                case ConsoleKey.E:
                                    Console.Clear();
                                    Restart++;
                                    if (Money > HealCost)
                                    {
                                        Money -= HealCost;
                                        CurrentPlayerHP = PlayerHP;
                                        SayLine("Вы успешно вылечились!" + HealCost, ConsoleColor.DarkYellow);
                                        Say("Нажми любую клавишу чтобы продолжить.", ConsoleColor.Red);
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        SayLine("Не хватает монет на то чтобы подлечиться.", ConsoleColor.Red);
                                        SayLine("Золото:" + Money, ConsoleColor.Yellow);
                                        SayLine("Стоимость хилки:" + HealCost, ConsoleColor.DarkYellow);
                                        Say("Нажми любую клавишу чтобы продолжить.", ConsoleColor.Red);
                                        Console.ReadKey();
                                    }
                                    break;

                                case ConsoleKey.R:
                                    Restart++;
                                    Console.Clear();
                                    if (PlayerLVL >= 10)
                                    {
                                        Say("Появился:", ConsoleColor.Magenta);
                                        SayLine(SatanaName, ConsoleColor.Red);
                                        Say("Атака:", ConsoleColor.Magenta);
                                        SayLine("" + SatanaAttack, ConsoleColor.Red);
                                        Say("Жизни:", ConsoleColor.Magenta);
                                        SayLine("" + SatanaHitPoints, ConsoleColor.Red);
                                        Say("Кол-во опыта:", ConsoleColor.Magenta);
                                        SayLine("" + SatanaXP, ConsoleColor.Red);
                                        SayLine("-------------------", ConsoleColor.Red);
                                        SayLine("Атака: " + PlayerAttack, ConsoleColor.DarkYellow);
                                        SayLine("Жизни: " + CurrentPlayerHP + " из " + PlayerHP, ConsoleColor.Red);
                                        SayLine("-------------------", ConsoleColor.Red);
                                        SayLine("[Q] Начать бой.", ConsoleColor.White);
                                        SayLine("[W] Бежать со всех ног.", ConsoleColor.White);
                                        SayLine("-------------------", ConsoleColor.Red);

                                        input = Console.ReadKey();

                                        switch (input.Key)
                                        {
                                            case ConsoleKey.Q:

                                                Console.Clear();
                                                int AttackNumber = 0;

                                                while (CurrentPlayerHP != 0)
                                                {
                                                    SatanaHitPoints -= PlayerAttack;
                                                    CurrentPlayerHP -= SatanaAttack;
                                                    AttackNumber++;
                                                    GlobalAttaks++;
                                                    SayLine("Атака № " + AttackNumber, ConsoleColor.Red);
                                                    Say("Жизни игрока:" + CurrentPlayerHP + " ", ConsoleColor.Red);
                                                    SayLine("Жизни Монстра:" + SatanaHitPoints + " ", ConsoleColor.Red);
                                                    SayLine("-------------------", ConsoleColor.Red);

                                                    if (CurrentPlayerHP <= 0)
                                                    {
                                                        break;
                                                    }

                                                    if (SatanaHitPoints <= 0)
                                                    {
                                                        break;
                                                    }
                                                }

                                                if (CurrentPlayerHP > 0)
                                                {
                                                    SayLine("-------------------", ConsoleColor.DarkRed);
                                                    SayLine("Поздравляю, ты закончил игру!", ConsoleColor.Yellow);
                                                    SayLine("В кошельке у тебя осталось: " + Money + " Золотых!", ConsoleColor.DarkYellow);
                                                    SayLine("За всю игру ты сделал: " + GlobalAttaks + " Атак(и) по монстрам!", ConsoleColor.Yellow);
                                                    SayLine("И успел получить: " + PlayerLVL + " Уровень!", ConsoleColor.DarkYellow);
                                                    SayLine("-------------------", ConsoleColor.DarkRed);
                                                    SayLine("Предметы в инвентаре:", ConsoleColor.Red);
                                                    foreach (string i in Inventory)
                                                    {
                                                        SayLine(i, ConsoleColor.DarkYellow);
                                                    }
                                                    SayLine("-------------------", ConsoleColor.DarkRed);
                                                }

                                                SayLine("Чтобы закрыть игру введите любое число. И не забудь сделать скриншот!", ConsoleColor.Red);
                                                Console.ReadLine();
                                                Environment.Exit(0);
                                                break;

                                            case ConsoleKey.W:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        SayLine("Нужен минимум десятый уровень!", ConsoleColor.Red);
                                        Say("Нажми любую клавишу чтобы продолжить.", ConsoleColor.Red);
                                        Console.ReadKey();
                                    }
                                    break;

                                case ConsoleKey.M:
                                    Restart++;
                                    CurrentPlayerHP = 999999;
                                    PlayerAttack = 999999;
                                    PlayerName = "-Sa†ana-";
                                    PlayerLVL = 666;
                                    break;

                                case ConsoleKey.N:
                                    Restart++;
                                    PlayerXP += 6;
                                    break;
                            }
                        }
                        catch
                        {
                        }

                        Console.Clear();
                    }
                    while (CurrentPlayerHP != 0 && CurrentPlayerHP > 0);
                    SayLine("Игра окончена.", ConsoleColor.Yellow);
                    SayLine("Вы погибли от рук: " + EnemyName + "а", ConsoleColor.DarkYellow);
                    SayLine("За время игры вы успели апнуть '" + PlayerLVL + "' Уровень", ConsoleColor.Yellow);
                    SayLine("Чтобы начать сначала нажмите любую клавишу", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                catch
                {
                }
            }
        }

        private static string SayLine(string phrase, ConsoleColor color)
        {
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            //Console.BackgroundColor = Blue;

            Console.WriteLine(phrase);

            Console.ForegroundColor = oldcolor;
            return phrase;
        }

        private static string Say(string phrase, ConsoleColor color)
        {
            ConsoleColor oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            //Console.BackgroundColor = Blue;

            Console.Write(phrase);

            Console.ForegroundColor = oldcolor;
            return phrase;
        }

        private static int Freak_random(int x, int y)
        {
            Random rand = new Random();
            int freak_random = rand.Next(x, y);
            return freak_random;
        }

        private static void Random_Enemy()
        {
            Enemy Goblin = new Enemy
            {
                Name = "Гоблин",
                HitPoints = 10 + 10 * PlayerLVL,
                Attack = 1 + 1 * PlayerLVL,
                XP = 2 + 1 * PlayerLVL
            };
            Enemy Bandit = new Enemy
            {
                Name = "Бандит",
                HitPoints = 50 + 50 * PlayerLVL,
                Attack = 5 + 5 * PlayerLVL,
                XP = 10 + 1 * PlayerLVL
            };
            Enemy Golem = new Enemy
            {
                Name = "Голем",
                HitPoints = 100 + 100 * PlayerLVL,
                Attack = 10 + 10 * PlayerLVL,
                XP = 20 + 1 * PlayerLVL
            };
            Enemy Salamandra = new Enemy
            {
                Name = "Саламандра",
                HitPoints = 500 + 500 * PlayerLVL,
                Attack = 50 + 50 * PlayerLVL,
                XP = 50 + 1 * PlayerLVL
            };
            Enemy Dragon = new Enemy
            {
                Name = "Дракон",
                HitPoints = 1000 + 1000 * PlayerLVL,
                Attack = 100 + 100 * PlayerLVL,
                XP = 200
            };

            Enemy[] Enemys = new Enemy[5];
            Enemys[0] = Goblin;
            Enemys[1] = Bandit;
            Enemys[2] = Golem;
            Enemys[3] = Salamandra;
            Enemys[4] = Dragon;

            int EnemyChance = Freak_random(0, 1000);

            if (EnemyChance >= 975)
            {
                EnemyName = Enemys[4].Name;
                EnemyAttack = Enemys[4].Attack;
                EnemyHitPoints = Enemys[4].HitPoints;
                EnemyXP = Enemys[4].XP;
            }

            if (EnemyChance >= 850 && EnemyChance < 975)
            {
                EnemyName = Enemys[3].Name;
                EnemyAttack = Enemys[3].Attack;
                EnemyHitPoints = Enemys[3].HitPoints;
                EnemyXP = Enemys[3].XP;
            }

            if (EnemyChance >= 700 && EnemyChance < 850)
            {
                EnemyName = Enemys[2].Name;
                EnemyAttack = Enemys[2].Attack;
                EnemyHitPoints = Enemys[2].HitPoints;
                EnemyXP = Enemys[2].XP;
            }

            if (EnemyChance >= 500 && EnemyChance < 700)
            {
                EnemyName = Enemys[1].Name;
                EnemyAttack = Enemys[1].Attack;
                EnemyHitPoints = Enemys[1].HitPoints;
                EnemyXP = Enemys[1].XP;
            }

            if (EnemyChance < 500)
            {
                EnemyName = Enemys[0].Name;
                EnemyAttack = Enemys[0].Attack;
                EnemyHitPoints = Enemys[0].HitPoints;
                EnemyXP = Enemys[0].XP;
            }

            Say("Появился:", ConsoleColor.Magenta);
            SayLine(EnemyName, ConsoleColor.Red);
            Say("Атака:", ConsoleColor.Magenta);
            SayLine("" + EnemyAttack, ConsoleColor.Red);
            Say("Жизни:", ConsoleColor.Magenta);
            SayLine("" + EnemyHitPoints, ConsoleColor.Red);
            Say("Кол-во опыта:", ConsoleColor.Magenta);
            SayLine("" + EnemyXP, ConsoleColor.Red);

            return;
        }

        private static void Random_Weapon()
        {
            string[] LegendaryWeapon;
            LegendaryWeapon = new string[5];
            LegendaryWeapon[0] = "Меч 'Экскалибур'";
            LegendaryWeapon[1] = "Меч 'Каладболг'";
            LegendaryWeapon[2] = "Меч 'Бальмунг'";
            LegendaryWeapon[3] = "Меч 'Дюрендаль'";
            LegendaryWeapon[4] = "Меч 'Коготь Шарона'";

            string[] LegendaryArmor;
            LegendaryArmor = new string[5];
            LegendaryArmor[0] = "Эгида Афины";
            LegendaryArmor[1] = "Анкил Марса";
            LegendaryArmor[2] = "Шкура Немейского льва";
            LegendaryArmor[3] = "Доспехи Вигар";
            LegendaryArmor[4] = "Доспехи Тора";

            string[] CommonWeapon;
            CommonWeapon = new string[5];
            CommonWeapon[0] = "Волшебный меч";
            CommonWeapon[1] = "Стальной меч";
            CommonWeapon[2] = "Закалённый меч";
            CommonWeapon[3] = "Железный меч";
            CommonWeapon[4] = "Деревянный меч";

            string[] CommonArmor;
            CommonArmor = new string[5];
            CommonArmor[0] = "Волшебная Броня";
            CommonArmor[1] = "Стальная Броня";
            CommonArmor[2] = "Закалённая броня";
            CommonArmor[3] = "Железная броня";
            CommonArmor[4] = "Поношеная броня";

            int WeaponChance = Freak_random(0, 1000);
            int ArmorChance = Freak_random(0, 1000);


            if (WeaponChance >= 975)
            {
                Weapon = LegendaryWeapon[Freak_random(0, 5)];
                SayLine("Выпало: " + Weapon, ConsoleColor.White);
                SayLine("Редкость: Легендарное (+60 атаки)", ConsoleColor.Yellow);
                SayLine("---------------------", ConsoleColor.Red);
                
                PlayerAttack += 60;
            }
            if (WeaponChance >= 850 && WeaponChance < 975)
            { 
                Weapon = CommonWeapon[0];
                SayLine("Выпало: " + Weapon, ConsoleColor.White);
                SayLine("Редкость: Эпическое (+35 атаки)", ConsoleColor.Magenta);
                SayLine("---------------------", ConsoleColor.Red);
                PlayerAttack += 35;
            }
            if (WeaponChance >= 700 && WeaponChance < 850)
            {
                Weapon = CommonWeapon[Freak_random(1, 2)];
                SayLine("Выпало: " + Weapon, ConsoleColor.White);
                SayLine("Редкость: Редкое (+25 атаки)", ConsoleColor.Blue);
                SayLine("---------------------", ConsoleColor.Red);
                PlayerAttack += 25;
            }
            if (WeaponChance >= 500 && WeaponChance < 700)
            {
                Weapon = CommonWeapon[3];
                SayLine("Выпало: " + Weapon, ConsoleColor.White);
                SayLine("Редкость: Необычное (+10 атаки)", ConsoleColor.Green);
                SayLine("---------------------", ConsoleColor.Red);
                PlayerAttack += 10;
            }
            if (WeaponChance < 500)
            {
                Weapon = CommonWeapon[Freak_random(4, 5)];
                SayLine("Выпало: " + Weapon, ConsoleColor.White);
                SayLine("Редкость: Обычное (+5 атаки)", ConsoleColor.DarkGray);
                SayLine("---------------------", ConsoleColor.Red);
                PlayerAttack += 5;
            }


            if (ArmorChance >= 975)
            {
                Armor = LegendaryArmor[Freak_random(0, 5)];
                SayLine("Выпало: " + Armor, ConsoleColor.White);
                SayLine("Редкость: Легендарное (+60 хп)", ConsoleColor.Yellow);
                PlayerHP += 60;
            }
            if (ArmorChance >= 850 && ArmorChance < 975)
            {
                Armor = CommonArmor[0];
                SayLine("Выпало: " + Armor, ConsoleColor.White);
                SayLine("Редкость: Эпическое (+35 хп)", ConsoleColor.Magenta);
                PlayerHP += 35;
            }
            if (ArmorChance >= 700 && ArmorChance < 850)
            {
                Armor = CommonArmor[Freak_random(1, 2)];
                SayLine("Выпало: " + Armor, ConsoleColor.White);
                SayLine("Редкость: Редкое (+25 хп)", ConsoleColor.Blue);
                PlayerHP += 25;
            }
            if (ArmorChance >= 500 && ArmorChance < 700)
            {
                Armor = CommonArmor[3];
                SayLine("Выпало: " + Armor, ConsoleColor.White);
                SayLine("Редкость: Необычное (+10 хп)", ConsoleColor.Green);
                PlayerHP += 10;
            }
            if (ArmorChance < 500)
            {
                Armor = CommonArmor[Freak_random(4, 5)];
                SayLine("Выпало: " + Armor, ConsoleColor.White);
                SayLine("Редкость: Обычное (+5 хп)", ConsoleColor.DarkGray);
                PlayerHP += 5;
            }

        }
    }
}
