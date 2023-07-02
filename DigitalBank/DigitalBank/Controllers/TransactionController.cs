using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Sacar(string accountNumber, int amount)
        {
            if (!String.IsNullOrEmpty(accountNumber))
            {
                // Verify database if the accountNumber exist
                // if( accountNumber Exist) {
                // puxo o valor em conta
                // if (valor em conta > amount)
                // {
                //  accontAmount = accountAmount - amount;
                //  return Ok("Transação bem sucedida, o seu saldo atual é amount);
                // }
                // else
                // {
                //  return BadRequest("O valor que deseja sacar é maior do que o valor em conta.");
                // }
                // 
                // }
            }

            return BadRequest("Entre Com Um Número de Conta Válido!");
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
