﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckRoad.Core.Domain
{
    public enum ProfileStatus
    {
        Active,Abandoned,Deactivated,Locked,Banned,ReviewNeccessary
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }
        public Guid ApplicationUserID { get; set; } // 1-1
        public string ScreenName { get; set; }
        public int Credits { get; set; }
        public int ScrapParts { get; set; }
        public List<CarOwnership> MyCars { get; set; }
        public int Victories { get; set; }
        public int MyProperty { get; set; }
        public string? MyRoads { get; set; } //do not use this property yet, this needs to become a solarsystem object attached to the player, this is not a system the admin makes, in the future, it will be part of feature for creating users own solar system
        public ProfileStatus CurrentStatus { get; set; }

        public bool ProfileType { get; set; } //true, admin, false, player

        //dbonly
        public DateTime ProfileCreatedAt { get; set; }
        public DateTime ProfileModifiedAt { get; set; }
        public DateTime ProfileAttributedToAnAccountUserAt { get; set; }
        public DateTime ProfileStatusLastChangedAt { get; set; }

    }
}
