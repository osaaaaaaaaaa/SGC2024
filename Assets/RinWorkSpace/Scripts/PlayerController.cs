using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
	bool isJumping;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		Walk();
		Jump();
    }
	///<summary>
	///Player�̍��E�ړ�
	///</summary>
	private void Walk()
	{
		float InputX = Input.GetAxisRaw("Horizontal");
		
	}
	///<summary>
	///Player�̃W�����v
	///</summary>
	private void Jump()
	{
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
		{
			if (isJumping)
			{
				float jumpPower = 5.0f;
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
				isJumping = false;
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
		{
			//�n�ʂƂ̐ڐG�m�F
			isJumping = true;
		}
	}
}
