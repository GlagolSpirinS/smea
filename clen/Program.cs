namespace clen
{
    internal class Chlen
    {

        enum consts : int
        {
            w = 30, h = 20
        }

        int[] X = new int[50];
        int[] Y = new int[50];

        int edaX;
        int edaY;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random rnd = new Random();

        Chlen()
        {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible= false;
            edaX = rnd.Next(2, ((int)consts.w - 2));
            edaY = rnd.Next(2, ((int)consts.h - 2));
        }

        public void WriteBoard()
        {
            Console.Clear();

            for (int i = 1; i <= ((int)consts.w + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
            }
            for (int i = 1; i <= ((int)consts.w + 2); i++)
            {
                Console.SetCursorPosition(i, ((int)consts.h + 2));
                Console.Write("#");
            }
            for (int i = 1; i <= ((int)consts.h + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("#");
            }
            for (int i = 1; i <= ((int)consts.h + 1); i++)
            {
                Console.SetCursorPosition(((int)consts.w + 2), i);
                Console.Write("#");
            }
        }

        public void Logic()
        {
            if (X[0]==edaX) 
            {
                if (Y[0]==edaY) 
                {
                    parts++;
                    edaX = rnd.Next(2, (int)consts.w - 2);
                    edaY= rnd.Next(2, (int)consts.h - 2);
                }
            }
            for(int i = parts;i>1;i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch(key)
            {
                case 'w':
                    Y[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
                case 'a':
                    X[0]--; 
                    break;

            }
            for(int i =0;i<=(parts-1);i++)
            {
                WritePoint(X[i], Y[i]);
                WritePoint(edaX,edaY);
            }
            Thread.Sleep(100);
        }

        public void Input()
        {
            if(Console.KeyAvailable) 
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        public void WritePoint(int x, int y)
        {
          ///  try
        //    {
                Console.SetCursorPosition(x, y);
/*            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Вы умерли!");
            }*/
            Console.WriteLine("#");
        }
        static void Main(string[] args)
        {

            Chlen penis = new Chlen();
            while(true) 
            { 
                penis.WriteBoard();
                penis.Input();
                penis.Logic();
            }
            Console.ReadKey();
        }
    }
}