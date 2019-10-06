namespace FightingFantasy.ConsoleInterface.Hid
{
    public class ConsoleUi
    {
        private readonly IOutput _output;

        public ConsoleUi(IOutput output)
        {
            _output = output;
        }

        public void Run()
        {
            _output.Write("Welcome to Stevö John's Fighting Fantasy Game Engine!\n\n");
            _output.Write("Type help at any time for commands.\n\n");
        }
    }
}