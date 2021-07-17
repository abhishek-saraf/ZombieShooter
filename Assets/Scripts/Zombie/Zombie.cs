using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.abhishek.saraf.ZombieSurvival
{
    public class Zombie : MonoBehaviour
    {
        private int _health = 100;

        [SerializeField] private Slider _healthSlider;

        // Update is called once per frame
        void Update()
        {
            UpdateHealth();

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void UpdateHealth()
        {
            _healthSlider.value = _health;
        }

        public void TakeDamage(int damagePoints)
        {
            _health -= damagePoints;
        }
    }
}
