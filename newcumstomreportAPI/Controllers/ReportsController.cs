using Microsoft.AspNetCore.Components;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.AspNetCore;

namespace newcumstomreportAPI.Controllers
{
    [Route("api/reports")]
    public class ReportsController:ReportsControllerBase
    {
        public ReportsController(IReportServiceConfiguration reportServiceConfiguration) :base(reportServiceConfiguration){ }
    }
}
