namespace FightingFantasy.ConsoleInterface.Hid
{
    public class ConsoleUi
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public ConsoleUi(IOutput output, IInput input)
        {
            _output = output;
            _input = input;
        }

        public void Run()
        {
            _output.Clear();

            _output.Write("\nWelcome to Stevö John's <b>Fighting Fantasy</b> Game Engine!\n\n");
            _output.Write("Type <b>help</b> at any time for commands.\n\n");
        }
    }
}