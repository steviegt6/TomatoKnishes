#region License
// Copyright (C) 2021 Tomat and Contributors
// GNU General Public License Version 3, 29 June 2007
#endregion

using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using TomatoKnishes.Internals.Localization;
using TomatoKnishes.Localization;

namespace TomatoKnishes.Tests.LocalizationTests
{
    public class LocalizerTextRetrievalTest
    {
        public const string Test1English = "This is a test.";
        public const string Test2English = "This is a second test.";
        public const string Test1Spanish = "Esto es una prueba.";
        public const string Test2Spanish = "Esta es una segunda prueba.";

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
            ILocalizer localizer = new KnishesLocalizer();
            localizer.AddProvider<TestTextProvider, TestTextType>();

            Assert.AreSame(localizer.GetLocalizedTextValue(TestTextType.Test1), Test1English);
            Assert.AreSame(localizer.GetLocalizedTextValue(TestTextType.Test2), Test2English);

            CultureInfo.CurrentCulture = Spanish;

            Assert.AreSame(localizer.GetLocalizedTextValue(TestTextType.Test1), Test1Spanish);
            Assert.AreSame(localizer.GetLocalizedTextValue(TestTextType.Test2), Test2Spanish);

            Assert.Pass();
        }
    }
}