using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Concretes.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {

        [SerializeField] float jumpAmount = 350f;
        bool _isJump;
        Rigidbody2D rb;
        public bool isJumpAction => rb.velocity != Vector2.zero;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void JumpAction()
        {
            rb.AddForce(Vector2.up * jumpAmount);
        }
    }
}
