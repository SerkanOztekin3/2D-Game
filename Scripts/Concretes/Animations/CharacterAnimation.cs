using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void CharacterMove(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);

            if (_animator.GetFloat("moveSpeed") == mathfValue) return;
            _animator.SetFloat("moveSpeed", mathfValue); // animasyon geçişi için 
        }

        public void CharacterJump(bool isJump)
        {
            if (isJump == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", isJump);
        }
        public void CharacterClimb(bool isClimb)
        {
            if (isClimb == _animator.GetBool("isClimb")) return;
            _animator.SetBool("isClimb", isClimb);


        }

    }
}
