using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.BankAccountDtos;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.API.Dtos.BankTransactionDtos;
using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;
using MinoBank.Core.Enums.BankCard;
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
        [Route("{id}/Details")]
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

        [HttpGet]
        [Route("{id}/BankCards")]
        public async Task<ActionResult<List<BankCardResponseDto>>> GetBankCardsById(Guid id)
        {
            var bankCards = await _bankAccountsService.GetBankCardsByIdAsync(id);
            if(bankCards == null)
            {
                return NotFound($"Bank account with ID {id} not found");
            }
            var bankCardsDtos = _mapper.Map<List<BankCardResponseDto>>(bankCards);
            return Ok(bankCardsDtos);
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

        [HttpPost]
        [Route("{id}/TransferMoney")]
        public async Task<ActionResult<BankTransactionResponseDto>> TransferMoneyToBankCardByNumber(Guid id, [FromBody]BankTransactionCreateRequestDto bankTransactionDto)
        {
            var senderBankCardNumber = bankTransactionDto.SenderBankCardNumber;
            var recipientBankCardNumber = bankTransactionDto.RecipientBankCardNumber;
            if (bankTransactionDto == null)
            {
                return BadRequest("Bank transaction data is required");
            }
            if (string.IsNullOrEmpty(recipientBankCardNumber))
            {
                return BadRequest("Recipient bank card number is required");
            }
            if (string.IsNullOrEmpty(senderBankCardNumber))
            {
                return BadRequest("Recipient bank card number is required");
            }
            if (bankTransactionDto.Amount == 0)
            {
                return BadRequest("Money amount is required");
            }
            try
            {
                var bankTransaction = _mapper.Map<BankTransaction>(bankTransactionDto);
                await _bankAccountsService.TransferMoneyToBankCardByNumberAsync(id, bankTransaction, senderBankCardNumber, recipientBankCardNumber);
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }

        [HttpPost]
        [Route("{id}/BankCards/Create")]
        public async Task<ActionResult<BankCardResponseDto>> CreateBankCard(Guid id, BankCardType bankCardType, BankCardCurrencyCode currencyCode)
        {
            if (bankCardType == null)
            {
                return BadRequest("Bank card type is required");
            }
            if (currencyCode == null)
            {
                return BadRequest("Bank card type is required");
            }
            try
            {
                await _bankAccountsService.CreateBankCardByIdAsync(id, bankCardType, currencyCode);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            };
        }

        [HttpDelete]
        [Route("{id}/Delete")]
        public async Task<ActionResult> DeleteBankAccountById(Guid id)
        {
            try
            {
                await _bankAccountsService.DeleteBankAccountByIdAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}/UpdateStatus")]
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
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}