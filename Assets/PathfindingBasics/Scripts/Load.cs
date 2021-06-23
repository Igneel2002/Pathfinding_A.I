using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public AgentSmith agent;
    private Waypoint[] waypoints;

    private Waypoint FirstPoint => waypoints[Random.Range(0, waypoints.Length)];

    private void Start()
    {
        waypoints = FindObjectsOfType<Waypoint>();
    }

    public void LOAD()
    {
        SceneManager.LoadScene("MAZE");
    }

    public void RESTART()
    {
        if (agent.door == 0)
        {
            agent.win.SetActive(false);
            agent.Agent.SetDestination(FirstPoint.Position);
            agent.mon = 0;
            Time.timeScale = 1;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Screen.lockCursor = false;
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void EXIT()
    {
#if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
