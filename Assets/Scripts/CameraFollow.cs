using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;

    [SerializeField]
    private float offset = -6f;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").transform;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset);
    }
}
