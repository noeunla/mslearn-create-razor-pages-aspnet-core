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
        public PizzaController() { }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }

        //Copilot
        //[HttpPatch("{id}")]
        //public IActionResult UpdatePartial(int id, Pizza patchDoc)
        //{
        //    if (patchDoc == null)
        //        return BadRequest();

        //    var existingPizza = PizzaService.Get(id);
        //    if (existingPizza is null)
        //        return NotFound();

        //    var notNullProperties = ObjectExtensions.GetNotNullProperties(patchDoc);

        //    foreach (var prop in notNullProperties)
        //    {
        //        //Console.WriteLine($"{prop.Name} = {prop.GetValue(pizza)}");

        //    }

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    PizzaService.Update(existingPizza);

        //    return NoContent();
        //}

        //Copilot
        [HttpPatch("{id}")]
        public IActionResult UpdatePartial(int id, [FromBody] JsonPatchDocument<Pizza> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            patchDoc.ApplyTo(existingPizza, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PizzaService.Update(existingPizza);

            return NoContent();
        }


    }
}
