using UnityEngine;

namespace BeatSaber.Core
{
    public static class Extensions
    {
        public static void TryRelease(this GameObject obj)
        {
            if (obj.TryGetComponent<IPooledObject>(out var component))
            {
                component.Release();
                return;
            }
            
            Object.Destroy(obj);
        } 
    }
}