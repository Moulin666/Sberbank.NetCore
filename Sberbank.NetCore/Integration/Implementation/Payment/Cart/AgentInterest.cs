using Sberbank.NetCore.Integration.Interfaces;
using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public class AgentInterest : IParameters
    {
        public AgentInterest() : this(string.Empty, 0) { }

        public AgentInterest(string type, int value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }

        public int Value { get; set; }

        #region Implementation of IParameters

        public Dictionary<string, object> CollectParameters()
        {
            var result = new Dictionary<string, object>
            {
                { Keys.Type, Type },
                { Keys.Value, $"{Value}" }
            };

            return result;
        }

        #endregion

        private static class Keys
        {
            public static readonly string Type = "interestType";
            public static readonly string Value = "interestValue";
        }
    }
}
