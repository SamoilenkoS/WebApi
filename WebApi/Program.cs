// <copyright file="Program.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace WebApi
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Main class of program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Command line args</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creating of web host builder
        /// </summary>
        /// <param name="args">Command line args</param>
        /// <returns>IWebHostBuilder instance</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
