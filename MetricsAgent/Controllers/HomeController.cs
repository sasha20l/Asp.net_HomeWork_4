using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IEnumerable<INotifier> _notifiers;
        public HomeController(IEnumerable<INotifier> notifiers)
        {
            _notifiers = notifiers;
        }
        [HttpGet("")]
        public ActionResult<string> NotifyAll()
        {
            _notifiers.ToList().ForEach(x => x.Notify());
            return "Completed";
        }
    }
}
