using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int numOfRings;
    public GameObject hex_prefab;
    public int rotationSpeed;
    private ArrayList hexList = new ArrayList();
    private float radius = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        for (int ring = 1; ring <= numOfRings; ring++)
        {
            int numOfHex = ring * 6;
            for (int h = 0; h < numOfHex; h++)
            {
                float radian = 2f * (Mathf.PI / numOfHex) * h;

                float xPos = Mathf.Sin(radian) * radius + transform.position.x;
                float yPos = Mathf.Cos(radian) * radius + transform.position.y;

                GameObject hex = Instantiate(hex_prefab, new Vector3(xPos, yPos, 1), new Quaternion(0, 0, 0, 0));
                hexList.Add(hex);
            }
            radius += 1.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject hex in hexList)
        {

            hex.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

    }
}
