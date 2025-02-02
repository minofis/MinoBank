using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.BankAccountDtos;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.Core.Entities;
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

        [Authorize(Policy = "BankAccountOwnerPolicy")]
        [HttpGet("by-current-user")]
        public async Task<ActionResult<List<BankAccountResponseDto>>> GetBankAccountsByUser()
        {
            // Get user id from the jwt token
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            // Check user id
            if (userId == null)
            {
                return Unauthorized("User isn't authenticated");
            }
            try
            {
            // Get all bank accounts
            var bankAccounts = await _bankAccountsService.GetBankAccountsByUserAsync(userId);

            // Map the bank accounts to a list of response DTOs
            var bankAccountResponseDtos = _mapper.Map<List<BankAccountResponseDto>>(bankAccounts);

            // Return a 200 Ok response with the list of bank accounts
            return Ok(bankAccountResponseDtos);
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

        [Authorize(Policy = "BankAccountOwnerPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountResponseDto>> GetBankAccount(Guid id)
        {
            // Get user id from the jwt token
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            // Check user id
            if (userId == null)
            {
                return Unauthorized("User isn't authenticated");
            }
            try
            {
                // Get bank account by the specified ID
                var bankAccount = await _bankAccountsService.GetBankAccountByIdAsync(id);

                if (bankAccount.UserId != userId)
                {
                    return Forbid("Bearer");
                }

                // Map the bank account entity to response DTO
                var bankAccountResponseDto = _mapper.Map<BankAccountResponseDto>(bankAccount);

                // Return a 200 Ok response with the bank account
                return Ok(bankAccountResponseDto);
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

        [Authorize(Policy = "BankAccountOwnerPolicy")]
        [HttpGet("{id}/details")]
        public async Task<ActionResult<BankAccountDetailsResponseDto>> GetBankAccountDetails(Guid id)
        {
            // Get user id from the jwt token
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            // Check user id
            if (userId == null)
            {
                return Unauthorized("User isn't authenticated");
            }
            try
            {
                // Get the bank account details by the specified ID
                var bankAccountDetails = await _bankAccountsService.GetBankAccountDetailsByIdAsync(id);

                if (bankAccountDetails.BankAccount.UserId != userId)
                {
                    return Forbid("Bearer");
                }

                // Map the bank account details entity to response DTO
                var bankAccountDetailsResponseDto = _mapper.Map<BankAccountDetailsResponseDto>(bankAccountDetails);

                // Return a 200 Ok response with the bank account details
                return Ok(bankAccountDetailsResponseDto);
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


        [Authorize(Policy = "BankAccountOwnerPolicy")]
        [HttpGet("{id}/bank-cards")]
        public async Task<ActionResult<List<BankCardResponseDto>>> GetBankCards(Guid id)
        {
            // Get user id from the jwt token
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            // Check user id
            if (userId == null)
            {
                return Unauthorized("User isn't authenticated");
            }
            try
            {
                var bankAccount = await _bankAccountsService.GetBankAccountByIdAsync(id);

                if (bankAccount.UserId != userId)
                {
                    return Forbid("Bearer");
                }

                // Get all bank cards associated with the specified bank account ID
                var bankCards = await _bankAccountsService.GetBankCardsByIdAsync(id);

                // Map the bank cards to a list of response DTOs
                var bankCardsDtos = _mapper.Map<List<BankCardResponseDto>>(bankCards);

                // Return a 200 Ok response with the list of bank cards
                return Ok(bankCardsDtos);
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

        [Authorize(Policy = "BankAccountOwnerPolicy")]
        [HttpPost]
        public async Task<ActionResult<BankAccountResponseDto>> Create([FromBody]BankAccountCreateRequestDto bankAccountDto)
        {
            // Get user id from the jwt token
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            // Check user id
            if (userId == null)
            {
                return Unauthorized("User isn't authenticated");
            }

            // Validate the incomming request
            if (bankAccountDto == null)
            {
                return BadRequest("Bank account data is required");
            }
            try
            {
                // Create a new bank account 
                await _bankAccountsService.CreateBankAccountAsync(userId, bankAccountDto.Type);

                // Return a 201 Created response
                return Created();
            }
            catch (ArgumentException ex)
            {
                // Return a 404 Not Found response with the error message
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
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
    }
}
/*
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
*/