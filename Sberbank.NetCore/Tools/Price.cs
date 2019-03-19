using System;

namespace Sberbank.NetCore.Tools
{
    public class Price
    {
        public int Decimal { get; set; }
        public int Float { get; set; }

        public int MinorFormat => Decimal * 100 + Float;
        public double DoubleFormat => ((double)MinorFormat) / 100;

        public Price(double value)
        {
            Decimal = (int)Math.Floor(value);
            Float = (int)(Math.Floor((value - Math.Floor(value)) * 100));
        }

        public Price(int minorPrice)
        {
            var abs = Math.Abs(minorPrice);

            Decimal = abs / 100;
            Float = abs % 100;
        }

        public Price(int @decimal, int @float)
        {
            Decimal = @decimal;
            Float = @float;
        }

        public static Price Zero => new Price(0, 0);
    }
}
