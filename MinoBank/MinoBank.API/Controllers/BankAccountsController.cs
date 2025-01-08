using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.BankAccountDtos;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("minobank/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBankAccountsService _bankAccountsService;
        public BankAccountsController(IBankAccountsService bankAccountsService, IMapper mapper)
        {
            _bankAccountsService = bankAccountsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankAccountResponseDto>>> GetBankAccounts()
        {
            // Get all bank accounts
            var bankAccounts = await _bankAccountsService.GetAllBankAccountsAsync();

            // Map the bank accounts to a list of response DTOs
            var bankAccountResponseDtos = _mapper.Map<List<BankAccountResponseDto>>(bankAccounts);

            // Return a 200 Ok response with the list of bank accounts
            return Ok(bankAccountResponseDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountResponseDto>> GetBankAccount(Guid id)
        {
            // Get bank account by the specified ID
            var bankAccount = await _bankAccountsService.GetBankAccountByIdAsync(id);

            // If the bank account does not exist, return a 404 Not Found response
            if(bankAccount == null)
            {
                // Return 404 status code
                return NotFound($"Bank account with ID {id} not found");
            }

            // Map the bank account entity to response DTO
            var bankAccountResponseDto = _mapper.Map<BankAccountResponseDto>(bankAccount);

            // Return a 200 Ok response with the bank account
            return Ok(bankAccountResponseDto);
        }

        [HttpGet]
        [Route("{id}/details")]
        public async Task<ActionResult<BankAccountDetailsResponseDto>> GetBankAccountDetails(Guid id)
        {
            // Get the bank account details by the specified ID
            var bankAccountDetails = await _bankAccountsService.GetBankAccountDetailsByIdAsync(id);

            // If the bank account does not exist, return a 404 Not Found response
            if(bankAccountDetails == null)
            {
                return NotFound($"Bank account with ID {id} not found");
            }

            // Map the bank account details entity to response DTO
            var bankAccountDetailsResponseDto = _mapper.Map<BankAccountDetailsResponseDto>(bankAccountDetails);

            // Return a 200 Ok response with the bank account details
            return Ok(bankAccountDetailsResponseDto);
        }

        [HttpPost]
        public async Task<ActionResult<BankAccountResponseDto>> Create([FromBody]BankAccountCreateRequestDto bankAccountDto)
        {
            // Validate the incomming request
            if (bankAccountDto == null)
            {
                return BadRequest("Bank account data is required");
            }
            try
            {
                // Map the request DTO to a bank account entity
                var bankAccount = _mapper.Map<BankAccount>(bankAccountDto);

                // Create a new bank account 
                await _bankAccountsService.CreateBankAccountAsync(bankAccount);

                // Map the bank account entity to a response DTO
                var bankAccountResponseDto = _mapper.Map<BankAccountResponseDto>(bankAccount);

                // Return a 201 Created response with the bank account
                return CreatedAtAction(nameof(GetBankAccount), new {id = bankAccount.Id}, bankAccountResponseDto);
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }

        [HttpGet]
        [Route("{id}/bank-cards")]
        public async Task<ActionResult<List<BankCardResponseDto>>> GetBankCards(Guid id)
        {
            // Get all bank cards associated with the specified bank account ID
            var bankCards = await _bankAccountsService.GetBankCardsByIdAsync(id);

            // If the bank account does not exist, return a 404 Not Found response
            if(bankCards == null)
            {
                return NotFound($"Bank account with ID {id} not found");
            }

            // Map the bank cards to a list of response DTOs
            var bankCardsDtos = _mapper.Map<List<BankCardResponseDto>>(bankCards);

            // Return a 200 Ok response with the list of bank cards
            return Ok(bankCardsDtos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Delete bank account service method
                await _bankAccountsService.DeleteBankAccountByIdAsync(id);

                // Return a 200 Ok response
                return Ok("Bank account is deleted successfully");
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

        [HttpPut]
        [Route("{id}/status")]
        public async Task<ActionResult> UpdateBankAccountStatus(Guid id, BankAccountStatus newStatus)
        {
            // Validate if the status is valid
            if (!Enum.IsDefined(typeof(BankAccountStatus), newStatus))
            {
                return BadRequest("Invalid status value");
            }
            try
            {
                // Update bank account status service method
                await _bankAccountsService.UpdateBankAccountStatusByIdAsync(id, newStatus);

                // Return a 200 Ok response
                return Ok("Bank account status is updated successfully");
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
}