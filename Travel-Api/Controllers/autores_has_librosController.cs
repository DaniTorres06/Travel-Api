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
    public class autores_has_librosController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IAutoresHasLibrosRepository _AutoresHasLibrosRepository;

        public autores_has_librosController(IMapper mapper, IAutoresHasLibrosRepository autoresHasLibrosRepository)
        {
            _AutoresHasLibrosRepository = autoresHasLibrosRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los autores con libros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAutores_has_libros()
        {            
            try
            {
                var listAutoresHasLibro = await _AutoresHasLibrosRepository.GetListAutoresHasLibros();
                var listAutoresHasLibroDto = _mapper.Map<IEnumerable<Autores_has_librosDTO>>(listAutoresHasLibro);
                return Ok(listAutoresHasLibroDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/autores_has_libros/5
        /// <summary>
        /// Obtiene autores_has_libros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Autores_has_libros>> Getautores_has_librosXId(int id)
        {
            try
            {
                var autores_has_libros = await _AutoresHasLibrosRepository.GetAutoresHasLibrosXId(id);

                if (autores_has_libros == null)
                {
                    return NotFound();
                }

                var autoresHasLibroDTO = _mapper.Map<Autores_has_librosDTO>(autores_has_libros);

                return Ok(autoresHasLibroDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/autores_has_libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Agregar registro de autor con libro
        /// </summary>
        /// <param name="autores_has_libros"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Autores_has_libros>> Postautores_has_libros(Autores_has_librosDTO autores_has_librosDto)
        {
            try
            {
                var autorHasLibro = _mapper.Map<Autores_has_libros>(autores_has_librosDto);

                autorHasLibro = await _AutoresHasLibrosRepository.AddAutoresHasLibros(autorHasLibro);

                var autorHasLibroItemDto = _mapper.Map<Autores_has_librosDTO>(autorHasLibro);
                return CreatedAtAction("Getautores_has_libros", new { id = autorHasLibroItemDto.Id }, autorHasLibroItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/autores_has_libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Editar autor con libro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="autores_has_libros"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Putautores_has_libros(int id, Autores_has_librosDTO autores_has_librosDto)
        {
            try
            {
                var autoresHasLibro = _mapper.Map<Autores_has_libros>(autores_has_librosDto);
                if (id != autoresHasLibro.Id)
                {
                    return BadRequest();
                }

                var autoresHasLibroItem = await _AutoresHasLibrosRepository.GetAutoresHasLibrosXId(id);
                if (autoresHasLibroItem == null)
                {
                    return NotFound();
                }
                autoresHasLibroItem.autores_id = autores_has_librosDto.Autores_id;
                autoresHasLibroItem.libros_ISBN= autores_has_librosDto.Libros_ISBN;

                await _AutoresHasLibrosRepository.AddAutoresHasLibros(autoresHasLibroItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        // DELETE: api/autores_has_libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteautores_has_libros(int id)
        {
            try
            {
                var autoresLibros = await _AutoresHasLibrosRepository.GetAutoresHasLibrosXId(id);

                if (autoresLibros == null)
                {
                    return NotFound();
                }

                await _AutoresHasLibrosRepository.DeleteAutoresHasLibros(autoresLibros);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
