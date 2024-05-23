using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubSearch.Core.Domain
{
    public class SearchResult
    {
        [JsonProperty("total_count")]
        public int Total { get; set; }


        [JsonProperty("items")]
        public RepositoryItem[] Items { get; set; }
    }
}
