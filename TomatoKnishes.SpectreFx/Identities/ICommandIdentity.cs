// Copyright (C) 2021 Tomat and Contributors, MIT License

namespace TomatoKnishes.SpectreFx.Identities
{
    public interface ICommandIdentity
    {
        string CommandName { get; }

        string CommandDescription { get; }
    }
}