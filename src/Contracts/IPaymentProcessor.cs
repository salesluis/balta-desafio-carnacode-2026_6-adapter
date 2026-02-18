using balta_desafio_carnacode_2026_6_adapter.Services.Payment;
using DesignPatternChallenge.DTOs.Payment.Modern;

namespace DesignPatternChallenge.Contracts;

public interface IPaymentProcessor
{
    PaymentResult ProcessPayment(PaymentRequest request);
    bool RefundPayment(string transactionId, decimal amount);
    PaymentStatus CheckStatus(string transactionId);
}