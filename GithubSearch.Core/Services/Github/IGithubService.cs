using GithubSearch.Core.Abstraction;
using GithubSearch.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubSearch.Core.Services.Github
{
    public interface IGithubService : ISearchService<SearchResult, RepositorySearchSpecification>
    {
    }
}
