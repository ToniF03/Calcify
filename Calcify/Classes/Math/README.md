**Math Conversion Utilities**

A collection of numeric and unit-conversion helpers used by the Calcify project. The code is split into small, focused files so individual units (angle, length, mass, time, temperature, data sizes, frequencies and numeral systems) can be consumed and tested independently.

**Contents**
- **Files:** `Calculator.cs`: general helper routines (e.g. date/time helpers, expression calculator helpers).
- **Files:** `Functions.cs`: common math helper functions (e.g. factorial, other utilities).
- **Files:** `Constants.cs`: shared constants used across conversions.
- **Folder:** `Conversion/`: the main conversion helpers and supporting enums.
- **Files:** inside `Conversion/`: `Converter.cs` (conversion entry points), `Enum.cs` (unit enums).
- **Folders (by unit):**
  - `Angle/` — gradian, degree, radian, milliradian, angular minute/second
  - `DataSize/` — bit/byte/kilobyte/... (byte/bit conversions)
  - `Frequency/` — hertz / kilo/mega/giga
  - `Length/` — nanometer..kilometer and imperial units (inch, feet, yard, mile)
  - `Mass/` — tons, kilograms, grams, ounces, pounds, stones, etc.
  - `Temperature/` — Celsius, Fahrenheit, Kelvin, Rankine, Reaumur
  - `Time/` — centuries, years, months, weeks, days, hours, minutes, seconds, milliseconds, micro/nanoseconds
- **Folder:** `Units/` — patterns and helpers used for unit parsing (e.g. `Patterns.cs`).

**Usage (summary)**
- The code uses small static classes for each unit type. For example, to convert from meters to feet you can call the corresponding static helper in the `Length` folder (example pattern):

```
// example (adjust namespace / class names to the project usage)
using Calcify.Math.Conversion.Length;

double feet = Meter.ToFeet(1.0); // converts 1.0 meter to feet
```

- For numeral system conversions, use the classes under `Conversion/NumeralSystem` (or the equivalent `Decimal`, `Binary`, `Hexadecimal`, `Octal` helpers).
- `Converter.cs` provides higher-level entry points (and likely enum-driven conversion) — prefer it when you need a single API to convert between arbitrary units.
- `Calculator.cs` / `Functions.cs` contain non-conversion helpers (date/time utilities, expression evaluation helpers). See the file comments for detailed API and regex usage for the expression calculator.

**Notes & Caveats**
- Many conversion methods validate their inputs and throw `ArgumentException` or return `NaN` on invalid input — check the individual method docs and handle exceptions appropriately.
- The code is organized to be easy to unit-test; consider adding tests that cover boundary values, NaN handling and common conversion pairs.
- Some methods use integer formatting or culture-sensitive parsing — prefer `CultureInfo.InvariantCulture` when formatting/parsing numbers for deterministic results.
- Review `Patterns.cs` before using any parsing features — it contains Regex patterns for unit detection.

**Recommended next steps**
- Add or update unit tests for each folder (one test class per unit folder).
- If you plan to reuse this module in other projects, add a small public facade (thin static `Converter` with a clear API) and publish/document expected enum values and method names.
- If license/attribution is required, verify project license and add a short note here.

**Contact / Maintainers**
- This module is part of the Calcify project. For questions about behavior or API changes, open an issue in the Calcify repository and reference these files.
