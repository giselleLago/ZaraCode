using System.Collections.Generic;
using ZaraCode.Models;

namespace ZaraCode.Services
{
    public interface IExporter
    {
        void Export(IEnumerable<Stocks> stocks, string fileName);
    }
}
