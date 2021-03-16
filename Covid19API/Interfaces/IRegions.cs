using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTenAPI.Common;

namespace TopTenAPI.Interfaces
{
    public interface IResults
    {
        SummaryResponse GetRegions(SummaryRequest request);
        SummaryResponse GetProvinces(SummaryRequest request);
    }
}
