using ZaraCode.Models;

namespace ZaraCode.Services
{
    public interface IExporter
    {
        void Export(InvestmetResult result, string fileName);
    }
}
