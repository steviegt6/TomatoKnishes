#region License
// Copyright (C) 2021 Tomat and Contributors
// GNU General Public License Version 3, 29 June 2007
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