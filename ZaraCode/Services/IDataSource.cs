using System.Collections.Generic;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public interface IDataSource
    {
        IList<DailyStock> ExtractData();
    }
}
