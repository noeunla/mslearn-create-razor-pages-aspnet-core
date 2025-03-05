using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _service;

        public PizzaController(PizzaService service) 
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Pizza> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetById(int id)
        {
            var pizza = _service.GetById(id);

            if (pizza is not null)
            {
                return pizza;
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            var pizza = _service.Create(newPizza);
            return CreatedAtAction(nameof(GetById), new { id = pizza!.Id }, pizza);
        }

        [HttpPut("{id}/addtopping")]
        public IActionResult AddTopping(int id, int toppingId)
        {
            var pizzaToUpdate = _service.GetById(id);

            if (pizzaToUpdate is not null)
            {
                _service.AddTopping(id, toppingId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/updatesauce")]
        public IActionResult UpdateSauce(int id, int sauceId)
        {
            var pizzaToUpdate = _service.GetById(id);

            if (pizzaToUpdate is not null)
            {
                _service.UpdateSauce(id, sauceId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Pizza pizza)
        //{
        //    if (id != pizza.Id)
        //        return BadRequest();

        //    var existingPizza = PizzaService.Get(id);
        //    if (existingPizza is null)
        //        return NotFound();

        //    PizzaService.Update(pizza);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = _service.GetById(id);

            if (pizza is not null)
            {
                _service.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //Copilot
        //[HttpPatch("{id}")]
        //public IActionResult UpdatePartial(int id, [FromBody] JsonPatchDocument<Pizza> patchDoc)
        //{
        //    if (patchDoc == null)
        //        return BadRequest();

        //    var existingPizza = PizzaService.Get(id);
        //    if (existingPizza is null)
        //        return NotFound();

        //    patchDoc.ApplyTo(existingPizza, ModelState);

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    PizzaService.Update(existingPizza);

        //    return NoContent();
        //}


    }
}
