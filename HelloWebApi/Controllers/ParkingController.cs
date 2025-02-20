using HelloWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private static List<Gate> _gates = new List<Gate>
        {
            new Gate { Id = 1, Name = "Gate A", Created_At = DateTime.UtcNow, Updated_At = DateTime.UtcNow },
            new Gate { Id = 2, Name = "Gate B", Created_At = DateTime.UtcNow, Updated_At = DateTime.UtcNow }
        };
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Gate>> Get()
        {
            return Ok(_gates);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Gate> Get(int id)
        {
            var gate = _gates.FirstOrDefault(i => i.Id == id);
            if (gate == null)
            {
                return NotFound();
            }
            return Ok(gate);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Gate> Create(Gate gate)
        {
            if (gate == null || string.IsNullOrWhiteSpace(gate.Name))
            {
                return BadRequest("Invalid Input"); 
            }
            gate.Created_At = DateTime.UtcNow;
            gate.Updated_At = DateTime.UtcNow;
            _gates.Add(gate);
            return Ok(gate);
        }
            
        [HttpPut]
        [Route("")]
        public ActionResult<Gate> Update(int id, Gate gate)
        {
            if (gate == null || string.IsNullOrWhiteSpace(gate.Name))
            {   
                return BadRequest("Invalid Input");
            }    
            var existingGate = _gates.FirstOrDefault(i => i.Id == id);
            if (existingGate == null)
            {
                return NotFound($"Gate with id {gate.Id} not found");
            }
            existingGate.Id = gate.Id;
            existingGate.Name = gate.Name;
            existingGate.Updated_At = DateTime.UtcNow;
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Gate> Delete(int id)
        {
            var gate = _gates.FirstOrDefault(i => i.Id == id);

            if (gate == null)
            {
                return NotFound($"Gate with id {id} not found");
            }

            _gates.Remove(gate);
            return NoContent();
        }

    }
}
