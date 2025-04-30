using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Data;
using System;

namespace PerformanceManagementSystem.PerformanceManagementSystem.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestConnectionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestConnectionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CheckConnection()
        {
            try
            {
                await _context.Database.CanConnectAsync();
                return Ok("✅ Connected to database successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Failed to connect: {ex.Message}");
            }
        }
    }
}
