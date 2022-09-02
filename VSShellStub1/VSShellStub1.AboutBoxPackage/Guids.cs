// Guids.cs
// MUST match guids.h
using System;

namespace VSShellStub1.AboutBoxPackage
{
    static class GuidList
    {
        public const string guidAboutBoxPackagePkgString = "0d455be0-077c-4089-be08-70eac7809aae";
        public const string guidAboutBoxPackageCmdSetString = "553a99cd-24f7-44f9-b737-be07c52c7ff1";

        public static readonly Guid guidAboutBoxPackageCmdSet = new Guid(guidAboutBoxPackageCmdSetString);
    };
}