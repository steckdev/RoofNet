using System.Text;
using RoofTool.Domain.Entities;

namespace RoofTool.Application.Services
{
    public class ReportGenerator
    {
        public string GenerateCsvReport(IEnumerable<Measurement> measurements)
        {
            var csv = new StringBuilder();
            csv.AppendLine("PropertyId,Area,Slope");

            foreach (var measurement in measurements)
            {
                csv.AppendLine($"{measurement.PropertyId},{measurement.Area},{measurement.Slope}");
            }

            return csv.ToString();
        }
    }
}