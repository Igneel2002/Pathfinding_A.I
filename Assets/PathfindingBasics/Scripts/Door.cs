using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AgentSmith agent;
    public GameObject door;
    public GameObject doorpos1;
    public GameObject doorpos2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.door == 2)
        {
            door.transform.position = doorpos1.transform.position;
        }
        
        if (agent.door == 0)
        {
            door.transform.position = doorpos2.transform.position;
        }
    }
}
