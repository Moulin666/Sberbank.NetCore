namespace Sberbank.NetCore.Integration.Implementation.Payment.Cart
{
    public enum ItemTaxType
    {
        WithoutVat = 0,
        Vat0 = 1,
        Vat10 = 2,
        Vat18 = 3,
        Vat10On110 = 4,
        Vat18On118 = 5,
    }
}
