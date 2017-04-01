namespace JKCore.Repositories.EF.Test
{
    using JKCore.Repositories.EF.Test.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using JKCore.Repositories.EF.Test.Data;
    using FluentAssertions;

    public class repository_tests : DbContextTestFixture
    {

        [Fact]
        public void insert_should_success()
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
                repo.Insert(model);

                dbContext.SaveChanges();

                var model2 = dbContext.TestModels.Find(model.Id);

                // Assertions
                model.Id.Should().NotBeNullOrEmpty();

                model2.Should().NotBeNull();
                model2.Age.Should().Be(model.Age);
            }
        }

        [Fact]
        public void update_should_success()
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

                repo.Insert(model);

                // Actions.
              
                model.Age = expectedAge;

                repo.Update(model);

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
