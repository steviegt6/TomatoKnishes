﻿using System;
using System.Threading.Tasks;
using TomatoKnishes.KConsole;
using TomatoKnishes.KConsole.Options;

namespace TomatoKnishes.Tests.Console
{
    public static class Program
    {
        public sealed class TestFallbackCollection : StandardOptionCollection
        {
            public TestFallbackCollection() : base("Test fallback...", null, new PrintOption("Print", "Printed."))
            {
                DisplayReturn = true;
            }
        }

        public sealed class TestConsole : StandardConsoleWindow
        {
            public override IOptionCollection DefaultOptions { get; } = new StandardOptionCollection("Test prompt!",
                new TestFallbackCollection(), new PrintOption("Option 1", "Test 1"),
                new PrintOption("Option 2", "Test 2"))
            {
                DisplayGoBack = true
            };

            public override void WriteStaticText(bool appendExtraNewLine = true) => WriteLine("Static");
        }

        public sealed class PrintOption : StandardConsoleOption
        {
            public override string DisplayText { get; }

            public string Text { get; }

            public PrintOption(string display, string text)
            {
                DisplayText = display;
                Text = text;
            }

            public override Task ExecuteAsync()
            {
                Console.WriteLine(Text);
                return Task.CompletedTask;
            }
        }

        public static IConsoleWindow<ConsoleColor> Console { get; private set; }

        public static void Main(string[] args)
        {
            Console = new TestConsole();
            Console.Clear();
            Console.WriteOptionsList(Console.SelectedOptions);
        }
    }
}