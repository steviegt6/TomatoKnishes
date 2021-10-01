// Copyright (C) 2021 Tomat and Contributors, MIT License

using CliFx.Attributes;
using TomatoKnishes.SpectreFx.Localization;

namespace TomatoKnishes.SpectreFx.Commands
{
    [Command]
    public class GoBackCommand : DummyCommand
    {
        public override string CommandName => SpectreFxLocalization.Get(SpectreFxType.GoBackCommand);

        public override string CommandDescription => SpectreFxLocalization.Get(SpectreFxType.GoBackDescription);
    }
}