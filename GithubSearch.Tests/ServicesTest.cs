using GithubSearch.Core.Domain;
using GithubSearch.Core.Services.Bookmark;
using GithubSearch.Core.Services.Github;

namespace GithubSearch.Tests
{
    public class ServicesTest
    {
        [Fact]
        public async Task GithubSearchServiceTest()
        {
            IGithubService service = new GithubService();
            var spec = new RepositorySearchSpecification()
            {
                Text = "Isrcard"
            };
            var result = await service.SearchAsync(spec);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task BookmarkServiceTest()
        {
            IBookmarkService service = new BookmarkService();
            var item = new BookmarkContext()
            {
                UserId = Guid.NewGuid().ToString(),
                Item = new RepositoryItem()
            };

            await service.SaveAsync(item);

            var result = await service.FetchAsync(item.UserId);


            Assert.NotNull(result);

            Assert.True(result.Length == 1);
        }
    }
}