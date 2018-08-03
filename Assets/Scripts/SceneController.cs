using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    }
}