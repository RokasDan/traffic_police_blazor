using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class reportsController : ControllerBase
    {
        private readonly ILogger<reportsController> _logger;
        private readonly reportsDbContext _ctx;

        public reportsController(ILogger<reportsController> logger, reportsDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // CRUD methods here !


        // Method for getting a report based on car number plates, a persons first or last names.
        [HttpGet("GetReport/{SearchString}")]
        public async Task<IActionResult> GetReport(string SearchString)
        {
            long searchLong;
            bool isLong = long.TryParse(SearchString, out searchLong);

            var searchData = await _ctx.reports
                                    .Where(r => r.car_id.Equals(SearchString) || (isLong && r.people_id == searchLong))
                                    .Select(r => new
                                    {
                                        report_id = r.report_id,
                                        author = r.author,
                                        car_id = r.car_id ?? "No Car Involved",
                                        people_id = r.people_id,
                                        offence_id = r.offence_id,
                                        fine_issued = r.fine_issued ?? "None issued",
                                        points_issued = r.points_issued ?? "None issued",
                                        report_date = r.report_date,
                                        details = r.details
                                    })
                                    .ToListAsync();

            if (searchData != null && searchData.Any())
            {
                return Ok(searchData);
            }
            else
            {
                return BadRequest();
            }

        }

        // Method for getting a report on base on report id.
        [HttpGet("GetDirectReport/{SearchId}")]
        public async Task<IActionResult> GetDirectReport(string SearchId)
        {
            long searchId = long.Parse(SearchId);

            var reportData = await _ctx.reports
                                    .Where(r => r.report_id == searchId)
                                    .Select(r => new
                                    {
                                        report_id = r.report_id,
                                        author = r.author,
                                        car_id = r.car_id ?? "No Car Involved",
                                        people_id = r.people_id,
                                        offence_id = r.offence_id,
                                        fine_issued = r.fine_issued ?? "None issued",
                                        points_issued = r.points_issued ?? "None issued",
                                        report_date = r.report_date,
                                        details = r.details
                                    })
                                    .FirstOrDefaultAsync();

            if (reportData != null)
            {
                return Ok(reportData);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateReport(long id, reports updatedReport)
        {
            var reportToUpdate = _ctx.reports.FirstOrDefault(r => r.report_id == id);

            if (reportToUpdate != null)
            {
                reportToUpdate.people_id = updatedReport.people_id;
                reportToUpdate.author = updatedReport.author;
                reportToUpdate.car_id = updatedReport.car_id;
                reportToUpdate.people_id = updatedReport.people_id;
                reportToUpdate.offence_id = updatedReport.offence_id;
                reportToUpdate.fine_issued = updatedReport.fine_issued;
                reportToUpdate.points_issued = updatedReport.points_issued;
                reportToUpdate.report_date = updatedReport.report_date;
                reportToUpdate.details = updatedReport.details;
                // Update other properties as needed

                _ctx.reports.Update(reportToUpdate);
                await _ctx.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] reports report)
        {
            _ctx.reports.Add(report);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
