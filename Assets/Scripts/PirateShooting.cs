using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShooting : MonoBehaviour
{
    public Animator animator;
    public float arrowVelocitySpeed;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;

    private Rigidbody2D arrowRB;
    private BoxCollider2D arrowBoxCol;
    private Vector3 aimPosition;
    private bool onShoot;

    private void Awake()
    {
        PrepareShooting();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !onShoot)
        {
            Shoot();
        }
    }

    private void PrepareShooting()
    {
        onShoot = false;
        GameObject arrow = Instantiate(arrowPrefab, transform, false);
        arrow.transform.position = arrowSpawnPoint.position;
        arrow.transform.parent = transform;
        arrowRB = arrow.GetComponent<Rigidbody2D>();
        arrowBoxCol = arrow.GetComponent<BoxCollider2D>();
        arrowBoxCol.enabled = false;
    }

    private void Shoot()
    {
        aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (aimPosition.x >= 0)
        {
            onShoot = true;

            var dir = aimPosition - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            arrowRB.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector3 targetVelocity = (aimPosition - (Vector3)arrowRB.transform.position);
            arrowRB.velocity = targetVelocity * arrowVelocitySpeed;

            arrowBoxCol.enabled = true;

            animator.SetTrigger("Aim");

            GlobalCoroutineHandler.Instance.PlayCoroutineWithTime(PrepareShooting, 0.25f);
        }
    }
}