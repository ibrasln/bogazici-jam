using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Entity
{
    public class EntityData : ScriptableObject
    {
        [Header("MOVEMENT")]
        public float MoveSpeed;
    }
}