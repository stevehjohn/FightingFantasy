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
            _output.Write("\n#Gray;Welcome to Stevö John's #Blue;Fighting Fantasy#Gray; Game Engine!\n\n");
            _output.Write("Type #Blue;help#Gray; at any time for commands.\n\n");
        }
    }
}