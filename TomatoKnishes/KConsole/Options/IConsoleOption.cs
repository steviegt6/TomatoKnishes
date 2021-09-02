#region License
// Copyright (C) 2021 Tomat and Contributors, MIT License
#endregion

using System.Threading.Tasks;

namespace TomatoKnishes.KConsole.Options
{
    /// <summary>
    ///     Console option framework.
    /// </summary>
    public interface IConsoleOption
    {
        /// <summary>
        ///     Nullable. The option's position in a <see cref="IOptionCollection"/>.
        /// </summary>
        int? Index { get; set; }

        /// <summary>
        ///     Text to display as the option's name.
        /// </summary>
        string DisplayText { get; }

        /// <summary>
        ///     Awaitable command execution.
        /// </summary>
        Task ExecuteAsync();
    }
}