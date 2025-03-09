//using Microsoft.AspNetCore.Mvc;
//using SuperDiploma.Restaurant.DomainService.Contracts;

//namespace SuperDiploma.Restaurant.Api;

//[ApiController]
//[Route("[controller]")]
//public class HelloController : ControllerBase
//{
//    private ICategoryService _categoryService;

//    public HelloController(ICategoryService categoryService)
//    {
//        _categoryService = categoryService;
//    }

//    [HttpGet("Hello")]
//    public async Task<ActionResult> SayHello()
//    {
//        return await Task.FromResult(Ok("Hello"));
//    }

//    [HttpGet("test")]
//    public async Task<ActionResult> Test()
//    {
//        var categories = await _categoryService.GetAllCategoriesAsync();
//        return await Task.FromResult(Ok(categories));
//    }

//}