using Rentio.Lib.Validators;
using Rentio.Lib.Exceptions.CreditCard;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Rentio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditCardController : Controller {
    protected CreditCardValidator _creditCardValidator;

    public CreditCardController(CreditCardValidator creditCardValidator) {
        _creditCardValidator = creditCardValidator;
    }

    [HttpGet]
    public IActionResult Get(string cardNumber) {
        try {
            _creditCardValidator.ValidateCardNumber(cardNumber);
            return Ok(new { cardProvider = _creditCardValidator.GetCardType(cardNumber) });
        }
        catch (CardNumberTooLongException ex) {
            return StatusCode((int)HttpStatusCode.RequestUriTooLong,
                new { error = "The card number is too long", code = (int)HttpStatusCode.RequestUriTooLong });
        }
        catch (CardNumberTooShortException) {
            return BadRequest(new { error = "The card number is too short", code = (int)HttpStatusCode.BadRequest });
        }
        catch (CardInvalidNumberException) {
            return BadRequest(new { error = "Invalid Card Number", code = (int)HttpStatusCode.BadRequest });
        }
    }
}