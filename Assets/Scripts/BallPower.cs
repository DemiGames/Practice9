using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPower : MonoBehaviour
{
    public int power;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(power, 0, 0, ForceMode.Impulse);
    }
}
