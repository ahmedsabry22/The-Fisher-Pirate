using UnityEngine;
using System.Collections;

public class FishLife : MonoBehaviour
{
    public Animator animator;
    public bool alive = true;

    public void Die()
    {
        alive = false;
        animator.SetTrigger("Die");
        Destroy(gameObject, 5);
    }
}