using System.Collections.Generic;

namespace Sberbank.NetCore.Integration.Interfaces
{
    public interface IParameters
    {
        Dictionary<string, object> CollectParameters();
    }
}
