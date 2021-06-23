using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentSmith : MonoBehaviour
{
    public NavMeshAgent Agent;
    private Waypoint[] waypoints;
    private Waypoint1[] waypoints1;
    private Waypoint2[] waypoints2;
    private Waypoint3[] waypoints3;
    public float door = 0;
    public GameObject coin;
    public GameObject sp1;
    public GameObject chara;
    public GameObject win;
    public float mon = 0;
    [SerializeField]
    private GameObject MON;
    public Text Montext;

    public Animator anim;

    private Waypoint FirstPoint => waypoints[Random.Range(0, waypoints.Length)];
    private Waypoint1 SecondPoint => waypoints1[Random.Range(0, waypoints1.Length)];
    private Waypoint2 ThirdPoint => waypoints2[Random.Range(0, waypoints2.Length)];
    private Waypoint3 FinalPoint => waypoints3[Random.Range(0, waypoints3.Length)];

    // Start is called before the first frame update
    void Start()
    {
        // Grab the component NavMeshAgent
        Agent = gameObject.GetComponent<NavMeshAgent>();
        // FindOfObjectsOfType gets every instance of this component in the scene
        waypoints = FindObjectsOfType<Waypoint>();
        waypoints1 = FindObjectsOfType<Waypoint1>();
        waypoints2 = FindObjectsOfType<Waypoint2>();
        waypoints3 = FindObjectsOfType<Waypoint3>();
        // Tell the agent to move to a random position in the scene waypoints
        Agent.SetDestination(FirstPoint.Position);
        // 
        anim = GetComponent<Animator>();
        anim.SetBool("walk1", true);
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // MONtext will display (the coin)
        Montext.text = "Coins " + (int)mon;
        // Has the agent reached it's position?
        if (!Agent.pathPending && Agent.remainingDistance == 0 && door == 0)
        {
            door += 1;
            // Tell the agent to move to a random position in the scene waypoints
            Agent.SetDestination(SecondPoint.Position);
        }
        
        // Has the agent reached it's position?
        if (!Agent.pathPending && Agent.remainingDistance == 0 && door == 1)
        {
            door += 1;
            // Tell the agent to move to a random position in the scene waypoints
            Agent.SetDestination(ThirdPoint.Position);
        }
        
        // Has the agent reached it's position?
        if (!Agent.pathPending && Agent.remainingDistance == 0 && door == 2)
        {
            door += 1;
            // Tell the agent to move to a random position in the scene waypoints
            Agent.SetDestination(FinalPoint.Position);
            coin.SetActive(false);
            mon += 1;
        }

        if (!Agent.pathPending && Agent.remainingDistance == 0 && door == 3 && mon == 1)
        {
            door = 0;
            chara.transform.position = sp1.transform.position;
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "way1":
                {
                    anim.SetBool("wa1k", false);
                }
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("walk1", false);
    }
}
