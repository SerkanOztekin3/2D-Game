using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject2.Managers
{
    public class GameManager : MonoBehaviour
    {
        
        public static GameManager Instance { get; private set; } // set privateledik dışarıdan erişilemesin diye
        public event System.Action<bool> OnSceneChanged;
        private void Awake()
        {
            SigletonThisGameObject();
             }

        private void SigletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        [SerializeField] float delayLevelTime = 1f;
        public void LoadScene(int levelIndex = 0)
        {

            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            yield return SceneManager.UnloadSceneAsync(buildIndex);
            

            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {


                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));


            };
            OnSceneChanged?.Invoke(false);
         }

        public void ExitGame()
        {

            Debug.Log("EXİT GAME METHOD TRİGGERED");
            Application.Quit();

        }



       public void LoadMenuAndUi(float delayLoadingTime) {
            StartCoroutine(LoadMenuAndUİAsync(delayLevelTime));
        }

        private IEnumerator LoadMenuAndUİAsync(float delayLoadigndTime) {

            yield return new WaitForSeconds(delayLevelTime);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("Proje2Uİ",LoadSceneMode.Additive);


            OnSceneChanged?.Invoke(true);
       }
    }
}
