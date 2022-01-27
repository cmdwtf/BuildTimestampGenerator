using System;

using Microsoft.CodeAnalysis;

namespace cmdwtf.BuildTimestampGenerator
{
	[Generator]
	internal class BuildTimestamp : ISourceGenerator
	{
		public void Execute(GeneratorExecutionContext context)
		{
			DateTime executeTimeUtc = DateTime.UtcNow;
			DateTimeOffset executeTimeUtcOffset = new(executeTimeUtc);

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
		/// 12:00 midnight, January 1, 1601 C.E. UTC) from when this source was generated.
		/// </summary>
		public const long FileTime = {executeTimeUtc.ToFileTime()};

		/// <summary>
		/// The timestamp (in ticks elapsed since the beginning of the 21st century)
		/// from when this source was generated.
		/// </summary>
		public const long Ticks = {executeTimeUtc.Ticks};

		/// <summary>
		/// The time this source was generated, as a <see cref=""DateTimeKind.Utc""/> <see cref=""DateTime""/>.
		/// </summary>
		public static DateTime BuildTimeUtc {{ get; }} = DateTime.FromFileTimeUtc(FileTime);

		/// <summary>
		/// The time this source was generated, as a <see cref=""DateTimeOffset""/>.
		/// </summary>
		public static DateTimeOffset BuildTimeDto {{ get; }} = new DateTimeOffset(BuildTimeUtc);

		/// <summary>
		/// The time this source was generated, as a <see cref=""DateTimeKind.Local""/> <see cref=""DateTime""/>.
		/// </summary>
		public static DateTime BuildTime {{ get; }} = BuildTimeDto.LocalDateTime;

		/// <summary>
		/// The time this source was generated as a Unix timestamp in UTC.
		/// </summary>
		public const long UnixTimeUtc = {executeTimeUtcOffset.ToUnixTimeSeconds()};

		/// <summary>
		/// The time this source was generated as a Unix timestamp in local time.
		/// </summary>
		public static long UnixTime {{ get; }} = BuildTimeDto.ToUnixTimeSeconds();

		/// <summary>
		/// The time this source was generated as a Unix millisecond timestamp in UTC.
		/// </summary>
		public const long UnixTimeMillisecondsUtc = {executeTimeUtcOffset.ToUnixTimeMilliseconds()};

		/// <summary>
		/// The time this source was generated as a Unix millisecond timestamp in local time.
		/// </summary>
		public static long UnixTimeMilliseconds {{ get; }} = BuildTimeDto.ToUnixTimeMilliseconds();
	}}
}}
";

			context.AddSource($"{nameof(BuildTimestamp)}.g.cs", source);
		}

		public void Initialize(GeneratorInitializationContext context) { }
	}
}
