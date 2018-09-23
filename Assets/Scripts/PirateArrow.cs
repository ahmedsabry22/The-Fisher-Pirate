using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateArrow : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public LayerMask fishLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fish")
        {
            rigidbody.bodyType = RigidbodyType2D.Static;

            transform.SetParent(other.transform, false);

            Rigidbody2D fishRB = other.gameObject.GetComponent<Rigidbody2D>();
            fishRB.gravityScale = 1;

            FishLife fishLife = other.GetComponent<FishLife>();
            fishLife.Die();

            Mission.Instance.OnFishHunted();

            Destroy(gameObject);
        }
    }
}