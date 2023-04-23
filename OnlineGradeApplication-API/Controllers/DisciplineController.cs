﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineController(IDisciplineRepository discipline)
        {
            _disciplineRepository = discipline;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.DisciplineDTO>> GetDisciplinesAsync()
        {
            return _disciplineRepository.GetDisciplinesAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.DisciplineDTO> GetDisciplineAsync(int id)
        {
            var discipline = _disciplineRepository.GetDisciplineAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            return Ok(discipline);

        }
    }
}