#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using TomatoKnishes.Internals;
using TomatoKnishes.Internals.Localization;
using TomatoKnishes.Localization;

namespace TomatoKnishes.Tests.LocalizationTests
{
    public class LocalizerTextRetrievalTest
    {
        public const string Test1English = "This is a test.";
        public const string Test2English = "This is a second test.";
        public const string Test1Spanish = "Esto es una prueba.";
        public const string Test2Spanish = "Esto es una segunda prueba.";

        public static readonly CultureInfo Spanish = new("es");

        public enum TestTextType
        {
            Test1,
            Test2
        }

        public class TestTextProvider : StandardLocalizationProvider<TestTextType>
        {
            public override IDictionary<TestTextType, ILocalizedTextEntry> TextEntries { get; } =
                new Dictionary<TestTextType, ILocalizedTextEntry>
                {
                    {
                        TestTextType.Test1,
                        new StandardLocalizedTextEntry((LocalizationConstants.English, Test1English),
                            (Spanish, Test1Spanish))
                    },
                    {
                        TestTextType.Test2,
                        new StandardLocalizedTextEntry((LocalizationConstants.English, Test2English),
                            (Spanish, Test2Spanish))
                    }
                };
        }

        [Test]
        public void TextRetrievalTest()
        {
            ILocalizer localizer = Knishes.Localizer;
            localizer.AddProvider<TestTextProvider, TestTextType>();

            static void LogAssertAreSame(object obj1, object obj2)
            {
                Assert.AreSame(obj1, obj2);
                Console.WriteLine($"Objects are same: {obj1}, {obj2}");
            }

            LogAssertAreSame(localizer.GetLocalizedText(TestTextType.Test1), Test1English);
            LogAssertAreSame(localizer.GetLocalizedText(TestTextType.Test2), Test2English);
            LogAssertAreSame(localizer.GetLocalizedTextEntry(TestTextType.Test1).GetText(LocalizationConstants.Default), Test1English);
            LogAssertAreSame(localizer.GetLocalizedTextEntry(TestTextType.Test2).GetText(LocalizationConstants.Default), Test2English);

            CultureInfo.CurrentCulture = Spanish;

            LogAssertAreSame(localizer.GetLocalizedText(TestTextType.Test1), Test1Spanish);
            LogAssertAreSame(localizer.GetLocalizedText(TestTextType.Test2), Test2Spanish);
            LogAssertAreSame(localizer.GetLocalizedTextEntry(TestTextType.Test1).GetText(LocalizationConstants.Default), Test1Spanish);
            LogAssertAreSame(localizer.GetLocalizedTextEntry(TestTextType.Test2).GetText(LocalizationConstants.Default), Test2Spanish);

            Assert.Pass();
        }

        [Test]
        public void TextPrintingTest()
        {
            ILocalizer localizer = Knishes.Localizer;
            localizer.AddProvider<TestTextProvider, TestTextType>();
            ILocalizationProvider<TestTextType> provider = localizer.GetProvider<TestTextProvider, TestTextType>();

            Console.WriteLine(provider.ToCollectedString());
        }
    }
}
