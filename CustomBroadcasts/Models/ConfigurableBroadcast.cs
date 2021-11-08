// -----------------------------------------------------------------------
// <copyright file="ConfigurableBroadcast.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomBroadcasts.Models
{
    using Exiled.API.Features;

    /// <summary>
    /// Represents a broadcast to be configured by a user.
    /// </summary>
    public class ConfigurableBroadcast
    {
        /// <summary>
        /// Gets or sets the recognizable name of the broadcast.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the delay from the original event firing.
        /// </summary>
        public float Delay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether broadcasts should be cleared before displaying this broadcast.
        /// </summary>
        public bool OverrideBroadcast { get; set; }

        /// <summary>
        /// Gets or sets the broadcast to use.
        /// </summary>
        public Broadcast Broadcast { get; set; }
    }
}