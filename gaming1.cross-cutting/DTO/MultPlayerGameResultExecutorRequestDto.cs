namespace gaming1.crossCutting.DTO
{
    public class UserAnswerDto
    {
        public UserAnswerDto(string name, int result)
        {
            Name = name;
            Result = result;
        }

        public string Name { get; set; }
        public int Result { get; set; }
    }
}
