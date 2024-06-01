using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace BeatSaber.Core
{
    [Serializable] public class ArrowPositions : SerializableDictionaryBase<ArrowDirection, GameObject> {}
    
    [Serializable] public class ColorsMaterialsDict : SerializableDictionaryBase<CubeColor, Material> {}
    
    [Serializable] public class SpawnPoints : SerializableDictionaryBase<GridPosition, Transform> {}
}