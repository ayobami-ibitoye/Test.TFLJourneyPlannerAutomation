using System;
using NUnit.Framework;

namespace Test.TFLJourneyPlannerAutomation
{
    public static class EnvironmentData
    {
        public static string baseUrl { get; } = TestContext.Parameters["baseUrl"];
    }
}
