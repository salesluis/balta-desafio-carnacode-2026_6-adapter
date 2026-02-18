  using balta_desafio_carnacode_2026_6_adapter.Services;
  using DesignPatternChallenge.Adapter;
  using DesignPatternChallenge.Services.Payment.Legacy;
  using DesignPatternChallenge.Services.Payment.Modern;
  
  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Checkout ===\n");

            // Funciona bem com o processador moderno
            var modernProcessor = new ModernPaymentProcessor();
            var checkoutWithModern = new CheckoutService(modernProcessor);
            checkoutWithModern.CompleteOrder("cliente@email.com", 150.00m, "4111111111111111");

            Console.WriteLine("\n" + new string('-', 60) + "\n");

            // Problema: Como usar o sistema legado sem modificar CheckoutService?
            // Resolvido: Pode usar o adapter que implementa a interface moderna
            var legacySystem = new LegacyPaymentSystem();
            var adapter = new PaymentAdapter(legacySystem);
            
            // ISSO FUNCIONA - Interfaces compatíveis
             var checkoutWithLegacy = new CheckoutService(adapter); // COMPILA NORMALMENTE!
             checkoutWithLegacy.CompleteOrder("teste@teste.com", 10, "5111111111111111");
        }
    }

