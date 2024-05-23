using GithubSearch.Core.Domain;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubSearch.Core.Services.Github
{
    public interface IGitHubApi
    {
        [Get("/search/repositories?q={text}")]
        [Headers("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36")]
        Task<SearchResult> SearchAsync(string text);
    }
}
