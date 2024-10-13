using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
	PlayerController player;

	[SerializeField] private Transform grabPoint;
	[SerializeField] private Transform rightRayPoint;
	[SerializeField] private Transform leftRayPoint;
	[SerializeField] private Transform downRayPoint;

	private float rayDistance = 0.2f;
	private GameObject grabObj;
	RaycastHit2D hitRight;
	RaycastHit2D hitLeft;
	RaycastHit2D hitDown;
	RaycastHit2D hit;

	private bool hasItem = false; 
	private void Start()
	{
		//grabPoint = GameObject.Find("GrabPoint").transform;
		//rayPoint = GameObject.Find("RayPoint").transform;
		player = GetComponent<PlayerController>();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			//何もアイテムを持っていないなら
			if (grabObj == null)
			{
				//0.2fまでRayを飛ばす
				hitRight = Physics2D.Raycast(rightRayPoint.position, transform.right, rayDistance);
				hitLeft = Physics2D.Raycast(leftRayPoint.position, transform.right, -rayDistance);
				if (hitRight.collider != null && hitRight.collider.tag == "Key")
				{
					hit = hitRight;
				}
				else if (hitLeft.collider != null && hitLeft.collider.tag == "Key")
				{
					hit = hitLeft;
				}
				/*Debug.DrawRay(hit.collider.tag);*/
				//鍵に接触したら上に持ち上げる
				if (hit.collider != null && hit.collider.tag == "Key")
				{
					Debug.Log("持った");
					grabObj = hit.collider.gameObject;
					grabObj.GetComponent<Rigidbody2D>().isKinematic = true;
					grabObj.transform.position = grabPoint.position;
					grabObj.transform.SetParent(transform);
					hasItem = true;
				}
			}
			
			//Eを押したら右に鍵を置く
		}
		//Qを押したら左に鍵を置く
		if (Input.GetKeyDown(KeyCode.Q) && hasItem)
		{
			Debug.Log("押された");
			Vector2 pos = transform.position;
			pos.x -= 1;
			grabObj.transform.position = pos;
			grabObj.GetComponent<Rigidbody2D>().isKinematic = false;
			grabObj.transform.SetParent(null);
			grabObj = null;
			hasItem = false;
		}
		else if (Input.GetKeyDown(KeyCode.E) && hasItem)
		{
			Debug.Log("押された");
			Vector2 pos = transform.position;
			pos.x += 1;
			grabObj.transform.position = pos;
			grabObj.GetComponent<Rigidbody2D>().isKinematic = false;
			grabObj.transform.SetParent(null);
			grabObj = null;
			hasItem = false;
		}

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		hitDown = Physics2D.Raycast(downRayPoint.position, transform.up, -rayDistance);
		if (hitDown.collider != null && hitDown.collider.tag == "Ground")
		{
			hit = hitDown;
		}
		if (hit.collider != null && hit.collider.tag == "Ground")
		{
			if (collision.gameObject.CompareTag("Ground"))
			{
				//地面との接触確認
				player.isJumping = true;
			}
		}
	}
}
