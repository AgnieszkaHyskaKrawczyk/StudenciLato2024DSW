using UnityEngine;

namespace BeatSaber.Core
{
    public static class Extensions
    {
        public static void TryRelease(this GameObject obj, CubeColor color)
        {
            if (obj.TryGetComponent<IPooledObject>(out var component))
            {
                component.Release(color);
                return;
            }
            
            Object.Destroy(obj);
        } 
    }
}