using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.API.Controllers
{
    [ApiController]
    [Route("MinoBank/[controller]")]
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
            var bankCards = await _bankCardsService.GetAllBankCardsAsync();
            var bankCardsResponseDtos = _mapper.Map<List<BankCardResponseDto>>(bankCards);
            return Ok(bankCardsResponseDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankCardResponseDto>> GetBankCardById(Guid id)
        {
            var bankCard = await _bankCardsService.GetBankCardByIdAsync(id);
            if (bankCard == null)
            {
                return NotFound($"Bank account with ID {id} not found");
            }
            var bankCardResponseDtos = _mapper.Map<BankCardResponseDto>(bankCard);
            return Ok(bankCardResponseDtos);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult<BankCardDetailsResponseDto>> GetBankCardDetailsById(Guid id)
        {
            var bankCardDetails = await _bankCardsService.GetBankCardDetailsByIdAsync(id);
            if (bankCardDetails == null)
            {
                return NotFound($"Bank card with ID {id} not found");
            }
            var bankCardDetailsResponseDto = _mapper.Map<BankCardDetailsResponseDto>(bankCardDetails);
            return Ok(bankCardDetailsResponseDto);
        }

        [HttpDelete]
        [Route("Delete/{bankCardId}")]
        public async Task<ActionResult> DeleteBankAccountById(Guid bankCardId)
        {
            try
            {
                await _bankCardsService.DeleteBankCardByIdAsync(bankCardId);
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