namespace Rentio.Lib.Exceptions.CreditCard;

public class CardInvalidNumberException : Exception {
    public CardInvalidNumberException() : base("Card Number is invalid") { }
    public CardInvalidNumberException(Exception innerException) : base("Card Number is invalid", innerException) { }
}