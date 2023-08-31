using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public float velocity;
    float timeToWait;

    float timeCounterToDie = 10f;

    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
        timeToWait = 1f - (1f / velocity);
    }
    private void Update()
    {
        timeToWait -= Time.deltaTime;
        timeCounterToDie -= Time.deltaTime;

        if(timeToWait < 0f)
        {
            MoveCube();
        }

        if (timeCounterToDie < 0f)
            Destroy();

    }

    public void DestroyCube()
    {
        Invoke(nameof(Destroy), 1f);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void MoveCube()
    {
        if (rb.velocity.magnitude < Mathf.Epsilon)
        {
            rb.velocity = -Vector3.forward * velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cleaner"))
        {
            Destroy(this.gameObject);
        }
    }

}
