#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System.Threading.Tasks;

namespace TomatoKnishes.KConsole.Options
{
    /// <summary>
    ///     Default <see cref="IConsoleOption"/> implementation.
    /// </summary>
    public abstract class StandardConsoleOption : IConsoleOption
    {
        public int? Index { get; set; }

        public abstract string DisplayText { get; }

        public abstract Task ExecuteAsync();

        public override string ToString() => $"  [{Index + 1}] {DisplayText}";
    }
}