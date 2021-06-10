using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}


public class Pool : MonoBehaviour
{
    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooleditems;

    private void Awake()
    {
        singleton = this;
    }

    public GameObject Get(string tag)
    {
        for(int i = 0; i < pooleditems.Count; i++)
        {
            if(!pooleditems[i].activeInHierarchy && pooleditems[i].tag == tag)
            {
                return pooleditems[i];
            }
        }
        foreach(PoolItem item in items)
        {
            if(item.prefab.tag == tag && item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooleditems.Add(obj);
                return obj;
            }
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooleditems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for(int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooleditems.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
