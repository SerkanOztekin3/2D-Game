using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;


namespace UdemyProject2.Uİs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.LoadScene();
        }
         public void NoButtonClick()
        {
            GameManager.Instance.LoadMenuAndUi(5f);
        }
    }
}
