using balta_desafio_carnacode_2026_6_adapter.Services.Payment;
using DesignPatternChallenge.Contracts;
using DesignPatternChallenge.DTOs.Payment.Legacy;
using DesignPatternChallenge.DTOs.Payment.Modern;
using DesignPatternChallenge.Services.Payment.Legacy;

namespace DesignPatternChallenge.Adapter;

public class PaymentAdapter : IPaymentProcessor
{
    private readonly LegacyPaymentSystem _legacyPaymentSystem;
    public PaymentAdapter(LegacyPaymentSystem  legacyPaymentSystem)
    {
        _legacyPaymentSystem = legacyPaymentSystem;
    }
    
    public PaymentResult ProcessPayment(PaymentRequest request)
    {
        var requestLegacy = new LegacyTransactionRequest(request.CreditCardNumber, (double)request.Amount); 
        var resultLegacy = _legacyPaymentSystem.AuthorizeTransaction(requestLegacy);
        var result = new PaymentResult
        {
             Success = true,
             TransactionId = resultLegacy.TransactionRef,
             Message = resultLegacy.ResponseMessage
        };

        return result;
    }

    public bool RefundPayment(string transactionId, decimal amountInCents)
    {
        Console.WriteLine($"[Sistema Legado] Revertendo transação {transactionId}");
        Console.WriteLine($"Valor: {amountInCents / 100:C}");
        return true;
    }

    public PaymentStatus CheckStatus(string transactionId)
    {
        Console.WriteLine($"[Sistema Legado] Consultando transação {transactionId}");
        return PaymentStatus.Approved;
    }
}