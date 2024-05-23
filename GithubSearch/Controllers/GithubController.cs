using GithubSearch.Core.Domain;
using GithubSearch.Core.Services.Github;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GithubSearch.Controllers
{
    [Route("api/[controller]")]
    public class GithubController : Controller
    {
        private IGithubService githubService;

        public GithubController(IGithubService service)
        {
            this.githubService = service;
        }

        // GET: api/Bookmark
        [HttpGet("search/{text}")]
        public async Task<SearchResult> Get(string text)
        {
            var spec = new RepositorySearchSpecification()
            {
                Text = text
            };

            return await this.githubService.SearchAsync(spec);
        }
    }
}
