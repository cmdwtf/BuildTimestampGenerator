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

	/// <summary>
	/// A static class representing when it was generated.
	/// </summary>
	internal static class {nameof(BuildTimestamp)}
	{{
		/// <summary>
		/// The timestamp (in Windows FILETIME, the number of 100ns intervals since
		/// 12:00 midnight, January 1, 1601 C.E UTC) from when this source was generated.
		/// </summary>
		public const long FileTime = {executeTime.ToFileTime()};


		/// <summary>
		/// The timestamp (in ticks elapsed since the beginning of the 21st century)
		/// from when this source was generated.
		/// </summary>
		public const long Ticks = {executeTime.Ticks};

		/// <summary>
		/// The time this source was generated, as a <see cref=""DateTimeKind.Utc""/> <see cref=""DateTime""/>.
		/// </summary>
		public static DateTime BuildTimeUtc {{ get; }} = DateTime.FromFileTimeUtc(FileTime);

		/// <summary>
		/// The time this source was generated, as a <see cref=""DateTimeOffset""/>.
		/// </summary>
		public static DateTimeOffset BuildTime {{ get; }} = new DateTimeOffset(BuildTimeUtc);

		/// <summary>
		/// The time this source was generated as a Unix timestamp in local time.
		/// </summary>
		public static long UnixTime {{ get; }} = BuildTime.ToUnixTimeSeconds();

		/// <summary>
		/// The time this source was generated as a Unix timestamp in UTC.
		/// </summary>
		public static long UnixTimeUtc {{ get; }} = BuildTime.ToUniversalTime().ToUnixTimeSeconds();

		/// <summary>
		/// The time this source was generated as a Unix millisecond timestamp in local time.
		/// </summary>
		public static long UnixTimeMilliseconds {{ get; }} = BuildTime.ToUnixTimeMilliseconds();

		/// <summary>
		/// The time this source was generated as a Unix millisecond timestamp in UTC.
		/// </summary>
		public static long UnixTimeMillisecondsUtc {{ get; }} = BuildTime.ToUniversalTime().ToUnixTimeMilliseconds();
	}}
}}
";

			context.AddSource($"{nameof(BuildTimestamp)}.g.cs", source);
		}

		public void Initialize(GeneratorInitializationContext context) { }
	}
}
