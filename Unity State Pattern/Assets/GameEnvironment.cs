using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> checkpoint =  new List<GameObject>();

    public List<GameObject> Checkpoint { get { return checkpoint; } }

    public static GameEnvironment Singleton
    {
        get{
            if (instance == null)
            {
                instance = new GameEnvironment();
                instance.Checkpoint.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
                instance.checkpoint = instance.checkpoint.OrderBy(x => x.name).ToList();
            }

            return instance;
        }
    }

    public GameObject GetPoint()
    {
        return checkpoint[Random.Range(0, checkpoint.Count)];
    }

}
