using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject body;
    public GameObject turret;
    private bool hit = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && !hit)
        {
            hit = !hit;
            ExplodeTank();
            Invoke("SinkTank", 4.0f);
            Invoke("RemoveTank", 7.0f);
        }
    }

    void ExplodeTank() {
        turret.AddComponent<Rigidbody>();
        turret.GetComponent<Rigidbody>().AddForce(Random.Range(-50, 50), Random.Range(100, 200), Random.Range(10,100));
    }

    void SinkTank()
    {
        turret.GetComponent<BoxCollider>().enabled = false;
        turret.GetComponent<Rigidbody>().drag = 1;
        body.GetComponent<BoxCollider>().enabled = false;
        body.GetComponent<Rigidbody>().drag = 1;
    }

    void RemoveTank()
    {
        Object.Destroy(gameObject);
    }
}
