using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public Rigidbody playerRB;
    public int power;
    public int speed;
    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Move();
    }
    private void Move()
    {
        playerRB.AddForce(speed, 0, 0, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            if(Vector3.Distance(transform.position, collision.transform.position) <= 2)
            {
                collision.rigidbody.AddForce(Random.Range(0, 50), Random.Range(10, 50), Random.Range(-50, 50));
                Debug.Log($"Badguy got {power} damage");
                //collision.gameObject.SetActive(false);
            }
        }
    }
}
