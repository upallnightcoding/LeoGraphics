using LeoLib.scipt.execute;
using LeoLib.script;

namespace LeoLib.scipt.command
{
    class ProgCmdWhile : ProgCmd
    {
        public ProgCmdWhile() 
            : base("WHILE")
        {

        }

        public override ProgNode Interpret(Script script)
        {
            ProgNode expression = script.Expression();

            ProgNode codeBlock = script.ReadCodeBlock();

            return (new ProgNodeWhile(expression, codeBlock));
        }
    }
}
