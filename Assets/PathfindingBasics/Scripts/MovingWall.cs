using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField]
    private float SPED = 0.1f;
    [SerializeField]
    private Transform startMarker;
    [SerializeField]
    private Transform endMarker;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(Time.time * SPED, 1));
    }
}
