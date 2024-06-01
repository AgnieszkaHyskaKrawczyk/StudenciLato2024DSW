using UnityEngine;

namespace MK.Scripts
{
    public class HealthPickup : Pickup
    {
        [SerializeField] private float restoreValue;
        
        protected override void OnGetPickup(Collider other)
        {
            other.GetComponent<HealthComponent>().RestoreHealth(restoreValue);
        }
    }
}