using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.API.Dtos.BankTransactionDtos;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("minobank/[controller]")]
    public class BankCardsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBankCardsService _bankCardsService;
        public BankCardsController(IBankCardsService bankCardsService, IMapper mapper)
        {
            _bankCardsService = bankCardsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BankCardResponseDto>>> GetAllBankCards()
        {
            // Get all bank cards
            var bankCards = await _bankCardsService.GetAllBankCardsAsync();

            // Map the bank cards to a list of response DTOs
            var bankCardsResponseDtos = _mapper.Map<List<BankCardResponseDto>>(bankCards);

            // Return a 200 Ok response with the list of bank cards
            return Ok(bankCardsResponseDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankCardResponseDto>> GetBankCard(Guid id)
        {
            try
            {
                // Get bank card by the specified ID
                var bankCard = await _bankCardsService.GetBankCardByIdAsync(id);

                // Map the bank card to response DTO
                var bankCardDto = _mapper.Map<BankCardResponseDto>(bankCard);

                // Return a 200 Ok response with the bank card
                return Ok(bankCardDto);
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

        [HttpGet]
        [Route("{id}/details")]
        public async Task<ActionResult<BankCardDetailsResponseDto>> GetBankCardDetailsById(Guid id)
        {
            try
            {
                // Get bank card details by the specified ID
                var bankCardDetails = await _bankCardsService.GetBankCardDetailsByIdAsync(id);

                // Map the bank card details to response DTO
                var bankCardDetailsResponseDto = _mapper.Map<BankCardDetailsResponseDto>(bankCardDetails);

                // Return a 200 Ok response with the bank card details
                return Ok(bankCardDetailsResponseDto);
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

        [HttpGet]
        [Route("{id}/sent-transactions")]
        public async Task<ActionResult<List<BankTransaction>>> GetSentTransactions(Guid id)
        {
            try
            {
                // Get sent transactions associated with the specified bank card ID
                var sentTransactions = await _bankCardsService.GetSentTransactionsByIdAsync(id);

                // Map the sent transactions to a list of response DTOs
                var sentTransactionDtos = _mapper.Map<List<BankTransactionResponseDto>>(sentTransactions);

                // Return a 200 Ok response with the list of sent transactions
                return Ok(sentTransactionDtos);
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

        [HttpGet]
        [Route("{id}/recived-transactions")]
        public async Task<ActionResult<List<BankTransaction>>> GetRecivedTransactions(Guid id)
        {
            try
            {
                // Get recived transactions associated with the specified bank card ID
                var recivedTransactions = await _bankCardsService.GetRecivedTransactionsByIdAsync(id);

                // Map the recived transactions to a list of response DTOs
                var recivedTransactionDtos = _mapper.Map<List<BankTransactionResponseDto>>(recivedTransactions);

                // Return a 200 Ok response with the list of recived transactions
                return Ok(recivedTransactionDtos);
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

        [HttpPost]
        [Route("{id}/top-up")]
        public async Task<ActionResult> TopUpCard(Guid id, [FromQuery] decimal topUpAmount)
        {
            // Validate the top up amount value
            if (topUpAmount <= 0)
            {
                return BadRequest("Top up amount must be greater than 0.");
            }
            try
            {
                // Top-up card service method
                await _bankCardsService.TopUpBankCardByIdAsync(id, topUpAmount);

                // Return a 200 Ok response
                return Ok("Bank card top-up successful.");
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

        [HttpPost]
        [Route("{id}/funds-transfer")]
        public async Task<ActionResult> FundsTransfer(
            Guid id,
            [FromBody]BankTransactionCreateRequestDto bankTransactionDto)
        {
            // Validate the incomming request
            if (bankTransactionDto == null)
            {
                return BadRequest("Bank transaction data is required");
            }
            try
            {
                // Map the request DTO to a bank transaction entity
                var bankTransaction = _mapper.Map<BankTransaction>(bankTransactionDto);

                // Funds transfer service method
                await _bankCardsService.FundsTransferToBankCardByIdAsync(id, bankTransaction);

                // Return a 200 Ok response
                return Ok("Bank card funds transfer successful.");
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

        [HttpPost]
        public async Task<ActionResult<BankCardResponseDto>> Create(BankCardCreateRequestDto bankCardDto)
        {
            try
            {
                // Map the request DTO to a bank card entity
                var bankCard = _mapper.Map<BankCard>(bankCardDto);

                // Create a new bank card
                await _bankCardsService.CreateBankCardAsync(bankCard);

                // Map the bank card entity to response DTO
                var bankCardResponseDto = _mapper.Map<BankCardResponseDto>(bankCard);

                // Return a 201 Created response with the bank card
                return CreatedAtAction(nameof(GetBankCard), new {id = bankCard.Id}, bankCardResponseDto);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Delete bank card service method
                await _bankCardsService.DeleteBankCardByIdAsync(id);

                // Return a 200 Ok response
                return Ok("Bank card is deleted successfully");
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