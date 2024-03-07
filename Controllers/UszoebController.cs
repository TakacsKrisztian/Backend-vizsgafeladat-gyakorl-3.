using Microsoft.AspNetCore.Mvc;
using Takács_Krisztián_backend3.Models;

namespace Takács_Krisztián_backend3.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UszoebController : ControllerBase
    {
        [HttpGet("GetVersenyzoNev")]
        public ActionResult Get()
        {
            try
            {
                using (var context = new UszoebContext())
                {
                    return Ok(context.Versenyzoks.ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpGet("GetVersenyzokSzama")]
        public ActionResult GetCount()
        {
            try
            {
                using (var context = new UszoebContext())
                {
                    return StatusCode(200, context.Versenyzoks.Count());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpPost("AddVersenyzo")]
        public ActionResult<VersenyzoDto> Post(string UID, CreateVersenyzoDto versenyzo)
        {
            if (UID != "FEB3F4FEA09CE43E")
            {
                return StatusCode(404, "Nincs jogosultsága új versenyző felvételéhez!");
            }

            using (var context = new UszoebContext())
            {
                try
                {
                    var request = new Versenyzok
                    {
                        Nev = versenyzo.Nev,
                        Orszagid = versenyzo.Orszagid,
                        Nem = versenyzo.Nem,
                    };

                    context.Versenyzoks.Add(request);
                    context.SaveChanges();

                    return StatusCode(201, "Versenyző hozzáadása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }
        [HttpPut("UpdateVersenyzo")]
        public ActionResult Put(string UID, int id, ModifyVersenyzoDto modifyVersenyzoDto)
        {
            if (UID != "FEB3F4FEA09CE43E")
            {
                return StatusCode(401, "Nincs jogosultsága új versenyző felvételéhez!");
            }
            using (var context = new UszoebContext())
            {
                try
                {
                    var existingVersenyzo = context.Versenyzoks.FirstOrDefault(x => x.Id == id);

                    existingVersenyzo.Nev = modifyVersenyzoDto.Nev;
                    existingVersenyzo.Orszagid = modifyVersenyzoDto.Orszagid;
                    existingVersenyzo.Nem = modifyVersenyzoDto.Nem;

                    context.Versenyzoks.Update(existingVersenyzo);
                    context.SaveChanges();
                    return StatusCode(200, "Versenyző adatainak a módosítása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }
        [HttpDelete("DeleteVersenyzo")]
        public ActionResult Delete(string UID, int id)
        {
            if (UID != "FEB3F4FEA09CE43E")
            {
                return StatusCode(401, "Nincs jogosultsága a versenyzők adatainak a törléséhez!");
            }
            try
            {
                using (var context = new UszoebContext())
                {
                    var existingVersenyzo = context.Versenyzoks.FirstOrDefault(x => x.Id == id);

                    context.Versenyzoks.Remove(existingVersenyzo);
                    context.SaveChanges();

                    return StatusCode(204, "Versenyző adatainak a törlése sikeresen megtörtént.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}