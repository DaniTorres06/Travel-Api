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
    public class librosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILibrosRepository _LibrosRepository;

        public librosController(IMapper mapper, ILibrosRepository librosRepository)
        {            
            _mapper = mapper;
            _LibrosRepository = librosRepository;
        }

        // GET: api/libros
        /// <summary>
        /// Obtiene registro de todos los libros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLibros()
        {
            //return await _context.Libros.ToListAsync();
            try
            {
                var listLibros = await _LibrosRepository.GetListLibros();
                var listLibrosDto = _mapper.Map<IEnumerable<LibrosDTO>>(listLibros);
                return Ok(listLibrosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/libros/5
        /// <summary>
        /// Obtiene todos los libros por codigo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Libros>> GetlibrosXId(int id)
        {
            try
            {
                var libros = await _LibrosRepository.GetLibrosXId(id);

                if (libros == null)
                {
                    return NotFound();
                }

                var LibrosDTO = _mapper.Map<LibrosDTO>(libros);

                return Ok(LibrosDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Agregar registro de libro
        /// </summary>
        /// <param name="libros"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Libros>> Postlibros(LibrosDTO librosDto)
        {            
            try
            {
                var libros = _mapper.Map<Libros>(librosDto);

                libros = await _LibrosRepository.AddLibros(libros);

                var masctoItemDto = _mapper.Map<LibrosDTO>(libros);
                return CreatedAtAction("Getlibros", new { id = masctoItemDto.Id }, masctoItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Editar libro registrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libros"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlibros(int id, LibrosDTO librosDto)
        {
            try
            {
                var libros = _mapper.Map<Libros>(librosDto);
                if (id != libros.Id)
                {
                    return BadRequest();
                }

                var librosItem = await _LibrosRepository.GetLibrosXId(id);
                if (librosItem == null)
                {
                    return NotFound();
                }
                librosItem.ISBN = librosDto.ISBN;
                librosItem.Editoriales_id = librosDto.Editoriales_id;
                librosItem.Titulo = librosDto.Titulo;
                librosItem.N_paginas = librosDto.N_paginas;

                await _LibrosRepository.AddLibros(librosItem);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/libros/5
        /// <summary>
        /// Eliminar registro de libro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelibros(int id)
        {
            try
            {
                var libros = await _LibrosRepository.GetLibrosXId(id);

                if (libros == null)
                {
                    return NotFound();
                }

                await _LibrosRepository.DeleteLibros(libros);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
