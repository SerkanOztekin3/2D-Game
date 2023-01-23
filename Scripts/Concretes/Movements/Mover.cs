using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Concretes.Movements
{
    public class Mover : MonoBehaviour
    {

        [SerializeField] float speed = 5f;
        public void HorizontalMove(float horizontal)
        {
            transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        }
    }
}

