using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Shell.NET;

namespace ConsoleColors
{
    public static class Clr
    {
        static string _v = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        private static bool _linux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        private static bool _mac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        private static Bash _bash = new Bash();

        public static string Bold { get; } = @"$(tput bold)";
        public static string Reset { get; } = @"$(tput sgr0)";
        public static string Black { get; } = @"$(tput setaf 0)";
        public static string Red { get; } = @"$(tput setaf 1)";
        public static string Green { get; } = @"$(tput setaf 2)";
        public static string Yellow { get; } = @"$(tput setaf 3)";
        public static string Blue { get; } = @"$(tput setaf 4)";
        public static string Magenta { get; } = @"$(tput setaf 5)";
        public static string Cyan { get; } = @"$(tput setaf 6)";
        public static string White { get; } = @"$(tput setaf 7)";
        private static string[] _wheel = new string[]
        {
            Bold,
            Reset,
            Black,
            Red,
            Green,
            Yellow,
            Blue,
            Magenta,
            Cyan,
            White
        };

        public static void Write(string output)
        {
            if (_linux || _mac)
                _bash.Command($"echo -n {ParseString(output)}");
            else
                Console.Write(output);
        }

        public static void WriteLine(string output)
        {
            if (_linux || _mac)
                _bash.Command($"echo {ParseString(output)}");
            else
                Console.Write(output);
        }

        public static void SayHello()
        {
            WriteLine($"{Bold}"
                    + $"{Red}C"
                    + $"{Yellow}o"
                    + $"{Green}n"
                    + $"{Cyan}s"
                    + $"{Blue}o"
                    + $"{Magenta}l"
                    + $"{Red}e"
                    + $"{Yellow}C"
                    + $"{Green}o"
                    + $"{Cyan}l"
                    + $"{Blue}o"
                    + $"{Magenta}r"
                    + $"{Red}s"
                    + $"{White} {_v}"
                    + $"{Reset}");
        }

        private static string ParseString(string input)
        {
            var new_wheel = new List<string>();
            foreach (var clr in _wheel)
                new_wheel.Add(Regex.Escape(clr));
            var join = string.Join("|", new_wheel);
            var pattern = $"({join})";
            var split = Regex.Split(input, pattern);

            var parse = new List<string>();

            for (var i = 0; i < split.Length; i++)
            {
                var inArray = Array.IndexOf(_wheel.ToArray(), split[i]);
                
                if (inArray > -1)
                {
                    parse.Add($"{_wheel[inArray]}");
                }
                else
                {
                    parse.Add($"'{Sanitize(split[i])}'");
                }
            }

            return string.Join("", parse);
        }

        private static string Sanitize(string input)
        {
            input = input.Replace(@"'", @"'\''");
            return input;
        }
    }
}
