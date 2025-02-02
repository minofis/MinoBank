using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.BankTransactionDtos;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
/*
    [ApiController]
    [Route("minobank/[controller]")]
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
            // Get all bank transactions
            var bankTransactions = await _bankTransactionsService.GetAllBankTransactionsAsync();

            // Map the bank transactions to a list of response DTOs
            var bankTransactionDtos = _mapper.Map<List<BankTransactionResponseDto>>(bankTransactions);

            // Return a 200 Ok response with the list of bank transactions
            return Ok(bankTransactionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankTransactionResponseDto>> GetBankTransaction(Guid id)
        {
            try
            {
                // Get bank transaction by the specified ID
                var bankTransaction = await _bankTransactionsService.GetBankTransactionByIdAsync(id);

                // Map the bank transaction to response DTO
                var bankTransactionDto = _mapper.Map<BankTransactionResponseDto>(bankTransaction);

                // Return a 200 Ok response with the bank transaction
                return Ok(bankTransactionDto);
            }
            catch (ArgumentException ex)
            {
                // Return a 404 Not Found response with the error message
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }
    }
*/
}