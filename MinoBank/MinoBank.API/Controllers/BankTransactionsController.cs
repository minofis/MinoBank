using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.BankTransactionDtos;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("MinoBank/[controller]")]
    public class BankTransactionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBankTransactionsService _bankTransactionsService;
        public BankTransactionsController(IBankTransactionsService bankTransactionsService, IMapper mapper)
        {
            _bankTransactionsService = bankTransactionsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankTransactionResponseDto>>> GetAllBankTransactions()
        {
            var bankTransactions = await _bankTransactionsService.GetAllBankTransactionsAsync();
            var bankTransactionDtos = _mapper.Map<List<BankTransactionResponseDto>>(bankTransactions);
            return Ok(bankTransactionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankTransactionResponseDto>> GetBankTransactionById(Guid id)
        {
            var bankTransaction = await _bankTransactionsService.GetBankTransactionByIdAsync(id);
            if (bankTransaction == null)
            {
                return NotFound($"Bank transaction with ID {id} not found");
            }
            var bankTransactionDto = _mapper.Map<BankTransactionResponseDto>(bankTransaction);
            return Ok(bankTransactionDto);
        }

        [HttpDelete]
        [Route("{id}/Delete")]
        public async Task<ActionResult> DeleteBankTransactionById(Guid id)
        {
            try
            {
                await _bankTransactionsService.DeleteBankTransactionByIdAsync(id);
                return NoContent();
            } 
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}