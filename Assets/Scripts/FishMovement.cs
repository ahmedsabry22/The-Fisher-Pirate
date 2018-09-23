using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    private Quaternion fromRotation, toRotation;
    private FishLife fishLife;

    [HideInInspector] public Transform Target;
    [SerializeField] public new Rigidbody2D rigidbody;
    public float speed;

    private void Awake()
    {
        fishLife = GetComponent<FishLife>();
        speed = Random.Range(1, 5);
    }

    private void Start()
    {
        var dir = Target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rigidbody.velocity = -transform.right * speed;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (fishLife.alive)
        {
            yield return (new WaitForSeconds(Random.Range(3f, 5f) / speed));

            toRotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(270, 360)));

            //while (Vector3.Angle(transform.rotation.eulerAngles, toRotation.eulerAngles) >= 0)

            while (transform.rotation != toRotation && fishLife.alive)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);

                rigidbody.velocity = -transform.right * speed;
                yield return (null);
            }
        }
    }
}
