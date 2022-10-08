using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Api.Context;
using Travel_Api.Models;
using Travel_Api.Models.DTO;
using Travel_Api.Models.Repository;

namespace Travel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class editorialesController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IEditorialesRepository _EditorialReposotory;

        public editorialesController(IMapper mapper, IEditorialesRepository editorialesRepository)
        {
            _mapper = mapper;
            _EditorialReposotory = editorialesRepository;
        }

        // GET: api/editoriales
        /// <summary>
        /// Obtiene todos los editoriales
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEditoriales()
        {            
            try
            {
                var listEditoriales = await _EditorialReposotory.GetListEditoriales();
                var listEditorialesDto = _mapper.Map<IEnumerable<EditorialesDTO>>(listEditoriales);
                return Ok(listEditorialesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        // GET: api/editoriales/5
        /// <summary>
        /// Obtiene EditorialxId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GeteditorialesXId(int id)
        {
            try
            {
                var editoriales = await _EditorialReposotory.GetEditorialesXId(id);

                if (editoriales == null)
                {
                    return NotFound();
                }

                var editorialesDto = _mapper.Map<EditorialesDTO>(editoriales);

                return Ok(editorialesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Editar registro editorial
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editorialesDTO"></param>
        /// <returns></returns>
        // PUT: api/editoriales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puteditoriales(int id, EditorialesDTO editorialesDTO)
        {
            try
            {
                var editorales = _mapper.Map<Editoriales>(editorialesDTO);
                if (id != editorialesDTO.Id)
                {
                    return BadRequest();
                }

                var editorialesItem = await _EditorialReposotory.GetEditorialesXId(id);
                if (editorialesItem == null)
                {
                    return NotFound();
                }

                editorialesItem.Nombre = editorialesDTO.Nombre;
                editorialesItem.Sede= editorialesDTO.Sede;

                await _EditorialReposotory.UpdateEditoriales(editorialesItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/editoriales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Posteditoriales(EditorialesDTO editorialesDto)
        {            
            try
            {
                var editoriales = _mapper.Map<Editoriales>(editorialesDto);

                editoriales = await _EditorialReposotory.AddEditoriales(editoriales);

                var editorialesItemDto = _mapper.Map<EditorialesDTO>(editoriales);
                return CreatedAtAction("Geteditoriales", new { id = editorialesItemDto.Id }, editorialesItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/editoriales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteeditoriales(int id)
        {
            try
            {
                var editoriales = await _EditorialReposotory.GetEditorialesXId(id);

                if (editoriales == null)
                {
                    return NotFound();
                }

                await _EditorialReposotory.DeleteEditoriales(editoriales);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }
}
