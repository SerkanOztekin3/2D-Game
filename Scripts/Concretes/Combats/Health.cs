using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Combats;
using UnityEngine;



namespace UdemyProject2.Concretes.Combats

{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int _currentHealth = 0;

        public bool IsDead => _currentHealth < 1; //Player health değerinin 0 dan küçük olmaması lazım check bool
        public event System.Action OnHealthChanged;
        public event System.Action OnDead;
        private void Awake()
        {
            _currentHealth = maxHealth; 

        }
        public void TakeHit(Damage damage)
        {
            if (!IsDead)
            {
                
                _currentHealth -= damage.HitDamage;
                
            }
            if (IsDead)
            {
                OnDead?.Invoke();
            }

            else
            {
                OnHealthChanged?.Invoke();
            }



        }




    }
}
