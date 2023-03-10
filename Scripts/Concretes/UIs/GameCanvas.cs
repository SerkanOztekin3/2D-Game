using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Managers;
using UnityEngine;

namespace UdemyProject2.Uİs
{

    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gamePlayObject;
        [SerializeField] GameOverPanel gameOverPanel;
        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }



        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }

        private void HandleSceneChanged(bool isActive)
        {
            if (isActive == gamePlayObject.activeSelf) return;

            gamePlayObject.SetActive(isActive);
        }
        public void ShowGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}
