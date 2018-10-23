using System.Collections.Generic;

namespace Integration.DeveloperPortal.Logic.Enums
{
    public static class ValueCollections
    {
        public static readonly IEnumerable<string> ContentType = new List<string> {
            "text/xml",
            "application/json"
        };
    }
}
