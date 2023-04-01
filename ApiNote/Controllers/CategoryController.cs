using Core.Entities;
using Infraestructure.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApiNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;


        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            var list = await _unitOfWork.Category.GetAllAsync();
            return Ok(list);
        }

        [HttpPost]

        public async Task<ActionResult<Category>> AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.Save();

            return Ok(category);
        }

        [HttpGet("{id}", Name = "GetCategory")]

        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var category = await _unitOfWork.Category.GetFirstAsync(l => l.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateCategory(int id, [FromBody] Category category)
        {

            if (id != category.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryExist = await _unitOfWork.Category.GetFirstAsync(
               c => c.Id == category.Id
                );
            if (categoryExist == null)
            {
                return BadRequest();
            }

            _unitOfWork.Category.UpdateCategory(category);
            await _unitOfWork.Save();

            return Ok(category);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> deleteCategory(int id)
        {
            var category = await _unitOfWork.Category.GetFirstAsync(u => u.Id == id);

            if(category == null)
            {
                return NotFound();
            }
            
            _unitOfWork.Category.RemoveAsync(category);
            await _unitOfWork.Save();

            return Ok();

        }



    }
}
