using System;

namespace gggame
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Тест игры";
            Console.Clear();

            int PlayerHP = 10;
            int PlayerAttack = 1;
            int PlayerXP = 0;
            int PlayerLevel = 1;

            string EnemyName;
            int EnemyAttack;
            int EnemyHitPoints;
            int EnemyXP;

            Enemy Goblin = new Enemy();
            Goblin.Name = "Гоблин";
            Goblin.HitPoints = 10;
            Goblin.Attack = 1;
            Goblin.XP = 2;
            Enemy Bandit = new Enemy();
            Goblin.Name = "Бандит";
            Goblin.HitPoints = 50;
            Goblin.Attack = 5;
            Goblin.XP = 10;
            Enemy Golem = new Enemy();
            Golem.Name = "Голем";
            Golem.HitPoints = 100;
            Golem.Attack = 10;
            Golem.XP = 20;
            Enemy Salamandra = new Enemy();
            Goblin.Name = "Саламандра";
            Goblin.HitPoints = 500;
            Goblin.Attack = 50;
            Goblin.XP = 100;
            Enemy Dragon = new Enemy();
            Dragon.Name = "Дракон";
            Dragon.HitPoints = 1000;
            Dragon.Attack = 100;
            Dragon.XP = 200;



            int xy = 0;

            do
            {
                
                SayLine("Жми Enter", ConsoleColor.White);
                SayLine("---", ConsoleColor.Cyan);

                Random_Enemy();
                Random_Weapon();

                Console.ReadLine();
                SayLine("---", ConsoleColor.Cyan);
                if (xy == 666)
                {
                    break;
                }
                Console.Clear();
            }
            while (xy == 0);
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


        //     The example displays output like the following:
        //     All the foreground colors except DarkCyan, the background color:
        //       The foreground color is Black.
        //       The foreground color is DarkBlue.
        //       The foreground color is DarkGreen.
        //       The foreground color is DarkRed.
        //       The foreground color is DarkMagenta.
        //       The foreground color is DarkYellow.
        //       The foreground color is Gray.
        //       The foreground color is DarkGray.
        //       The foreground color is Blue.
        //       The foreground color is Green.
        //       The foreground color is Cyan.
        //       The foreground color is Red.
        //       The foreground color is Magenta.
        //       The foreground color is Yellow.
        //       The foreground color is White.

        private static int Freak_random(int x, int y)
        {
            Random rand = new Random();
            int freak_random = rand.Next(x, y);
            return freak_random;
        }

        private static void Random_Enemy()
        {

            string EnemyName = "Enemy";
            int EnemyAttack = 0;
            int EnemyHitPoints = 0;
            int EnemyXP = 0;

            Enemy Goblin = new Enemy
            {
                Name = "Гоблин",
                HitPoints = 10,
                Attack = 1,
                XP = 2
            };
            Enemy Bandit = new Enemy
            {
                Name = "Бандит",
                HitPoints = 50,
                Attack = 5,
                XP = 10
            };
            Enemy Golem = new Enemy
            {
                Name = "Голем",
                HitPoints = 100,
                Attack = 10,
                XP = 20
            };
            Enemy Salamandra = new Enemy
            {
                Name = "Саламандра",
                HitPoints = 500,
                Attack = 50,
                XP = 100
            };
            Enemy Dragon = new Enemy
            {
                Name = "Дракон",
                HitPoints = 1000,
                Attack = 100,
                XP = 200
            };

            Enemy[] Enemys = new Enemy[5];
            Enemys[0] = Goblin;
            Enemys[1] = Bandit;
            Enemys[2] = Golem;
            Enemys[3] = Salamandra;
            Enemys[4] = Dragon;

            int EnemyChance = Freak_random(0, 1000);
            SayLine("Нарандомило:" + EnemyChance, ConsoleColor.DarkCyan);

            if (EnemyChance >= 905)
                EnemyName = Enemys[4].Name;
            EnemyAttack = Enemys[4].Attack;
            EnemyHitPoints = Enemys[4].HitPoints;

            if (EnemyChance >= 800 && EnemyChance < 950)
                EnemyName = Enemys[3].Name;
            EnemyAttack = Enemys[3].Attack;
            EnemyHitPoints = Enemys[3].HitPoints;

            if (EnemyChance >= 550 && EnemyChance < 800)
                EnemyName = Enemys[2].Name;
            EnemyAttack = Enemys[2].Attack;
            EnemyHitPoints = Enemys[2].HitPoints;

            if (EnemyChance >= 250 && EnemyChance < 550)
                EnemyName = Enemys[1].Name;
            EnemyAttack = Enemys[1].Attack;
            EnemyHitPoints = Enemys[1].HitPoints;

            if (EnemyChance < 250)
                EnemyName = Enemys[0].Name;
            EnemyAttack = Enemys[0].Attack;
            EnemyHitPoints = Enemys[0].HitPoints;

            Say("Появился:", ConsoleColor.Magenta);
            SayLine(EnemyName, ConsoleColor.Red);
        }

        private static void Random_Weapon()
        {
            string[] RareWeapon;
            RareWeapon = new string[5];
            RareWeapon[0] = "Легендарный Меч 'Экскалибур'";
            RareWeapon[1] = "Легендарный Меч 'Каладболг'";
            RareWeapon[2] = "Легендарный Меч 'Бальмунг'";
            RareWeapon[3] = "Легендарный Меч 'Дюрендаль'";
            RareWeapon[4] = "Легендарный Меч 'Коготь Шарона'";

            string[] CommonWeapon;
            CommonWeapon = new string[5];
            CommonWeapon[0] = "Волшебный меч";
            CommonWeapon[1] = "Стальной меч";
            CommonWeapon[2] = "Закалённый меч";
            CommonWeapon[3] = "Железный меч";
            CommonWeapon[4] = "Деревянный меч";

            int WeaponChance = Freak_random(0, 1000);

            SayLine("Нарандомило число:" + WeaponChance, ConsoleColor.DarkCyan);
            Say("Выпало оружие:", ConsoleColor.Magenta);

            if (WeaponChance >= 950)
                SayLine(RareWeapon[Freak_random(0, 5)], ConsoleColor.DarkYellow);
            if (WeaponChance >= 800 && WeaponChance < 950)
                SayLine(CommonWeapon[0], ConsoleColor.Blue);
            if (WeaponChance >= 550 && WeaponChance < 800)
                SayLine(CommonWeapon[Freak_random(1, 2)], ConsoleColor.Cyan);
            if (WeaponChance >= 250 && WeaponChance < 550)
                SayLine(CommonWeapon[3], ConsoleColor.Green);
            if (WeaponChance < 250)
                SayLine(CommonWeapon[Freak_random(4, 5)], ConsoleColor.DarkGray);
        }

    }
}
