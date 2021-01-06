using Client;
using LeoLib;
using LeoLib.game;
using LeoLib.game.d2;
using LeoLib.scipt;
using System;

namespace Leo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestGame01();

            TestGame2d_01();

            //TestParser01();
        }

        static void TestGame01()
        {
            Game3D game = new Game3D("Leo Client ..."); 
        }

        static void TestGame2d_01()
        {
            Scene2D scene = TestCase.SpinOffTest();
            //Scene2D scene = TestCase.SpinStateTest();
            //Scene2D scene = TestCase.SpinStateKeyBoardTest();
            //Scene2D scene = TestCase.StillTest();
            //Scene2D scene = TestCase.FlipBookTest();

            Game2D game = new Game2D("Leo Client ...", scene);
        }


        static void TestParser01()
        {
            //string source = "   print 11+((33) *6)/2, \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";
            //string source = "   print \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";
            //string source = "  print 120 - 4 * 5; print 45 * 4 / 3";

            /*string[] source = new string[] {
                "program;",
                "  integer a = 1, b = 2, c = 45+2;",
                "  a = 11;",
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
            };*/

            /*string[] source = new string[] {
                "program;",
                "  integer a = 1, b = 2, c = 45+2;",
                "  a = 11;",
                "  print 11 ^ 2, 6 % 4;",
                "  print a, \" \",b +1,\" \",c*3, \" \",a;",
                "end;"
            };*/

            string[] source = new string[] {
                "program;",
                "  print 1 > 3, \" \", 1 < 3;",
                "  print 1.0 > 3, \" \", 1 < 3.5;",
                "  integer a = 1, b = 2, c = 45+2;",
                "  print a*5 > 3, \" \", 1*10 < 3;",
                "  float x = 1.5, y = 2.5, z = 45+2;",
                "  print a, ' ', b, ' ', c;",
                "  print a, ' ', b, ' ', c;",
                "  print x, ' ', y, ' ', z;",
                "  print (a + b) * c, ' ', c % 2;",
                "  print 11 + 2, \" \", 3 % 2;",
                "  print 11 - 2, \" \", 3 - 12;",
                "  print 11 * 2, \" \", 3 * 12;",
                "  print 11.0 / 2, \" \", 3 / 12.5;",
                "  print 11 % 2, \" \", 3 % 12;",
                "  print 11 ^ 2, \" \", 3 ^ 2;",
                "end;"
            };

            Parser parser = new Parser(source);
             
            Script script = new Script(parser);
        }
    }
}
