using UnityEngine;

namespace MK.Scripts
{
    public class Poison : Pickup
    {
        [SerializeField] private float damage = 1f;
        protected override void OnGetPickup(Collider other)
        {
            other.GetComponent<HealthComponent>().TakeDamage(damage);
        }
    }
}