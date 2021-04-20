using System;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_2.Controllers
{
    public class CpuMetrics : Controller
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
