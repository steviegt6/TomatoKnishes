#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System;
using System.Collections.Generic;

namespace TomatoKnishes.KConsole.Options
{
    public interface IOptionCollection : ICloneable, IList<IConsoleOption>
    {
        /// <summary>
        ///     Prompt text displayed to the user.
        /// </summary>
        string PromptText { get; }

        /// <summary>
        ///     Whether to display an option to return to the base window.
        /// </summary>
        bool DisplayReturn { get; }

        /// <summary>
        ///     Whether to display an option to return to the previous collection state.
        /// </summary>
        bool DisplayGoBack { get; }

        /// <summary>
        ///     The previous collection state, which can be returned to it <see cref="DisplayGoBack"/> is true.
        /// </summary>
        IOptionCollection? PreviousCollectionState { get; }

        /// <summary>
        ///     List options to the console window.
        /// </summary>
        /// <param name="window">The window instance.</param>
        void ListOptions<TColor>(IConsoleWindow<TColor> window);
    }
}