namespace JKCore.Repositories.EF.Test
{
    using JKCore.Repositories.EF.Test.Helpers;
    using System.Threading.Tasks;
    using Xunit;
    using JKCore.Repositories.EF.Test.Data;
    using FluentAssertions;

    public class repository_tests : DbContextTestFixture
    {

        [Fact]
        public async Task insert_should_success()
        {
         
            using (var dbContext = CreateDbContext())
            {
                // Arrange
                var repo = new TestModelRepository(dbContext);
                var model = new TestModel
                {
                    Age = 1
                };

                // actions
                await repo.InsertAsync(model);

                dbContext.SaveChanges();

                var model2 = dbContext.TestModels.Find(model.Id);

                // Assertions
                model.Id.Should().NotBeNullOrEmpty();

                model2.Should().NotBeNull();
                model2.Age.Should().Be(model.Age);
            }
        }

        [Fact]
        public async Task update_should_success()
        {
            // Arrange
            using (var dbContext = CreateDbContext())
            {
                // Arrange
                var repo = new TestModelRepository(dbContext);
                var expectedAge = 2;

                var model = new TestModel
                {
                    Age = 1
                };

                await repo.InsertAsync(model);

                // Actions.
              
                model.Age = expectedAge;

                await repo.UpdateAsync(model);

                dbContext.SaveChanges();

                var model2 = dbContext.TestModels.Find(model.Id);

                // Assertions
                model.Id.Should().NotBeNullOrEmpty();

                model2.Should().NotBeNull();
                model2.Age.Should().Be(expectedAge);
            }
        }
    }
}
