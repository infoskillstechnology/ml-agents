using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [Header("KEY")]
	// public Transform key;
	public Collider keyCollider;
	Vector3 startingPositionKey;

    [Header("DOOR")]
	// public Transform door;
	public Collider doorCollider;
	Vector3 startingPositionDoor;


    [Header("LEVEL")]
	public int currentLevel = 0;

	// Use this for initialization
	void Awake () {
		startingPositionKey = keyCollider.transform.position;
		startingPositionDoor = doorCollider.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetKeyPosition()
	{
		keyCollider.transform.parent = null;
		keyCollider.enabled = true;
		keyCollider.transform.position = startingPositionKey;
	}
	public void ResetDoor()
	{
		doorCollider.transform.position = startingPositionDoor;
		doorCollider.transform.gameObject.SetActive(true);
	}

}
