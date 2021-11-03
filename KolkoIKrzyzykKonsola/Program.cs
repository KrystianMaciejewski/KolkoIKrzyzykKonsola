using System;

namespace KolkoIKrzyzykKonsola
{

    class Program
    {
        static string[,] plansza = new string[,]
{
                {"[]", "[]", "[]" },
                {"[]", "[]", "[]" },
                {"[]", "[]", "[]" }
};

        static void Main(string[] args)
        {

            Console.WriteLine("Witaj! oto gra Kolko i Krzyzyk! Projekt finansowany by doktor Ola");
            Console.WriteLine("Nacisnij dowolny klawisz, aby kontynuowac");
            Console.ReadKey();
            int x = 2;
            while (wygrana())
            {
                if (x == 1)
                    x++;
                else
                    x--;
                tura(x);
               
            }
            Console.WriteLine("Wygrywa gracz nr " + x);
            Console.ReadKey();

        }

        static public void tura(int numerGracza)
        {
            Console.Clear();
            Console.WriteLine("Tura gracza: " + numerGracza);
            rysujPlansze();
            int x, y;
            bool success;
            do
            {
                do
                {
                    Console.WriteLine("Podaj numer wiersza, w którym chcesz postawić swój znak");
                    string iks = Console.ReadLine();
                    success = int.TryParse(iks, out x);
                } while (!success);

                do {
                    Console.WriteLine("Podaj numer kolumny, w którym chcesz postawić swój znak");
                    string igrek = Console.ReadLine();
                    success = int.TryParse(igrek, out y);
                } while (!success);
            } while (czyPoleJestPuste(x, y));
            zmianaZnaku(x, y, numerGracza);
            Console.Clear();
            Console.WriteLine("aktualny stan planszy");
            rysujPlansze();
            Console.WriteLine("Nacisnij dowolny klawisz, aby kontynuowac");
            Console.ReadKey();


        }
        static public void rysujPlansze()
        {
            for (int i = 0; i < plansza.GetLength(0); i++)
            {
                for (int j = 0; j < plansza.GetLength(1); j++)
                {
                    Console.Write(plansza[i, j]);
                }
                Console.WriteLine();
                
            }
            //Console.ReadKey();
        }
        static public void zmianaZnaku(int x, int y, int numerGracza)
        {
            string znak;
            if(numerGracza == 1){
                znak = "x";
            }
            else
            {
                znak = "O";
            }
            plansza[x, y] = "[" + znak + "]";
        }
        static public bool czyPoleJestPuste(int x, int y)
        {
            if (plansza[x, y] != "[]")
            {
                Console.WriteLine("To pole jest zajete! Sproboj ponownie");
                return true;
            }
            else
                return false;
        }
        static public bool wygrana()
        {
            for (int i = 0; i < plansza.GetLength(0); i++)
            {
                if (plansza[i, 0] != "[]" && plansza[i, 0] == plansza[i, 1] && plansza[i, 0] == plansza[i, 2])
                {
                    return false;
                }

            }
            if (plansza[0, 0] != "[]" && plansza[0, 0] == plansza[1, 1] && plansza[1, 1] == plansza[2, 2])
            {
                return false;
            }
            if (plansza[0, 2] != "[]" && plansza[0, 2] == plansza[1, 1] && plansza[1, 1] == plansza[2, 0])
            {
                return false;
            }

            return true;
        }
    }
}
