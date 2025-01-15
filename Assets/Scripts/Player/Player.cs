using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 7.5f;

    Rigidbody2D rigid;
    Animator anim;

    [SerializeField] private bool isFacingRight = false; // �ڵ� �׽�Ʈ�� ���ؼ� �ν������� �����ŷ, Ȯ���� �����


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Jump();
    }
    // Start is called before the first frame update
    private void Move()
    {
        // �Է� Control
        float horizontal = InputUser.Instance.moveInput.x;

        // �Է°��� �־��°�?
        if(Math.Abs(horizontal)>0) // �Է°��� ���� ��
        {
            anim.SetBool("isWalking", true);
            TrunCheck();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // rigidbody2D
        rigid.velocity = new Vector2(horizontal * moveSpeed, rigid.velocity.y);

    }

    #region Flip

    private void TrunCheck()
    {
        if (InputUser.Instance.moveInput.x > 0 && !isFacingRight) // ����
        {
            Turn();
        }
        else if (InputUser.Instance.moveInput.x < 0 && isFacingRight) // �ĸ�
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (isFacingRight) // ���� -> �ĸ�
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
        else // �ĸ� -> ����
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
    }
    #endregion
    // Update is called once per frame
    private void Jump()
    {
        
    }
}
