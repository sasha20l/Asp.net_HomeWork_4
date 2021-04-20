using System;

using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    public class DotNetMetric : Controller
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
