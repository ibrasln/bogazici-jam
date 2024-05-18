using Bogazici.Entity;
using UnityEngine;

namespace Bogazici.Player
{
    public class PlayerData : EntityData
    {
        [Space(7)]
        [Header("JUMP PROPERTIES")]
        public float JumpPower;
    }
}
