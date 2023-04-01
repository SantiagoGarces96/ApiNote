using Core.Entities;
using Infraestructure.Repository;
using Infraestructure.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;


namespace ApiNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicLevelController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public AcademicLevelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AcademicLevel>>> GetALEVEL()
        {
            var list = await _unitOfWork.AcademicLevel.GetAllAsync();
            return Ok(list);
        }

        [HttpPost]

        public async Task<ActionResult<AcademicLevel>> AddAcademic([FromBody] AcademicLevel academicLevel)
        {
            if (academicLevel== null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.AcademicLevel.AddAsync(academicLevel);
            await _unitOfWork.Save();

            return Ok(academicLevel);
        }

        [HttpGet("{id}", Name = "GetAcademicLevel")]

        public async Task<ActionResult<AcademicLevel>> GetAcademic(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var academic = await _unitOfWork.AcademicLevel.GetFirstAsync(l => l.Id == id);

            if (academic == null)
            {
                return NotFound();
            }
            return Ok(academic);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateAcademic(int id, [FromBody] AcademicLevel academicLevel)
        {

            if (id != academicLevel.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var AcademicExist = await _unitOfWork.AcademicLevel.GetFirstAsync(
               c => c.Id == academicLevel.Id
                );
            if (AcademicExist == null)
            {
                return BadRequest();
            }

            _unitOfWork.AcademicLevel.UpdateAcademicLevel(academicLevel);    
            await _unitOfWork.Save();

            return Ok(academicLevel);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> deleteAcademicLevel(int id)
        {
            var academicLevel = await _unitOfWork.AcademicLevel.GetFirstAsync(u => u.Id == id);

            if (academicLevel == null)
            {
                return NotFound();
            }

            _unitOfWork.AcademicLevel.RemoveAsync(academicLevel);
            await _unitOfWork.Save();

            return Ok();

        }




    }
}
