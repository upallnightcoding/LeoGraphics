using LeoLib;
using LeoLib.game;
using LeoLib.scipt;
using System;

namespace Leo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestGame01();

            //TestGame2d_01();

            TestParser01();
        }

        static void TestGame01()
        {
            Game3D game = new Game3D("Leo Client ..."); 
        }

        static void TestGame2d_01()
        {
            Game2D game = new Game2D("Leo Client ...");
        }


        static void TestParser01()
        {
            //string source = "   print 11+((33) *6)/2, \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";
            //string source = "   print \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";
            //string source = "  print 120 - 4 * 5; print 45 * 4 / 3";

            string[] source = new string[] {
                "program;",
                "  integer a = 1, b = 2, c = 45+2;",
                "  print a, b +1,c*3, a;",
                "  print 2 +3, \" \", 34.23 + 17.9, \" \", 7 - 2, \" \", 78.3/34, \" \", 3*8; ",
                "  print 45.0 - 4.8; ",
                "  print 20.0 - 14.8; ",
                "  print 45 + 4; ",
                "  print \"45*34=1530: \", 45 * 34; ",
                "  print \"((23+3)*9)=234:  \", ((23 + 3) * 9); ",
                "  print \"((23*2)*9)*(34)=14076:  \", ((23 * 2) * 9) * (34); ",
                "  print \"123.5/765.9=0.16124:  \", 123.5/765.9; ",
                "  program;",
                "    print \"Inner Program\";",
                "  end;",
                "  print ((23 * 2) * 9) * (34);",
                "end;"
            };

            Parser parser = new Parser(source);
             
            Script script = new Script(parser);
        }
    }
}
