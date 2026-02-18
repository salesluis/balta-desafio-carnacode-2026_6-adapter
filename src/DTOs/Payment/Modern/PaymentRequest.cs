namespace DesignPatternChallenge.DTOs.Payment.Modern;

public record PaymentRequest
{
    public string CustomerEmail { get; set; }
    public decimal Amount { get; set; }
    public string CreditCardNumber { get; set; }
    public string Cvv { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Description { get; set; }
}