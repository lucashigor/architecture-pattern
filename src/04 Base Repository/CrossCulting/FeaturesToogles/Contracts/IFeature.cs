using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCulting
{
    public interface IFeature
    {
        bool IsFeatureEnabled(string feature);
    }
}
