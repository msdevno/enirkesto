using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;

namespace Web
{
    public static class SinglePageApplicationApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSinglePageApplication(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRewriter(new RewriteOptions()
                .Add(new SinglePageApplicationRule(env))
            );
            return app;
        }
    }
}