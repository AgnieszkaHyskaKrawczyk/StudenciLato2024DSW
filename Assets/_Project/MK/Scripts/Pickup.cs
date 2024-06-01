using System;
using UnityEngine;

namespace MK.Scripts
{
    public abstract class Pickup : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                OnGetPickup(other);
                Destroy(gameObject);
            }
        }

        protected abstract void OnGetPickup(Collider other);
    }
}