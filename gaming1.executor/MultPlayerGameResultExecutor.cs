using gaming1.crossCutting;
using gaming1.crossCutting.DTO;
using gaming1.iexecutor;

namespace gaming1.executor
{
    public class MultPlayerGameResultExecutor : IMultPlayerGameResultExecutor
    {
        private readonly IMistery _mistery;

        public MultPlayerGameResultExecutor(IMistery mistery)
        {
            _mistery = mistery;
        }

        /// <summary>
        /// This method will check if any user set the correct nubmer
        /// </summary>
        /// <param name="answers">Users answers list</param>
        /// <returns>
        /// If a user sets the correct number, returns this user, 
        /// if no user sets the correct number, returns null.
        /// </returns>
        public UserAnswerDto? Winner(IList<UserAnswerDto> answers)
        {
            int misteryNumber = _mistery.MisteryNumber();

            return answers.FirstOrDefault(x => x.Result == misteryNumber);
        }
    }
}
