using System.Reflection;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Shared.PlatformSupport;

namespace Avalonia
{
    /// <summary>
    /// Initializes platform-specific services for an <see cref="Application"/>.
    /// </summary>
    public sealed class AppBuilder : AppBuilderBase<AppBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppBuilder"/> class.
        /// </summary>
        public AppBuilder()
            : base(new StandardRuntimePlatform(),
                  builder => StandardRuntimePlatformServices.Register(builder.Instance?.GetType()
                      ?.GetTypeInfo().Assembly))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppBuilder"/> class.
        /// </summary>
        /// <param name="app">The <see cref="Application"/> instance.</param>
        public AppBuilder(Application app) : this()
        {
            Instance = app;
        }

        /// <summary>
        /// Instructs the <see cref="AppBuilder"/> to use the best settings for the platform.
        /// </summary>
        /// <returns>An <see cref="AppBuilder"/> instance.</returns>
        public AppBuilder UsePlatformDetect()
        {
            this.UseGtk3();
            this.UseSkia();

            return this;
        }
    }
}
