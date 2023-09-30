using System;
using Refit;

namespace CatAppSharp.Rest
{
	public interface IApi
	{
        [Get("/v1/images/search?limit=10")]
        Task<List<Cat>> GetCats();
    }
}

