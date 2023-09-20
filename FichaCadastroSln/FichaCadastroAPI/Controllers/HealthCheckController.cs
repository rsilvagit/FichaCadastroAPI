﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FichaCadastroAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class HealthCheckController:ControllerBase
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
