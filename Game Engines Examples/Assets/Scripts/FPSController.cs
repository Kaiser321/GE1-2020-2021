using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 100;

    void FixedUpdate()
    {
        float c = Input.GetAxis("Vertical");
        transform.Translate(0, 0, c * speed * Time.deltaTime);

        float r = Input.GetAxis("Horizontal");
        transform.Rotate(0, r * rotationSpeed * Time.deltaTime, 0);
    }
}
