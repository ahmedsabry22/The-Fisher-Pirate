using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string name)
    {
        GlobalCoroutineHandler.Instance.PlayCoroutineWithTime(() => SceneManager.LoadSceneAsync(name, LoadSceneMode.Single), 3);
    }
}