using gaming1.crossCutting;
using gaming1.executor;
using Moq;

namespace gaming1.test.Executor
{
    [TestClass]
    public class SinglePlayerGameExecutorTest
    {
        private Mock<IMistery> _misteryMock;
        private SinglePlayerGameExecutor _singlePlayerGameExecutor_;

        public SinglePlayerGameExecutorTest()
        {
            _misteryMock = new Mock<IMistery>();

            _singlePlayerGameExecutor_ = new SinglePlayerGameExecutor(_misteryMock.Object);
        }

        [TestMethod]
        public void ShouldReturnBigger()
        {
            _misteryMock.Setup(x => x.MisteryNumber()).Returns(13);

            string result = _singlePlayerGameExecutor_.ValidateResult(30);

            Assert.IsNotNull(">");
        }

        [TestMethod]
        public void ShouldReturnLower()
        {
            _misteryMock.Setup(x => x.MisteryNumber()).Returns(13);

            string result = _singlePlayerGameExecutor_.ValidateResult(2);

            Assert.IsNotNull("<");
        }

        [TestMethod]
        public void ShouldReturnEquals()
        {
            _misteryMock.Setup(x => x.MisteryNumber()).Returns(13);

            string result = _singlePlayerGameExecutor_.ValidateResult(2);

            Assert.IsNotNull("=");
        }
    }
}
