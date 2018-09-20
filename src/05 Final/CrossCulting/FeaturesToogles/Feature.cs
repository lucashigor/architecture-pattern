using Microsoft.Extensions.Configuration;
using System;

namespace CrossCulting
{
    public class Feature : IFeature
    {
        private readonly IConfiguration _configuration;

        public Feature(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool IsFeatureEnabled(string feature)
        {
            var featureValue = _configuration[$"Features:{feature}"];
            if (string.IsNullOrWhiteSpace(featureValue))
            {
                throw new Exception(feature);
            }

            return bool.Parse(featureValue);
        }
    }
}
