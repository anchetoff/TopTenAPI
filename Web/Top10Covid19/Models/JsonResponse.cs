using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Top10Covid19.Models
{
    public class JsonResponse<T>
    {
        public List<T> data { get; set; }
        public List<RegionModel> regions { get; set; }
    }
}