using System.Collections.Generic;
using MetricsAgent.DAL.interfaces;
using MetricsAgent.DAL.Request;
using MetricsAgent.DAL.Responses;
using MetricsAgent.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricAgentController : ControllerBase
    {
        private ICpuMetricsRepository repository;

        public MetricAgentController(ICpuMetricsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            repository.Create(new CpuMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        [HttpPost("read")]
        public IActionResult GetFullMetric()
        {
            return Ok();
        }
        [HttpPut("enable")]
        public IActionResult EnableAgentById()
        {
            return Ok();
        }
        [HttpPut("disable")]
        public IActionResult DisableAgentById()
        {
            return Ok();
        }
    }
    public class DotNetMetricAgentController : ControllerBase
    {
        private IDotNetMetricsRepository repository;

        public DotNetMetricAgentController(IDotNetMetricsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            repository.Create(new DotNetMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new DotNetMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        [HttpPost("read")]
        public IActionResult GetFullMetric()
        {
            return Ok();
        }
        [HttpPut("enable")]
        public IActionResult EnableAgentById()
        {
            return Ok();
        }
        [HttpPut("disable")]
        public IActionResult DisableAgentById()
        {
            return Ok();
        }
    }
    public class HddMetricAgentController : ControllerBase
    {
        private IHddMetricsRepository repository;

        public HddMetricAgentController(IHddMetricsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            repository.Create(new HddMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        [HttpPost("read")]
        public IActionResult GetFullMetric()
        {
            return Ok();
        }
        [HttpPut("enable")]
        public IActionResult EnableAgentById()
        {
            return Ok();
        }
        [HttpPut("disable")]
        public IActionResult DisableAgentById()
        {
            return Ok();
        }
    }
    public class NetworkMetricAgentController : ControllerBase
    {
        private INetworkMetricsRepository repository;

        public NetworkMetricAgentController(INetworkMetricsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] NetworkMetricCreateRequest request)
        {
            repository.Create(new NetworkMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllNetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new NetworkMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        [HttpPost("read")]
        public IActionResult GetFullMetric()
        {
            return Ok();
        }
        [HttpPut("enable")]
        public IActionResult EnableAgentById()
        {
            return Ok();
        }
        [HttpPut("disable")]
        public IActionResult DisableAgentById()
        {
            return Ok();
        }
    }
    public class RamMetricAgentController : ControllerBase
    {
        private IRamMetricsRepository repository;

        public RamMetricAgentController(IRamMetricsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            repository.Create(new RamMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        [HttpPost("read")]
        public IActionResult GetFullMetric()
        {
            return Ok();
        }
        [HttpPut("enable")]
        public IActionResult EnableAgentById()
        {
            return Ok();
        }
        [HttpPut("disable")]
        public IActionResult DisableAgentById()
        {
            return Ok();
        }
    }
}

