using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepo, IPortfolioRepository portfolioRepo){
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepo = portfolioRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }
    }
}

// eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXJAZXhhbXBsZTEuY29tIiwiZ2l2ZW5fbmFtZSI6ImV4YW1wbGUxIiwibmJmIjoxNzM1MTI3MzkxLCJleHAiOjE3MzU3MzIxOTEsImlhdCI6MTczNTEyNzM5MSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2In0.mBYNrmCYhVCc0XQNAhqOXghFcEoJW14bhFWLAXCyD_YzUAZi_o8_75Iqo77evXCYCfDUomfT2QVOORMxhWplxQ