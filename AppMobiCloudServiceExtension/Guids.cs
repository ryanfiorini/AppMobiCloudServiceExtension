// Guids.cs
// MUST match guids.h
using System;

namespace appMobi.AppMobiCloudServiceExtension
{
    static class GuidList
    {
        public const string guidAppMobiCloudServiceExtensionPkgString = "e0e40a19-39a7-4a99-a67e-e4f9c2ff2f7c";
        public const string guidAppMobiCloudServiceExtensionCmdSetString = "60c55181-4624-4e7d-ac92-27855f0a42cc";
        public const string guidToolWindowPersistanceString = "b1425580-4313-4458-b1e3-d1ea8875a48e";

        public static readonly Guid guidAppMobiCloudServiceExtensionCmdSet = new Guid(guidAppMobiCloudServiceExtensionCmdSetString);
    };
}