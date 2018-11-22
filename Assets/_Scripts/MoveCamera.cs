using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {


    private PlayerConroller pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerConroller>();
    }

    void Update () {
        transform.position = new Vector3(pc.transform.position.x, transform.position.y,-10);
	}
}
