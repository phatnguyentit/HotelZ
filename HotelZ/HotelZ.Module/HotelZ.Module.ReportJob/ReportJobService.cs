using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelZ.Module.ReportJob
{
    public class ReportJobService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(ReportJobService)} is started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(ReportJobService)} is finished");
            return Task.CompletedTask;
        }
    }
}
