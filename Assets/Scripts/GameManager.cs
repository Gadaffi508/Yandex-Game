using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ducktastic
{
    public class GameManager : MonoBehaviour
    {
        [Header("Load Options")] public GameObject loadScene;
        public Image LoadingFillImage;
        
        public void LoadScene(int _SceneIndex)
        {
            StartCoroutine(LoadSceneAsync(_SceneIndex));
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
        IEnumerator LoadSceneAsync(int SceneId)
        {
            loadScene.SetActive(true);

            yield return new WaitForEndOfFrame();

            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);

            while (!operation.isDone)
            {
                float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

                LoadingFillImage.fillAmount = progressValue;

                yield return null;
            }
        }
    }
}
