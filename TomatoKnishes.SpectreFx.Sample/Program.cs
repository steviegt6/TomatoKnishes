using System.Threading.Tasks;
using CliFx;

namespace TomatoKnishes.SpectreFx.Sample
{
    public static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            // IF: The program was launched with any arguments.
            if (args.Length > 0)
                return await new CliApplicationBuilder()
                    .AddCommandsFromThisAssembly()
                    .Build()
                    .RunAsync();

            // ELSE: Allow interactive usage.
            new MainWindow().WriteFullConsole();
            return 0;
        }
    }
}
