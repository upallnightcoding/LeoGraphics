using LeoLib.scipt.command;
using LeoLib.script;

namespace LeoLib.scipt
{
    public class Script
    {
        public Script(Parser parser)
        {
            while(parser.IsNotEof())
            {
                ProgNode node = GetCommand(parser);

                node.Evaluate();
            }
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public ProgNode GetCommand(Parser parser)
        {
            Token keyword = parser.GetToken();

            ProgCmd command = new ProgCmdPrint();

            return (command.Construct(parser));
        }

        private void Populate()
        {
            ProgCmd command = new ProgCmdEnd();
        }
    }
}
