#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System.Globalization;

namespace TomatoKnishes.Localization
{
    /// <summary>
    ///     Constant, readonly, and get-only localization-oriented fields.
    /// </summary>
    public static class LocalizationConstants
    {
        public static CultureInfo English => new("en-US");

        public static CultureInfo Default => English;
    }
}