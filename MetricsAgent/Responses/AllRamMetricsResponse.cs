using System.Collections.Generic;
using MetricsAgent.DTO;

namespace MetricsAgent.DAL.Responses
{
    public class AllRamMetricsResponse
    {
        public List<RamMetricDto> Metrics { get; set; }

    }
}
