using BoardSite.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoardSite.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase {
        // GET: api/<CalculatorController>
        [HttpGet]
        public CalculatorResult Get(Operation operation, Decimal operand1, Decimal operand2) {
            CalculatorInput input = new CalculatorInput() { Operation = operation, Operand1 = operand1, Operand2 = operand2 };
            return Calculate(input);
        }

        // POST api/<CalculatorController>
        [HttpPost]
        public CalculatorResult Post([FromBody] CalculatorInput input) {
            return Calculate(input);
        }

        private CalculatorResult Calculate(CalculatorInput input) {
            if (input == null) {
                return new CalculatorResult { HasError = true, ErrorText = "input is empty. provide input" };
            }

            if (input.Operation == Operation.AddOperation) {
                return new CalculatorResult { Result = input.Operand1 + input.Operand2, HasError = false, ErrorText = "" };
            }

            if (input.Operation == Operation.SubstituteOperation) {
                return new CalculatorResult { Result = input.Operand2 - input.Operand1, HasError = false, ErrorText = null };
            }

            return new CalculatorResult { HasError = true, ErrorText = "this operation is not implemented yet" };
        }
    }
}
