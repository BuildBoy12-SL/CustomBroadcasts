// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomBroadcasts
{
    using System.Collections.Generic;
    using CustomBroadcasts.Enums;
    using CustomBroadcasts.Models;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether debug messages should be shown.
        /// </summary>
        public bool ShowDebug { get; set; } = false;

        /// <summary>
        /// Gets or sets a collection of all broadcasts to use.
        /// </summary>
        public Dictionary<EventType, ConfigurableBroadcast[]> Broadcasts { get; set; } = new Dictionary<EventType, ConfigurableBroadcast[]>
        {
            [EventType.RoundStarted] = new[]
            {
                new ConfigurableBroadcast
                {
                    Name = "Rules",
                    Delay = 0,
                    Content = "Please read our rules!",
                    Duration = 5,
                },
                new ConfigurableBroadcast
                {
                    Name = "Eggs",
                    Delay = 5,
                    Content = "Hello, {Name}",
                    Duration = 10,
                },
            },
        };
    }
}