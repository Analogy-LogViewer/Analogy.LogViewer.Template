using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.CommonUtilities.Web;

namespace Analogy.LogViewer.Template
{
    public static class Utils
    {
        ///  <summary>
        /// Get latest release info
        ///  </summary>
        ///  <param name="repositoryPath">url to repository (e.g: "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer")</param>
        ///  <param name="forceUpdate"></param>
        ///  <param name="lastUpdate"></param>
        ///  <returns></returns>
        public static async Task<(bool newData, GithubObjects.GithubReleaseEntry? release)> CheckVersion(string repositoryPath,string userAgent,string githubToken, bool forceUpdate,DateTime lastUpdate)
        {
            var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubObjects.GithubReleaseEntry[]>(repositoryPath + "/releases",userAgent,githubToken ,lastUpdate);
            if (entries != null)
            {
                GithubObjects.GithubReleaseEntry? release = entries.OrderByDescending(r => r.Published).FirstOrDefault();
                return (newData, release);
            }
            return (false, null);
        }
    }
}
