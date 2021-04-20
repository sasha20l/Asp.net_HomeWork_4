
using System.Collections.Generic;
using MetricsAgent.DTO;

namespace MetricsAgent.DAL.Responses
{
    public class AllDotNetMetricsResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }

    }
}
