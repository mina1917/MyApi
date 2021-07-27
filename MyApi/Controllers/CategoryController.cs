using Common.Exceptions;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFramework.Filters;
using Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiResultFilter]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ICategoryTagRepository categoryTagRepository;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryRepository categoryRepository, ICategoryTagRepository categoryTagRepository, ILogger<CategoryController> logger)
        {
            this.categoryRepository = categoryRepository;
            this.categoryTagRepository = categoryTagRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            var catTags = categoryTagRepository.TableNoTracking;

            //TODO : AutoMapper
            var result = await catTags.Include(x => x.Category).Include(x => x.Tag).Include(x => x.Parent)
                .Select(x => new CategoryDto
                {
                    CatName = x.Category.Name,
                    TagName = x.Tag.Name,
                    ParentName = x.Parent != null ? x.Parent.Category.Name : ""
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("GetSubCategoryByCatID/{id}")]
        public async Task<ActionResult<List<CategoryDto>>> GetSubCategoryByCatID(int id)
        {
            var catTags = categoryTagRepository.TableNoTracking;

            //TODO : AutoMapper
            var result = await catTags.Include(x => x.Category).Include(x => x.Tag).Include(x => x.Parent).Where(x => x.Parent.CategoryID == id)
                .Select(x => new CategoryDto
                {
                    CatName = x.Category.Name,
                    ParentName = x.Parent != null ? x.Parent.Category.Name : ""
                })
                .ToListAsync();

            return Ok(result);
        }
    }
}
