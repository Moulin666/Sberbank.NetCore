namespace Sberbank.NetCore.Tools
{
    public enum PaymentStatus
    {
        Registered = 0,
        Reserved = 1,
        AuthorizedOrCompleted = 2,
        AuthorizationCanceled = 3,
        Refunded = 4,
        ACS = 5,
        AuthorizationDenied = 6
    }
}
