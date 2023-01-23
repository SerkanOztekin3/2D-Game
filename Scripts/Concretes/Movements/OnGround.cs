
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Concretes.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] Transform[] translates;
        [SerializeField] float maxDistance = 0.15f;
        [SerializeField] bool isOnGround = false;
        [SerializeField] LayerMask layerMask;

        public bool IsOnGround => isOnGround;


        private void Update()
        {
            foreach (Transform footTransfrom in translates)
            {
                CheckFootOnGround(footTransfrom);  //verdiğimiz foot1-2-3 ler OnGround olup olmadığını kontrol eder 
                                                   //Footları component dizilimindeki gibi tek tek kontrol edecek

                if (isOnGround) break;
            }
        }

        private void CheckFootOnGround(Transform footTransfrom)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransfrom.position,footTransfrom.forward,maxDistance,layerMask);
            Debug.DrawRay(footTransfrom.position, footTransfrom.forward * maxDistance, Color.red);  
          
        if(hit.collider != null)
            {
                isOnGround = true;
            }
            else { isOnGround = false;
            }

           
        }


    }
}
