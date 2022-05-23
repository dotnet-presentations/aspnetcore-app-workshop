using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FrontEnd.HealthChecks
{
    public class BackendHealthCheck : IHealthCheck
    {
        private readonly IApiClient _client;

        public BackendHealthCheck(IApiClient client)
        {
            _client = client;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (await _client.CheckHealthAsync())
            {
                return HealthCheckResult.Healthy();
            }

            return HealthCheckResult.Unhealthy();
        }
    }
}
