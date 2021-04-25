using TSKApp.PL.Models;
using TSKApp.PL.Services;
using TSKTests.Mocks;
using Xunit;

namespace TSKTests.Tests
{
    public class TestServiceTests
    {
        [Fact]
        public void SetTestEditModelIntoDbTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock());
            var testService = new TestService(managerMock);
            var testEditModel = new TestEditModel {Id = 1, TimeStamp = 1, Title = "Fake"};
            var adminName = "admin";
            var expectedTestId = 1;

            var actual = testService.SetTestEditModelIntoDb(testEditModel, adminName);

            Assert.Equal(expectedTestId, actual);

            testEditModel.Id = 0;
            expectedTestId = 0;
            actual = testService.SetTestEditModelIntoDb(testEditModel, adminName);

            Assert.Equal(expectedTestId, actual);
        }
    }
}