using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubSearch.Core.Abstraction
{
    public interface ISearchService<TResult, in TSpec>
    {
        Task<TResult> SearchAsync(TSpec spec);
    }
}
