#region Usages

using System;
using System.IO;
using System.Reflection;
using NUnitReporter.Reporting;

#endregion

namespace AskFm.Utils
{
    class Utilities
    {
        private static bool? _runWithoutAddin;
        /// <summary>
        /// Determine does NUnit launch test class with connected NUnitReporter plug-in
        /// </summary>
        public static bool RunWithoutAddin
        {
            get
            {
                if (_runWithoutAddin == null)
                {
                    _runWithoutAddin = (Reporter.Reporters.Count == 0);
                }
                return (bool) _runWithoutAddin;
            }

        }

        static public string GetProjectDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }


    }
}
