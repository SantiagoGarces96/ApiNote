using Core.Entities;
using Infraestructure.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ApiNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;


        public NoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNote()
        {
            var notes = await _unitOfWork.Note.GetAllAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNoteById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Note Id");
            }

            var note = await _unitOfWork.Note.GetFirstAsync(n => n.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> AddNote([FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Note.AddAsync(note);
            await _unitOfWork.Save();

            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNote(int id, [FromBody] Note note)
        {
            if (note == null || note.Id != id)
            {
                return BadRequest();
            }

            var noteExists = await _unitOfWork.Note.GetFirstAsync(n => n.Id == id);
            if (noteExists == null)
            {
                return NotFound();
            }

            _unitOfWork.Note.Update(note);
            await _unitOfWork.Save();

            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNoteById(int id)
        {
            var note = await _unitOfWork.Note.GetFirstAsync(n => n.Id == id);

            if (note == null)
            {
                return NotFound();
            }

            _unitOfWork.Note.RemoveAsync(note);
            await _unitOfWork.Save();

            return Ok();
        }
    }

}
