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
        ///  <param name="userAgent"></param>
        ///  <param name="optionalGithubToken"></param>
        ///  <param name="lastUpdate"></param>
        ///  <returns></returns>
        public static async Task<(bool newData, GithubObjects.GithubReleaseEntry? release)> CheckVersion(string repositoryPath,string userAgent,string optionalGithubToken, DateTime lastUpdate)
        {
            var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubObjects.GithubReleaseEntry[]>(repositoryPath + "/releases",userAgent, optionalGithubToken, lastUpdate);
            if (entries != null)
            {
                GithubObjects.GithubReleaseEntry? release = entries.OrderByDescending(r => r.Published).FirstOrDefault();
                return (newData, release);
            }
            return (false, null);
        }

        ///  <summary>
        /// Get latest release info
        ///  </summary>
        ///  <param name="repositoryPath">url to repository (e.g: "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer")</param>
        ///  <param name="userAgent"></param>
        ///  <param name="optionalGithubToken"></param>
        ///  <returns></returns>
        public static async Task<(bool newData, GithubObjects.GithubReleaseEntry[] release)> GetAllReleases(string repositoryPath, string userAgent, string optionalGithubToken)
        {
            try
            {
                var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubObjects.GithubReleaseEntry[]>(repositoryPath + "/releases", userAgent, optionalGithubToken, DateTime.MinValue);
                return (newData, entries);
            }
            catch (Exception)
            {
                return (false, new GithubObjects.GithubReleaseEntry[0]);
            }
       
        }
    }
}
