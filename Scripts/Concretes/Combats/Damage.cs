using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Concretes.Combats;
using UnityEngine;

namespace UdemyProject2.Combats
{


    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage;  //Playerıa Deadzon tarafından verilecek hasar 

        public int HitDamage => damage; 


        public void HitTarget(Health health)
        {
            health.TakeHit(this);

        }

    }
}
