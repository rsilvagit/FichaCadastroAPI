using FichaCadastroAPI.Model;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FichaCadastroAPI.HealthCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        private readonly FichaCadastroContextDB fichaCadastroContextDB;
        private readonly IWebHostEnvironment hostEnvironment;

        public HealthCheckCustom(FichaCadastroContextDB fichaCadastroContextDB, IWebHostEnvironment hostEnvironment)
        {
            this.fichaCadastroContextDB = fichaCadastroContextDB;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(HealthCheckResult.Healthy("ok"));
        }
    }
}
