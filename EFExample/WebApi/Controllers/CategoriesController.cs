﻿using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("api/categories")]
  public class CategoriesController : ControllerBase
  {
    IDataService _dataService;
    public CategoriesController(IDataService dataService)
    {
      _dataService = dataService;
    }

    [HttpGet]
    public IList<Category> GetCategories()
    {
      return _dataService.GetCategories();
    }

    [HttpGet("{categoryId}")]
    public ActionResult<Category> GetCategory(int categoryId)
    {
      var category = _dataService.GetCategory(categoryId);

      if (category == null) return NotFound();

      return Ok(category);
    }

    [HttpPost]
    public ActionResult CreateCategory([FromBody] Category category)
    {
      var cat = _dataService.CreateCategory(category.Name, category.Description);

      return Created("post", cat);
    }

    [HttpPut("{categoryId}")]
    public ActionResult PutCategory([FromBody] Category category, int categoryId)
    {
      var cat = _dataService.PutCategory(categoryId, category.Name, category.Description);
      if (cat == false)
      {
        return NotFound();
      }

      return Ok(cat);
    }

    [HttpDelete("{categoryId}")]
    public ActionResult<Category> DeleteCategory(int categoryId)
    {
      // var category = _dataService.DeleteCategory(categoryId);

      if (_dataService.DeleteCategory(categoryId) == false)
      {
        return NotFound();
      }

      return Ok();
    }
  }
}
