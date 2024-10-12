using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;

	private float rayDistance = 0.2f;
	private GameObject grabObj;
	RaycastHit2D hit;
	private void Start()
	{
		//grabPoint = GameObject.Find("GrabPoint").transform;
		//rayPoint = GameObject.Find("RayPoint").transform;
	}
	void Update()
    {
		if(Input.GetKeyDown(KeyCode.F))
		{
			//何もアイテムを持っていないなら
			if (grabObj == null)
			{
				//0.2fまでRayを飛ばす
				hit = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
				/*Debug.DrawRay(hit.collider.tag);*/
				//鍵に接触したら上に持ち上げる
				if(hit.collider != null && hit.collider.tag == "Key")
				{
					Debug.Log("持った");
					grabObj = hit.collider.gameObject;
					grabObj.GetComponent<Rigidbody2D>().isKinematic = true;
					grabObj.transform.position = grabPoint.position;
					grabObj.transform.SetParent(transform);
				}
			}
			else
			{
				grabObj.GetComponent<Rigidbody2D>().isKinematic = false;
				grabObj.transform.SetParent(null);
				grabObj = null;
			}
		}
		
    }
}
