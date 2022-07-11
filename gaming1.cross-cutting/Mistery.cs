namespace gaming1.crossCutting
{
    public class Mistery : IMistery
    {
        private static int misteryNumber = new Random().Next(0, 100);

        public int MisteryNumber()
        {
            return misteryNumber;
        }
    }
}