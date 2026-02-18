namespace DesignPatternChallenge.DTOs.Payment.Legacy;

public record LegacyTransactionResponse
{
    public string AuthCode { get; set; }
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public string TransactionRef { get; set; }
}