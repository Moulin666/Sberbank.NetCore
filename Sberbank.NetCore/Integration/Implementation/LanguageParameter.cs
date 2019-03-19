using Sberbank.NetCore.Integration.Interfaces;

namespace Sberbank.NetCore.Integration.Implementation
{
    public sealed class LanguageParameter : IValueParameter
    {
        public static readonly LanguageParameter Ru = new LanguageParameter("ru");
        public static readonly LanguageParameter En = new LanguageParameter("en");

        public string Value { get; private set; }

        public LanguageParameter(string value) => Value = value;
    }
}
