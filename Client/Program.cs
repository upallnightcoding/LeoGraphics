using LeoLib;
using LeoLib.scipt;
using System;

namespace Leo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestGame01();

            TestParser01();
        }

        static void TestGame01()
        {
            Game game = new Game("Leo Client ..."); 
        }

        static void TestParser01()
        {
            //string source = "   print 11+((33) *6)/2, \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";
            //string source = "   print \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";
            //string source = "  print 120 - 4 * 5; print 45 * 4 / 3";
            string[] source = new string[] {
                "print 2 +3, \" \", 7 - 2, \" \", 78.3/34, \" \", 3*8; ",
                "print 45 * 4 / 3; ",
                "print 45 * 34; ",
                "print ((23 + 3) * 9);" 
            };

            Parser parser = new Parser(source);
             
            Script script = new Script(parser);
        }
    }
}
