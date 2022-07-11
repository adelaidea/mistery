using gaming1.crossCutting;
using gaming1.iexecutor;

namespace gaming1.executor
{
    public class SinglePlayerGameExecutor : ISinglePlayerGameExecutor
    {
        private readonly IMistery _mistery;

        public SinglePlayerGameExecutor(IMistery mistery)
        {
            _mistery = mistery;
        }

        /// <summary>
        /// This method validate if the mistery number is bigger, lower of equal than a given number.
        /// </summary>
        /// <param name="value">Number do validate</param>
        /// <returns>
        /// retunrs > when is bigger
        /// returns < when is lower
        /// returns = when is equals
        /// </returns>
        public string ValidateResult(int value)
        {
            int misteryNumber = _mistery.MisteryNumber();

            if (value == misteryNumber)
                return "=";
            else if (misteryNumber > value)
                return ">";
            else
                return "<";
        }
    }
}
