# Console Colors [![License][License]](LICENSE.md) [![Nuget][Nuget]](https://www.nuget.org/packages/ConsoleColors)

[License]: https://img.shields.io/badge/License-MIT-blue.svg

[Nuget]: https://img.shields.io/badge/Nuget-0.1.4--alpha-blue.svg

Disclaimer: This library only works on Linux & MacOS currently. Alpha builds are subject to change.

<img src="http://i.imgur.com/yoHOxQb.png" width="40%" height="40%">

## Usage

Use string formatting/interpolation while calling `Printer.Write()` or `Printer.WriteLine()` to print with colors! Color properties are stored in the `Clr` class , formatting properties are in the `Frmt` class, and background color properties are in the `Bkgrd` class. To reset all color/formatting changes, use the `Reset.Code` property or call the `Reset.All()` class method.

[Get this library off of Nuget!](https://www.nuget.org/packages/ConsoleColors)

## Examples

```C#
Printer.SayHello();
Clr.SetCyan();
Printer.WriteLine($"This library uses {Frmt.Bold}Shell.NET!");
Reset.All();
Printer.WriteLine(string.Format("{0}{4}C#{5} in {2}{4}Linux{5} is pretty {3}{4}cool!{5}",
    Clr.Magenta,
    Clr.White,
    Clr.Green,
    Clr.Yellow,
    Frmt.Bold,
    Reset.Code
));
```

Note: Remember to use Reset.All() to return back to default colors.

## Color Properties

* Clr.Default
* Clr.Black
* Clr.White
* Clr.Red
* Clr.Green
* Clr.Yellow
* Clr.Blue
* Clr.Magenta
* Clr.Cyan
* Clr.LtGray
* Clr.DrkGray
* Clr.LtRed
* Clr.LtGreen
* Clr.LtYellow
* Clr.LtBlue
* Clr.LtMagenta
* Clr.LtCyan

Note: All color properties have a corresponding class method. Examples:

* Clr.SetBlue()
* Clr.SetDefault()

## Formatting Properties

* Frmt.Bold
* Frmt.Dim
* Frmt.Underline
* Frmt.Invert
* Frmt.Hidden
* Frmt.UnBold
* Frmt.UnDim
* Frmt.UnUnderline
* Frmt.UnInvert
* Frmt.UnHidden

Note: All formatting properties have corresponding activation *and* deactivation class methods. Examples:

* Frmt.SetDim()
* Frmt.ResetDim()
* Frmt.Underline()
* Frmt.ResetAll()

## Reset Utility

* Reset.Code
* Reset.All()

## Background Color Properties

Same colors as the Clr class; contained in the Bkgrd class. Examples:

* Bkgrd.LtGray
* Bkgrd.White
* Bkgrd.SetBlue()
* Bkgrd.SetDefault()
