using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Inputs;
using UnityEngine;


namespace UdemyProject2.Concretes.input 
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public bool IsJump => Input.GetButtonDown("Jump");
        public float Vertical => Input.GetAxis("Vertical");
    }


}