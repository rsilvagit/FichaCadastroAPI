using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FichaCadastroAPI.DTO.Ficha;
using FichaCadastroAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FichaCadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckService healthCheckService;

        public HealthCheckController(HealthCheckService healthCheckService)
        {
           this.healthCheckService = healthCheckService;
        }

        [HttpGet(Name = "Get")]
        public async Task<ActionResult> GetAsync(CancellationToken token = default)
        {
            HealthReport report = await this.healthCheckService.CheckHealthAsync();
            return await Task.FromResult(Ok(report));
        }

    }
}
