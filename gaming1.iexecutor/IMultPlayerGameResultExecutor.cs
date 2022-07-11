using gaming1.crossCutting.DTO;

namespace gaming1.iexecutor
{
    public interface IMultPlayerGameResultExecutor
    {
        UserAnswerDto? Winner(IList<UserAnswerDto> answers);
    }
}
