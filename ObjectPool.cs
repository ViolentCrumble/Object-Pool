using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public List<GameObject> pooledobjects = new List<GameObject>();
    public List<GameObject> objectsToPool = new List<GameObject>();

    // Use this for initialization
    void Start () {

        pooledobjects = new List<GameObject>();

        FillPool();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearPool()
    {
        pooledobjects = new List<GameObject>();
    }


    public void FillPool()
    {
        foreach (var item in objectsToPool)
        {
            var obj = Instantiate(item);
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        if (pooledobjects.Any(x => !x.activeInHierarchy))
        {
            return pooledobjects.OrderBy(x => Guid.NewGuid()).FirstOrDefault(x => !x.activeInHierarchy);
        }
        else
        {
            var obj = GetRandomObject();
            pooledobjects.Add(obj);
            return obj;
        }
    }


    public GameObject GetRandomObject()
    {
        GameObject obj;

        obj = Instantiate(objectsToPool.OrderBy(x => Guid.NewGuid()).FirstOrDefault());

        obj.SetActive(false);
        return obj;

    }
}
