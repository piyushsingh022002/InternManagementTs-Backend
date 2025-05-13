using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using InternManagementAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _hasher;

        public InternsController(AppDbContext context)
        {
            _context = context;
            _hasher = new PasswordHasher<User>();
        }

        // GET: /api/interns (HR only)
        [HttpGet]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> GetAllInterns()
        {
            var interns = await _context.Interns.ToListAsync();
            return Ok(interns);
        }

        // POST: /api/interns (HR only)
        [HttpPost]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> CreateIntern(CreateInternRequest request)
        {
            // Generate InternId
            string internId = $"INT-{Guid.NewGuid().ToString().Substring(0, 8)}";

            var internUser = new User
            {
                InternId = internId,
                Email = request.Email,
                Role = "Intern"
            };
            internUser.PasswordHash = _hasher.HashPassword(internUser, request.Password);

            await _context.Users.AddAsync(internUser);

            var intern = new Intern
            {
                InternId = internId,
                Name = request.Name,
                Domain = request.Domain,
                College = request.College,
                JoiningDate = request.JoiningDate
            };

            await _context.Interns.AddAsync(intern);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Intern created", internId });
        }

        // GET: /api/interns/me (Intern only)
        [HttpGet("me")]
        [Authorize(Roles = "Intern")]
        public async Task<IActionResult> GetMyData()
        {
            string internId = User.FindFirstValue("InternId");

            var intern = await _context.Interns
                .FirstOrDefaultAsync(i => i.InternId == internId);

            if (intern == null)
                return NotFound("No data found");

            return Ok(intern);
        }
    }
}
