using Sberbank.NetCore.Integration.Interfaces;

namespace Sberbank.NetCore.Integration.Implementation.Payment
{
    public sealed class RegisterPaymentFeatures : IValueParameter
    {
        public static readonly RegisterPaymentFeatures AutoPayment = new RegisterPaymentFeatures("AUTO_PAYMENT");

        internal RegisterPaymentFeatures(string value) => Value = value;

        public string Value { get; private set; }
    }
}
