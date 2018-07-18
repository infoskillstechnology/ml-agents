using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

    [Header("GENERAL")]
	public bool isNPC;
	Vector3 startingPlayerPosition;
	GameController gameController;

    [Header("HEALTH/DAMAGE")]
	public float health;

    [Header("VISION/RAYCASTING")]
	public bool useVision;

    [Header("GROUND CHECK")]
	public bool isGrounded;

    [Header("FIGHTING")]
	public bool canFight;

    [Header("PATHFINDING")]
	public bool usePathfinding;

    [Header("PICK UP ITEMS")]
	public bool canPickUpItems;
	public Transform holdKeyPosition;
	public bool playerHasKey;

    // [Header("DOOR CONTROLS")]
	// public bool canPickUpItems;
	// public Transform holdKeyPosition;

	// Use this for initialization
	void Awake () {
		gameController = FindObjectOfType<GameController>();
		playerHasKey = false;
		startingPlayerPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -.5) //fell
		{
			ResetPlayer();
		}
	}

	void OnTriggerEnter(Collider col)
	{
	}

	public void ResetPlayer()
	{
		transform.position = startingPlayerPosition;
		playerHasKey = false;
		gameController.ResetKeyPosition();
	}

	void PickUpKey(Collision col)
	{
		print("PICKING UP KEY");
		col.transform.position = holdKeyPosition.position;
		col.collider.enabled = false;
		col.transform.SetParent(holdKeyPosition);
		// col.transform.GetComponent<Rigidbody>().isKinematic = true;
		playerHasKey = true;
	}

	void OnCollisionEnter(Collision col)
	{
		if(canPickUpItems && !playerHasKey)
		{
			if(col.gameObject.CompareTag("key"))
			{
				PickUpKey(col);
			}
		}
		if(col.gameObject.CompareTag("door"))
		{
			if(playerHasKey)
			{
				//open door
				col.gameObject.SetActive(false);
				//PLAYER CAN ADVANCE TO THE NEXT LEVEL
			}
			else
			{
				//key required
			}
		}
		if(col.gameObject.CompareTag("hazard"))
		{
			ResetPlayer();
			gameController.ResetKeyPosition();
			gameController.ResetDoor();
		}
	}


	// void GrabKey(Collision col)
	// {

	// }
}
