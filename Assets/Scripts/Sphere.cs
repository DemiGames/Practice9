using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float power;
    private float timeTillboom;
    public float startTimeTillBoom;
    public float boomRadius;
    public GameObject boomObject;
    private void Start()
    {
        timeTillboom = startTimeTillBoom;
    }

    void Update()
    {
        timeTillboom -= Time.deltaTime;
        if (timeTillboom <= 0)
            Boom();
    }
    private void Boom()
    {
        Rigidbody[] boomObjects = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody weee in boomObjects)
        {
            float distanceFromBoom = Vector3.Distance(boomObject.transform.position, weee.transform.position);
            if (distanceFromBoom < boomRadius)
            {
                Vector3 direction = weee.transform.position - boomObject.transform.position;
                weee.AddForce(direction.normalized * power * (boomRadius - distanceFromBoom),ForceMode.Impulse);
            }
        }
        timeTillboom = startTimeTillBoom;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
