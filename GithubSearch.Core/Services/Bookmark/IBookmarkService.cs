using GithubSearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubSearch.Core.Services.Bookmark
{
    public interface IBookmarkService
    {
        Task SaveAsync(BookmarkContext item);

        Task<RepositoryItem[]> FetchAsync(string userId);
    }

    public class BookmarkContext
    {
        public string UserId { get; set; }

        public RepositoryItem Item { get; set; }
    }
}
