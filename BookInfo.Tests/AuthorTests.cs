
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
            FakeAuhtorRepository far = new FakeAuhtorRepository();
            FakeBookRepository fbr = new FakeBookRepository();
            AuthorController controller = new AuthorController(far, fbr);

            // Act
            List<Author> authors = controller.Index().ViewData.Model as List<Author>;

            // Assert
            if (authors != null)
            {
                Assert.Equal(far.GetAllAuthors()[0].Name,
                    authors[0].Name);
                Assert.Equal(far.GetAllAuthors()[0].Birthday,
                    authors[0].Birthday);
                Assert.Equal(far.GetAllAuthors()[1].Name,
                    authors[1].Name);
                Assert.Equal(far.GetAllAuthors()[1].Birthday,
                    authors[1].Birthday);
            }
        }
    }

}
