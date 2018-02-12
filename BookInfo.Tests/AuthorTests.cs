
using BookInfo.Controllers;
using BookInfo.Models;
using System.Collections.Generic;
using Xunit;

namespace BookInfo.Tests
{
    public class AuthorTests
    {
        public AuthorTests()
        {
        }

        [Fact]
        // Test AuthorController getting a list of authors
        public void DoesGetAuthors()
        {
            // Arrange
            FakeAuhtorRepository repository = new FakeAuhtorRepository();
            AuthorController controller = new AuthorController(repository);

            // Act
            List<Author> authors = controller.Index().ViewData.Model as List<Author>;

            // Assert
            if (authors != null)
            {
                Assert.Equal(repository.GetAllAuthors()[0].Name,
                    authors[0].Name);
                Assert.Equal(repository.GetAllAuthors()[0].Birthday,
                    authors[0].Birthday);
                Assert.Equal(repository.GetAllAuthors()[1].Name,
                    authors[1].Name);
                Assert.Equal(repository.GetAllAuthors()[1].Birthday,
                    authors[1].Birthday);
            }
        }
    }

}
