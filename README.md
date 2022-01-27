![icon](.meta/timestamp-icon.png#gh-dark-mode-only)
![icon](.meta/timestamp-icon-alt.png#gh-light-mode-only)

# 🛠⏲ BuildTimestampGenerator
Have you wanted a way to reliably get the time your application was compiled at, but still wanted to have 'deterministic' builds enabled? Well then do I have the package for you!

This is a small Roslyn source generator that outputs a class, `BuildTimestamp`, that contains several variables that describe when the source generator was run (and thus when your project was built.)

## ❓Usage

- Reference the source generator (sometimes called 'analyzer') in your `.csproj` 
```xml
  <ItemGroup>
    <PackageReference Include="cmdwtf.BuildTimestampGenerator" Version="*" PrivateAssets="all" />
  </ItemGroup>
```
- Build once so packages are restored and source can be generated.
- Use the properties of the class `cmdwtf.BuildTimestamp` to determine your compile time!

### ❗Example

#### 📥Source

```csharp
using System;

namespace HelloTimestamp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"I was built at {cmdwtf.BuildTimestamp.BuildTime}");
        }
    }
}
```

#### 📤Output

```
I was built at 1/27/2022 12:54:21 PM
```

(Obviously, your output will vary.)

## 📝 License
cmdwtf.BuildTimestampGenerator is [licensed](./LICENSE) under the Zero-Clause BSD License (SPDX-License-Identifier: 0BSD). If you're interested in cmdwtf.BuildTimestampGenerator under other terms, please contact the authors. cmdwtf.BuildTimestampGenerator may make use of several open source packages. Those packages are each covered by their own copyrights and licenses, which are available via the tooling you use to restore the packages when building. As well, some portions of code are distributed under terms of other licenses, which are designated in comments. See `copyright` for more details.

Copyright © 2022 [Chris March Dailey](https://cmd.wtf)

Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
