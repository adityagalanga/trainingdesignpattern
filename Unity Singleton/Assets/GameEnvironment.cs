using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> obstacles = new List<GameObject>();
    private List<GameObject> goalLocations =  new List<GameObject>();
    public List<GameObject> Obstacles { get { return obstacles; } }
    public List<GameObject> GoalLocation { get { return goalLocations; } }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
                instance.goalLocations.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            }
            return instance;
        }
    }

    public GameObject GetLocation()
    {
        return goalLocations[Random.Range(0, goalLocations.Count)];
    }

    public void AddObstacle(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveObstacle(GameObject go)
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
        GameObject.Destroy(go);
    }
}
