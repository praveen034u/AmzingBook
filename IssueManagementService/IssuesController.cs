using IssueManagementService.Models;
using IssueManagementService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IssueManagementService
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IssueDbContext _context;

        public IssuesController(IssueDbContext context)
        {
            _context = context;
        }

        [HttpGet("{custId}")]
        public async Task<IActionResult> GetIssuesByCustomer(string custId) => Ok(await _context.Issues.Where(i => i.CustomerId == custId).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> IssueBook([FromBody] Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIssuesByCustomer), new { custId = issue.CustomerId }, issue);
        }

        [HttpDelete("{custId}/{isbn}")]
        public async Task<IActionResult> CancelIssue(string custId, string isbn)
        {
            var issue = await _context.Issues.FirstOrDefaultAsync(i => i.CustomerId == custId && i.Isbn == isbn);
            if (issue == null) return NotFound();

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
