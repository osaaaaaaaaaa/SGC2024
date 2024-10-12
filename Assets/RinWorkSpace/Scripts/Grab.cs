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
			//�����A�C�e���������Ă��Ȃ��Ȃ�
			if (grabObj == null)
			{
				//0.2f�܂�Ray���΂�
				hit = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
				/*Debug.DrawRay(hit.collider.tag);*/
				//���ɐڐG�������Ɏ����グ��
				if(hit.collider != null && hit.collider.tag == "Key")
				{
					Debug.Log("������");
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
