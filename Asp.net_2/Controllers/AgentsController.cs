using System;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            return Ok();
        }
        [HttpPost("read")]
        public IActionResult GetRegisterAgent()
        {
            return Ok();
        }
        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
    }
    public class AgentInfo
    {
        public int AgentId { get; }
        public Uri AgentAddress { get; }
    }
}
