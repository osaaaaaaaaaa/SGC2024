using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Sprite[] walk;
	SpriteRenderer sprite;
	Animator animator;
	private new Rigidbody2D rigidbody2D;
	bool isJumping;
	
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();	
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
		if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
		{
			Vector2 pos = transform.position;
			pos.x += 0.01f;
			transform.position = pos;
			animator.Play("PlayerRun");
		}
		else if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
		{
			Vector2 pos = transform.position;
			pos.x -= 0.01f;
			transform.position = pos;

			animator.Play("PlayerRun");
		}
		else
		{
			animator.Play("PlayerIdle");
		}
		
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
