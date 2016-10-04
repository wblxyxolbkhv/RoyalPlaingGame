using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPlayingGame
{
    public class PlayerMenu
    {
        public PlayerMenu(Player player)
        {
            this.player = player;
        }
        Player player;

        public uint Health { get; set; }
        public uint Strength { get; protected set; }
        public uint Agility { get; protected set; }
        public uint Intelligence { get; protected set; }
        
        public void RefreshPLayerMenuStats()
        {
            this.Health = player.RealHealth;
            this.Agility = player.RealAgility;
            this.Strength = player.RealStrength;
            this.Intelligence = player.RealIntelligence;
        }
    }
}
