using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;

namespace CleanArch.IntegrationTests.Ioc
{

    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureMiddleware(this WebApplication app)
        {
            app.UseRouting(); 

            app.UseCors("corsPolicy"); 

            app.UseAuthorization();

            app.MapControllers();

            app.MapOpenApi();

            app.MapScalarApiReference(options =>
            {
                options
                .WithTitle("CleanArch IntegrationTests")
                .WithTheme(ScalarTheme.Default)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
            });

            app.Run();
        }

    }
}
