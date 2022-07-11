using gaming1.crossCutting;
using gaming1.crossCutting.DTO;
using gaming1.executor;
using Moq;

namespace gaming1.test.Executor
{
    [TestClass]
    public class MultPlayerGameResultExecutorTest
    {
        private Mock<IMistery> _misteryMock;
        private MultPlayerGameResultExecutor _multPlayerGameResultExecutor;

        public MultPlayerGameResultExecutorTest()
        {
            _misteryMock = new Mock<IMistery>();

            _multPlayerGameResultExecutor = new MultPlayerGameResultExecutor(_misteryMock.Object);
        }

        [TestMethod]
        public void ShouldReturnCorrectWinner()
        {
            _misteryMock.Setup(x => x.MisteryNumber()).Returns(13);

            UserAnswerDto? result = _multPlayerGameResultExecutor.Winner(
                new List<UserAnswerDto> {
                    new UserAnswerDto("User-1", 13),
                    new UserAnswerDto("User-2", 54)
                });

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "User-1");
        }

        [TestMethod]
        public void ShouldReturnNullWinner()
        {
            _misteryMock.Setup(x => x.MisteryNumber()).Returns(0);

            UserAnswerDto? result = _multPlayerGameResultExecutor.Winner(
                new List<UserAnswerDto> {
                    new UserAnswerDto("User-1", 13),
                    new UserAnswerDto("User-2", 54)
                });

            Assert.IsNull(result);
        }
    }
}
