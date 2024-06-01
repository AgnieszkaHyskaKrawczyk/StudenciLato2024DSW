using System;
using UnityEngine;

namespace MK.Scripts
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        public event Action<float> onHealthChanged; 
        
        private float _currentHealth;

        public void TakeDamage(float damage)
        {
            //TODO: zdrowie może spaść poniżej 0
            _currentHealth -= damage;
            onHealthChanged?.Invoke(_currentHealth);
            //TODO: jak mam mniej niż 0 to powinienem umrzeć
        }

        public void RestoreHealth(float value)
        {
            //TODO: zdrowie może być większe niż max
            _currentHealth += value;
            onHealthChanged?.Invoke(_currentHealth);
        }

        public float GetHealth()
        {
            return _currentHealth;
        }
    }
}