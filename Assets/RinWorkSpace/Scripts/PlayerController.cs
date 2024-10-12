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
	///Playerの左右移動
	///</summary>
	private void Walk()
	{
		//右移動
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			Debug.Log("右移動");
			Vector2 pos = transform.position;
			pos.x += 0.01f;
			transform.position = pos;
		}
		//左移動
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			Debug.Log("左移動");
			Vector2 pos = transform.position;
			pos.x -= 0.01f;
			transform.position = pos;
		}
	}
	///<summary>
	///Playerのジャンプ
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
			//地面との接触確認
			isJumping = true;
		}
	}
}
