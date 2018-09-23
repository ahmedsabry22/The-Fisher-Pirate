using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        GlobalCoroutineHandler.Instance.PlayCoroutineWithTime(() => SceneManager.LoadSceneAsync(name, LoadSceneMode.Single), 3);
    }

    public void PausePlay(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}