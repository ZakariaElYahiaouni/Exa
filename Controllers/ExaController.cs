using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DTOs;
using backend.models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExaController : ControllerBase
    {
        private readonly IServiceResponse _userResponse;

        public ExaController(IServiceResponse userResponse)
        {
            _userResponse = userResponse;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userResponse.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante il recupero degli utenti: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddComment newComment)
        {
            try
            {
                var response = await _userResponse.AddUserComment(newComment);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore durante l'aggiunta del commento dell'utente: {ex.Message}");
            }
        }
    }
}
