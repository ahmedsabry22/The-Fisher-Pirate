using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGamePirate : MonoBehaviour
{
    public Animator animator;

    private void OnMouseDown()
    {
        animator.SetTrigger("Jump");
        GlobalCoroutineHandler.Instance.PlayCoroutineWithTime(() => SceneManager.LoadSceneAsync("2 - Game"), 3);
    }
}