using System;
using System.Drawing;
using System.IO;

namespace Dottor.ImageBitmap
{
    class Program
    {
        static void Main(string[] args)
        {
            // step1 creazione immagine con dimensioni scelte dall'utente
            var height = GetUserInput("Altezza dell'immagine");
            var width = GetUserInput("Larghezza dell'immagine");
            var image = new Bitmap(width, height);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Premere '1' per Quadrato vuoto");
                Console.WriteLine("Premere '2' per Quadrato pieno");
                Console.WriteLine("Premere '3' per figure complesse");

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Step2(image);
                        exit = true;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Step3(image);
                        exit = true;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Step4(image);
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Scelta non valida.");
                        Console.ResetColor();
                        break;
                }
            }

            image.Save(Path.Combine(Directory.GetCurrentDirectory(), "image.bmp"));
            Console.WriteLine("END");
            Console.ReadLine();
        }

        private static void Step2(Bitmap image)
        {
            var size = GetUserInput("Lato del quadrato");

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (x == 0 || x == size - 1 || y == 0 || y == size - 1)
                    {
                        image.SetPixel(x, y, Color.Red);
                    }
                }
            }
        }

        private static void Step3(Bitmap image)
        {
            var size = GetUserInput("Lato del quadrato");

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    image.SetPixel(x, y, Color.Red);
                }
            }
        }

        private static void Step4(Bitmap image)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                var x = GetUserInput("Rettangolo dato X");
                var y = GetUserInput("Rettangolo dato Y");
                var height = GetUserInput("Rettangolo dato height");
                var width = GetUserInput("Rettangolo dato width");

                using (Graphics gr = Graphics.FromImage(image))
                {
                    gr.FillRectangle(Brushes.LightGreen, x, y, width, height);
                }

                Console.WriteLine("Vuoi disegnare un altro rettangolo? y/N");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.N)
                    exit = true;
            }
        }

        private static int GetUserInput(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int num))
                {
                    return num;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input non valido. Inserire un numero");
                Console.ResetColor();
            }
        }
    }
}
