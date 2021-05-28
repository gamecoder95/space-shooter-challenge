using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg3 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mt = mr.material;

        Vector2 offset = mt.mainTextureOffset;

        offset.y += Time.deltaTime / 50f;

        mt.mainTextureOffset = offset;


    }
}
