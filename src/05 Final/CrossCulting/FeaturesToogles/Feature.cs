using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using FeatureToggle.Core;

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
                throw new ToggleConfigurationError(feature);
            }

            return bool.Parse(featureValue);
        }
    }
}
