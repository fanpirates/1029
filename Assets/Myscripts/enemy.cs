using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float lookSpeed = 2f;

    Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        dir = new Vector3(dir.x, 0, dir.z);

        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(dir), Time.deltaTime * lookSpeed);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameSystem.Instance.FinishRun();
        }
    }
}