﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;

namespace MicroVaporate
{
    internal sealed class EventHandlers
    {
        public void OnDying(DyingEventArgs ev)
        {
            foreach(var damageType in Plugin.Instance.Config.KillDamageTypes)
            {
                if (ev.DamageHandler.Type == damageType && ev.DamageHandler.Type != DamageType.ParticleDisruptor)
                {
                    ev.IsAllowed = false;
                    ev.Player.Vaporize();
                }
            }
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            foreach (var damageType in Plugin.Instance.Config.DamageTypes)
            {
                if (ev.DamageHandler.Type == damageType)
                {
                    ev.IsAllowed = false;
                    ev.Player.Vaporize();
                }
            }
        }
    }
}
