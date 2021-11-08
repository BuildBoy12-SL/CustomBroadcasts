// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomBroadcasts
{
    using System;
    using System.Collections.Generic;
    using CustomBroadcasts.Enums;
    using CustomBroadcasts.Models;
    using Exiled.API.Features;
    using MEC;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private readonly List<CoroutineHandle> coroutines = new List<CoroutineHandle>();
        private EventHandlers eventHandlers;

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc />
        public override string Author { get; } = "Build";

        /// <inheritdoc />
        public override string Name { get; } = "CustomBroadcasts";

        /// <inheritdoc />
        public override string Prefix { get; } = "CustomBroadcasts";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(3, 6, 2);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandlers(this);
            eventHandlers.Subscribe();
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            eventHandlers.Unsubscribe();
            eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }

        /// <summary>
        /// Fires a broadcast event.
        /// </summary>
        /// <param name="eventType">The event to fire.</param>
        public void FireBroadcasts(Event eventType)
        {
            if (!Config.Broadcasts.TryGetValue(eventType, out ConfigurableBroadcast[] broadcasts))
                return;

            foreach (ConfigurableBroadcast broadcast in broadcasts)
            {
                if (!broadcast.Show)
                    continue;

                coroutines.Add(Timing.CallDelayed(broadcast.Delay, () =>
                {
                    Log.Debug($"Firing broadcast \"{broadcast.Name}\".", Config.ShowDebug);
                    foreach (Player player in Player.List)
                    {
                        if (broadcast.DisplayType == DisplayType.Hint)
                        {
                            player.ShowHint(broadcast.Content.Replace("{Name}", player.Nickname), broadcast.Duration);
                            continue;
                        }

                        player.Broadcast(broadcast.Duration, broadcast.Content.Replace("{Name}", player.Nickname), global::Broadcast.BroadcastFlags.Normal, broadcast.OverrideBroadcast);
                    }
                }));
            }
        }
    }
}
