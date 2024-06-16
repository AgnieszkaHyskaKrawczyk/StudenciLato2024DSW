using System;
using BeatSaber.Core;
using UnityEngine;

namespace BeatSaber.Gameloop
{
    public class Destroyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent<SliceableCube>(out var cube))
                cube.Release(CubeColor.None);
        }
    }
}