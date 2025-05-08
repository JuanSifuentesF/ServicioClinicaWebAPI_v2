using Microsoft.AspNetCore.Mvc;
using ClinicaWebAPI_v2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaWebAPI_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaV2Controller : ControllerBase
    {

        private readonly Bdclinica2022Context db;

        public ClinicaV2Controller(Bdclinica2022Context _db)
        {
            db = _db;
        }

        // GET: api/<ClinicaV2Controller>
        [HttpGet("ListarMedicos")]
        public async Task<ActionResult<List<Medico>>> ListarMedicos()
        {
            var listado = await db.Medicos.ToListAsync();
            return listado ;
        }

        // GET api/<ClinicaV2Controller>/5
        [HttpGet("GetMedico/{id}")]
        public async Task<ActionResult<string>> GetMedico(string id)
        {
            var buscado = await db.Medicos.FindAsync(id);
            if (buscado == null)
            {
                return BadRequest($"No se encontro el medico con el id: {id}");
            }
            else
            {
                return Ok(buscado);
            }
        }

        // POST api/<ClinicaV2Controller>
        [HttpPost("GrabarMedicosPost")]
        public async Task<ActionResult<string>> GrabarMedicosPost([FromBody] Medico obj)
        {
            try
            {
                await db.Medicos.AddAsync(obj); // Se guarda el objeto medico en memoria
                await db.SaveChangesAsync(); // se guarda en la BD de forma persistente
                return $"El medico: {obj.Nommed} fue registrado correctamente";
            }
            catch(Exception ex)
            {
                return "Error: " + ex.InnerException!.Message;
            }
        }

        // PUT api/<ClinicaV2Controller>/5
        [HttpPut("ActualizarMedicoPut")]
        public async Task<ActionResult<string>> ActualizarMedicoPut([FromBody] Medico obj)
        {
            try
            {
                await Task.Run( ()=> db.Medicos.Update(obj)) ; // Se actualiza el objeto medico en memoria
                await db.SaveChangesAsync(); // se guarda en la BD de forma persistente
                return $"El medico: {obj.Nommed} fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.InnerException!.Message;
            }
        }

        // DELETE api/<ClinicaV2Controller>/5
        [HttpDelete("DeleteMedico/{id}")]
        public async Task<ActionResult<string>> DeleteMedico(String id)
        {
            try
            {
                var buscado = await db.Medicos.FindAsync(id);
                //Eliminacion logica
                buscado.Estado = 0;
                //await db.Medicos.ExecuteDeleteAsync(); Eliminacion fisica
                return $"El medico: {buscado!.Nommed} fue eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.InnerException!.Message;
            }
        }


        [HttpGet("GetPA_CITAS_ANIO/{anio}")]
        public async Task<ActionResult<List<PA_CITAS_ANIO>>> GetPA_CITAS_ANIO(int anio)
        {
            var listado = await db.PA_CITAS_ANIO
                .FromSqlRaw("EXEC PA_CITAS_ANIO {0}", anio)
                .ToListAsync();

            return Ok(listado);
        }
    }
}
