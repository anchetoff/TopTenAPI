using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenService.Client.Interface
{
    public interface ITopTenClient : IDisposable
    {
        SummaryResponse GetResults(TopTenRequest request);
    }
}
