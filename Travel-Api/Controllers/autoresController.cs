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
    public class autoresController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IAutoresRepository _AutoresRepository;

        public autoresController(IMapper mapper, IAutoresRepository autoresRepository)
        {            
            _mapper = mapper;
            _AutoresRepository = autoresRepository;
        }        

        /// <summary>
        /// Obtiene listado de autores
        /// </summary>
        /// <returns></returns>
        // GET: api/autores
        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {            
            try
            {
                var listAutores = await _AutoresRepository.GetListAutores();
                var listAutoresDto = _mapper.Map<IEnumerable<AutoresDTO>>(listAutores);
                return Ok(listAutoresDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// Obtener Autor x codigo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]        
        public async Task<IActionResult> GetautoresXId(int id)
        {
            try
            {
                var autores = await _AutoresRepository.GetAutoresXId(id);

                if (autores == null)
                {
                    return NotFound();
                }

                var autoresDTO = _mapper.Map<AutoresDTO>(autores);

                return Ok(autoresDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
        /// <summary>
        /// Agregar Autor
        /// </summary>
        /// <param name="autores"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Postautores(AutoresDTO autoresDTO)
        {            
            try
            {
                var autores = _mapper.Map<Autores>(autoresDTO);

                autores = await _AutoresRepository.AddAutores(autores);

                var autoresItemDto = _mapper.Map<AutoresDTO>(autores);
                return CreatedAtAction("Getautores", new { id = autoresItemDto.Id }, autoresItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        /// <summary>
        /// Editar libro por codigo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="autores"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Putautores(int id, AutoresDTO autoresDTO)
        {
            try
            {
                var autores = _mapper.Map<Autores>(autoresDTO);
                if (id != autores.Id)
                {
                    return BadRequest();
                }

                var autoresItem = await _AutoresRepository.GetAutoresXId(id);
                if (autoresItem == null)
                {
                    return NotFound();
                }
                autoresItem.nombre = autoresDTO.Nombre;
                autoresItem.apellidos = autoresDTO.Apellidos;

                await _AutoresRepository.UpdateAutores(autoresItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// Eliminar registro de autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteautores(int id)
        {
            try
            {
                var autores = await _AutoresRepository.GetAutoresXId(id);

                if (autores == null)
                {
                    return NotFound();
                }

                await _AutoresRepository.DeleteAutores(autores);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        private bool autoresExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
        */
    }
}
