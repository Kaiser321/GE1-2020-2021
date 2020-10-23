using UnityEngine;

public class OrbController : MonoBehaviour
{
    GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            SwitchControl();
        }
    }
    void TriggerCooldown()
    {
        transform.GetComponent<SphereCollider>().enabled = true;
    }

    void SwitchControl()
    {
        transform.parent.GetComponent<FPSController>().enabled = !transform.parent.GetComponent<FPSController>().enabled;
        transform.parent.GetComponent<Shooting>().enabled = !transform.parent.GetComponent<Shooting>().enabled;
        transform.parent.GetComponent<Patrol>().enabled = !transform.parent.GetComponent<Patrol>().enabled;
        transform.GetComponent<Rotation>().enabled = !transform.GetComponent<Rotation>().enabled;
        player.GetComponent<FPSController>().enabled = !player.GetComponent<FPSController>().enabled;
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SwitchControl();
            transform.GetComponent<SphereCollider>().enabled = false;
            player = null;
            Invoke("TriggerCooldown", 5);
        }

        if (other.gameObject.tag == "Player")
        {
            player.transform.position = Vector3.Lerp(player.transform.position, transform.position, 5 * Time.deltaTime);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, transform.parent.rotation, 5 * Time.deltaTime);
        }
    }


}