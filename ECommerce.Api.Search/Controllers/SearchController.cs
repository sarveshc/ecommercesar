﻿using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController :ControllerBase 
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }
        [HttpPost]
      public async Task<IActionResult>SearchAsync(SearchTerm searchTerm)
        {
            var result = await searchService.SearchAsync(searchTerm.CustomerId);
            if(result.isSuccess)
            {
                return Ok(result.searchResult);
            }
            return NotFound();
        }
    }   
}
