using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;

namespace Web
{
    /// <summary>
    /// A rewrite rule to allow for deeplinking
    /// </summary>
    /// <remarks>
    /// This is a very naïve implementation and assumes there aren't any specific routes.
    /// Bifrost will have a more clever implementation of this - which will make this go away
    /// </remarks>
    public class SinglePageApplicationRule : IRule
    {
        IHostingEnvironment _env;

        public SinglePageApplicationRule(IHostingEnvironment env)
        {
            _env = env;
        }

        public void ApplyRule(RewriteContext context)
        {
            var path = context.HttpContext.Request.Path.Value;
            if (path.StartsWith("/")) path = path.Substring(1);
            var fullPath = Path.Combine(_env.WebRootPath, path);
            var exists = File.Exists(fullPath);
            if (!exists && !path.StartsWith("Bifrost")) context.HttpContext.Request.Path = "/";
        }
    }
}