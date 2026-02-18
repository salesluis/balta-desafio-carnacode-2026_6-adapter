namespace DesignPatternChallenge.DTOs.Payment.Modern;

public record PaymentResult
{
    public bool Success { get; set; }
    public string TransactionId { get; set; }
    public string Message { get; set; }
}