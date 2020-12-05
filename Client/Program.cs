using LeoLib;
using LeoLib.scipt;
using System;

namespace Leo
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Leo Client ..."); 

            string source = "   print 11+((33) *6)/2, \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";
            //string source = "   print \" \" , 2, \" \", 3, \" Test Text \", 123.345, \" \", 0.098;";

            //Parser parser = new Parser(source);

            //Script script = new Script(parser);
        }
    }
}
