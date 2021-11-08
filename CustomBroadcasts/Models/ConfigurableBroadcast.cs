// -----------------------------------------------------------------------
// <copyright file="ConfigurableBroadcast.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomBroadcasts.Models
{
    using System.ComponentModel;
    using CustomBroadcasts.Enums;

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
        /// Gets or sets a value indicating whether the broadcast is enabled.
        /// </summary>
        [Description("Indicates whether the broadcast is enabled.")]
        public bool Show { get; set; }

        /// <summary>
        /// Gets or sets the delay from the original event firing.
        /// </summary>
        [Description("The delay from the original event firing.")]
        public float Delay { get; set; }

        /// <summary>
        /// Gets or sets the content of the broadcast.
        /// </summary>
        [Description("The content of the broadcast.")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the duration of the broadcast.
        /// </summary>
        [Description("The duration of the broadcast.")]
        public ushort Duration { get; set; }

        /// <summary>
        /// Gets or sets the way the message should be showed. Available: Broadcast, Hint.
        /// </summary>
        [Description("The way the message should be showed. Available: Broadcast, Hint.")]
        public DisplayType DisplayType { get; set; } = DisplayType.Broadcast;

        /// <summary>
        /// Gets or sets a value indicating whether broadcasts should be cleared before displaying this.
        /// </summary>
        [Description("Indicates whether broadcasts should be cleared before displaying this.")]
        public bool OverrideBroadcast { get; set; }
    }
}