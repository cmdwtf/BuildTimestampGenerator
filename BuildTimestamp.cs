using System;

using Microsoft.CodeAnalysis;

namespace cmdwtf.BuildTimestampGenerator
{
	[Generator]
	internal class BuildTimestamp : ISourceGenerator
	{
		public void Execute(GeneratorExecutionContext context)
		{

			DateTime executeTime = DateTime.UtcNow;

			string source = $@"// Auto-generated code
using System;

namespace {nameof(cmdwtf)}
{{
	internal static partial class {nameof(BuildTimestamp)}
	{{
		public const long FileTime = {executeTime.ToFileTime()};
		public const long Ticks = {executeTime.Ticks};
		public static DateTime BuildTimeUtc {{ get; }} = DateTime.FromFileTimeUtc(FileTime);
		public static DateTimeOffset BuildTime {{ get; }} = new DateTimeOffset(BuildTime);
		public static long UnixTime {{ get; }} = BuildTime.ToUnixTimeSeconds();
		public static long UnixTimeUtc {{ get; }} = BuildTime.Now.ToUniversalTime().ToUnixTimeSeconds();
		public static long UnixTimeMilliseconds {{ get; }} = BuildTime.ToUnixTimeMilliseconds();
		public static long UnixTimeMillisecondsUtc {{ get; }} = BuildTime.Now.ToUniversalTime().ToUnixTimeMilliseconds();
	}}
}}
";

			context.AddSource($"{nameof(BuildTimestamp)}.g.cs", source);
		}

		public void Initialize(GeneratorInitializationContext context) { }
	}
}
