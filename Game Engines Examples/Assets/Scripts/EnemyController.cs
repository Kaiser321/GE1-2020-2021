using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int elements = 12;
    public float radius = 10;
    public GameObject waypointPrefab;
    private ArrayList wayPoints = new ArrayList();
    private int currentWaypointIndex = 0;
    private GameObject currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        float theta = Mathf.PI * 2.0f / (float)elements;
        for (int i = 0; i < elements; i++)
        {
            GameObject wp = Instantiate(waypointPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            wp.transform.position = transform.TransformPoint(pos);
            wayPoints.Add(wp);
            currentWaypoint = (GameObject)wayPoints[currentWaypointIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Vector3.Distance(transform.position, w.transform.position));
        if (Vector3.Distance(transform.position, currentWaypoint.transform.position) < 0.5)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % wayPoints.Count;
            currentWaypoint = (GameObject)wayPoints[currentWaypointIndex];
        }
        Vector3 targetDirection = currentWaypoint.transform.position - transform.position;
        transform.LookAt(currentWaypoint.transform);
        // Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 20 * Time.deltaTime, 0.0f);
        // transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.transform.position, 1 * Time.deltaTime);
    }
}
