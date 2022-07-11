namespace gaming1.cross-cutting
{
    public class GameResultExecutorRequestDto
    {
        public GameResultExecutorRequestDto(IList<int> values)
        {
            Values = values;
        }

        public IList<int> Values { get; set; }
    }
}