﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] levels;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        foreach(GameObject obj in levels)
        {
            loadObjs(obj);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadObjs(GameObject obj)
    {
        //Debug.Log(obj.name);
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;

        int childNeeds = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childNeeds; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;

        }

        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());

    }

    private void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);

            } else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, lastChild.transform.position.z);
            }

        }
    }

    private void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }
}
