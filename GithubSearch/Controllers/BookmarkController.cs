﻿using GithubSearch.Core.Domain;
using GithubSearch.Core.Services.Bookmark;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GithubSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : Controller
    {
        private IBookmarkService bookmarkService;
        private string UserId => this.User.Identity.Name;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            this.bookmarkService = bookmarkService;

        }

        // GET: api/Bookmark
        [HttpGet]
        public async Task<RepositoryItem[]> Get()
        {
            var model = await bookmarkService.FetchAsync(this.UserId);

            return model;
        }

        // POST: api/Bookmark
        [HttpPost("{id}")]
        public async Task Post(int id, [FromBody] RepositoryItem model)
        {
            var item = new BookmarkContext()
            {
                Item = model,
                UserId = UserId
            };

            await this.bookmarkService.SaveAsync(item);
        }
    }
}
