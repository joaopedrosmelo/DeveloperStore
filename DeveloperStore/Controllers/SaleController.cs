using DeveloperStore.Commands;
using DeveloperStore.Models;
using DeveloperStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            var sale = await _mediator.Send(new GetSaleByIdQuery(id));
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        [HttpGet]
        public async Task<ActionResult> GetSales([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string orderBy = "", [FromQuery] string filter = "")
        {
            var (sales, totalItems) = await _mediator.Send(new GetSalesQuery(page, size, orderBy, filter));
            var response = new
            {
                Data = sales,
                TotalItems = totalItems,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)size)
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSale(Sale sale)
        {
            var saleId = await _mediator.Send(new CreateSaleCommand(sale));
            return CreatedAtAction(nameof(GetSale), new { id = saleId }, sale);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSale(int id, Sale sale)
        {
            if (id != sale.Id) return BadRequest();
            await _mediator.Send(new UpdateSaleCommand(sale));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> CancelSale(int id)
        {
            await _mediator.Send(new CancelSaleCommand(id));
            return NoContent();
        }
    }
}