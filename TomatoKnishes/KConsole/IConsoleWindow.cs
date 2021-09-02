#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using TomatoKnishes.KConsole.Options;

namespace TomatoKnishes.KConsole
{
    public interface IConsoleWindow<TColor>
    {
        /// <summary>
        ///     The default set of <see cref="IConsoleOption"/>s.
        /// </summary>
        IOptionCollection DefaultOptions { get; }

        /// <summary>
        ///     The selected set of <see cref="IConsoleOption"/>s.
        /// </summary>
        IOptionCollection SelectedOptions { get; set; }

        TColor SuccessColor { get; }

        TColor ErrorColor { get; }

        /// <summary>
        ///     Static message that gets refreshed upon clearing the window.
        /// </summary>
        /// <param name="appendExtraNewLine"></param>
        void WriteStaticText(bool appendExtraNewLine = true);

        void Write(object o);

        void WriteLine();

        void WriteLine(object o);

        void Clear(bool appendExtraNewLine = true);

        /// <summary>
        ///     Sets <see cref="SelectedOptions"/> to <paramref name="collection"/> and writes it to the console.
        /// </summary>
        /// <param name="collection"></param>
        void WriteOptionsList(IOptionCollection collection);

        void WriteAndClear(string message, TColor color);

        void DisplayPagedList<TItem>(int itemsPerPage, params TItem[] items) where TItem : notnull;
    }
}