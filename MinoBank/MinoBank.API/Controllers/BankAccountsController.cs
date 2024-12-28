using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos;
using MinoBank.API.Dtos.BankAccount;
using MinoBank.API.Dtos.BankAccountDetails;
using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccounts;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("MinoBank/[controller]")]
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
        public async Task<ActionResult<List<BankAccountResponseDto>>> GetAllBankAccounts()
        {
            var bankAccounts = await _bankAccountsService.GetAllBankAccountsAsync();
            var bankAccountResponseDtos = _mapper.Map<List<BankAccountResponseDto>>(bankAccounts);
            return Ok(bankAccountResponseDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountResponseDto>> GetBankAccountById(Guid id)
        {
            var bankAccount = await _bankAccountsService.GetBankAccountByIdAsync(id);
            if(bankAccount == null)
            {
                return NotFound($"Bank account with ID {id} not found");
            }
            var bankAccountResponseDto = _mapper.Map<BankAccountResponseDto>(bankAccount);
            return Ok(bankAccountResponseDto);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult<BankAccountDetailsResponseDto>> GetBankAccountDetailsById(Guid id)
        {
            var bankAccountDetails = await _bankAccountsService.GetBankAccountDetailsByIdAsync(id);
            if(bankAccountDetails == null)
            {
                return NotFound($"Bank account with ID {id} not found");
            }
            var bankAccountDetailsResponseDto = _mapper.Map<BankAccountDetailsResponseDto>(bankAccountDetails);
            return Ok(bankAccountDetailsResponseDto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<BankAccountResponseDto>> CreateBankAccount([FromBody]BankAccountCreateRequestDto bankAccountDto)
        {
            if (bankAccountDto == null)
            {
                return BadRequest("Bank account data is required");
            }
            if (string.IsNullOrEmpty(bankAccountDto.OwnerName))
            {
                return BadRequest("Owner name is required");
            }
            try
            {
                var bankAccount = _mapper.Map<BankAccount>(bankAccountDto);
                await _bankAccountsService.CreateBankAccountAsync(bankAccount);
                var bankAccountResponseDto = _mapper.Map<BankAccountResponseDto>(bankAccount);
                return CreatedAtAction(nameof(GetBankAccountById), new {id = bankAccount.Id}, bankAccountResponseDto);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteBankAccountById(Guid id)
        {
            try
            {
                await _bankAccountsService.DeleteBankAccountByIdAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex. Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPut]
        [Route("UpdateStatus/{id}")]
        public async Task<ActionResult> UpdateBankAccountStatusById(Guid id, BankAccountStatus newStatus)
        {
            if (newStatus == null)
            {
                return BadRequest("Status is required");
            }
            try
            {
                await _bankAccountsService.UpdateBankAccountStatusByIdAsync(id, newStatus);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex. Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateType/{id}")]
        public async Task<ActionResult> UpdateBankAccountTypeById(Guid id, BankAccountType newType)
        {
            if (newType == null)
            {
                return BadRequest("Type is required");
            }
            try
            {
                await _bankAccountsService.UpdateBankAccountTypeByIdAsync(id, newType);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex. Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}