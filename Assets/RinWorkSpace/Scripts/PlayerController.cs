using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator animator;
	private new Rigidbody2D rigidbody2D;
	public bool isJumping;
	bool isGrounded;
	[SerializeField] float speed = 2.0f;
	[SerializeField] float jumpPower = 5.0f;
	void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();	
    }
	private void Update()
	{
		Walk();
		Jump();
	}
	///<summary>
	///Player�̍��E�ړ�
	///</summary>
	private void Walk()
	{
		float horizontalKey = Input.GetAxis("Horizontal");

		//�E���͂ō������ɓ���
		if (horizontalKey > 0)
		{
			rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
			if (isJumping)
				animator.Play("PlayerRun");
		}
		//�����͂ō������ɓ���
		else if (horizontalKey < 0)
		{
			rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
			if (isJumping)
				animator.Play("PlayerRun");
		}
		//�{�^����b���Ǝ~�܂�
		else
		{
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
			if (isJumping)
				animator.Play("PlayerIdle");
		}	
		
		/*if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
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
		}*/

	}
	///<summary>
	///Player�̃W�����v
	///</summary>
	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (isJumping)
			{
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
				isJumping = false;
				animator.Play("PlayerJump");
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
		{
			/*if (!isJumping)
			{
				isGrounded = false;
				animator.Play("PlayerFall");
				Vector2 pos = transform.position;
				pos.y += 0.1f;
				transform.position = pos;
				isGrounded = true;
			}*/
			//�n�ʂƂ̐ڐG�m�F
			//isJumping = true;
		}
		
	}
}
