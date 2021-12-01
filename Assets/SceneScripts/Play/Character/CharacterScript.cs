using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    /// <summary>
    /// 入力にて使用するキー・ボタン
    /// </summary>
    enum eKeyInput
    {
        NONE = -1,

        W,
        D,
        S,
        A,
        SPACE,
        SHIFT,

        INPUT_NUM,
    }

    enum eJumpState
    {
        NONE = -1,

        UP,
        DOWN,

        STATE_NUM,
    }

    [SerializeField]
    private Rigidbody rb;

    private Vector3 vel;
    private float speed;

    private const float walkSpeed = 10.0f;
    private const float dashSpeed = 15.0f;
    private const float limitSpeed = 30.0f;

    private const float jumpForce= 10.0f;
    private const int limitJump = 50;

    private int jumpInput;

    private float velX;
    private float velZ;

    private eKeyInput input;
    private eJumpState jumpState;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(jumpInput);
        Debug.Log(jumpState);

        // プレイヤー移動更新
        PlayerMove();

        // プレイヤー空中挙動更新
        PlayerJump();
    }

    /// <summary>
    /// プレイヤーの移動を管理する関数
    /// </summary>
    private void PlayerMove()
    {
        // 入力が無ければスキップ
        if (!PlayerInput())
            return;

        // 入力から速度を更新
        vel = new Vector3(velX, 0, velZ);

        // プレイヤーを動かす
        rb.AddForce(vel * speed);
    }

    /// <summary>
    /// プレイヤーのジャンプを管理する関数
    /// </summary>
    private void PlayerJump()
    {
        if (jumpInput > limitJump || jumpState == eJumpState.DOWN)
            return;

        if (jumpInput > 0)
        {
            jumpState = eJumpState.UP;

            // プレイヤーを動かす
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }


    /// <summary>
    /// プレイヤーの入力を管理する関数
    /// </summary>
    /// <returns></returns>
    private bool PlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velZ = 1.0f;
            input = eKeyInput.W;
        }
        else
        {
            velZ = 0.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velX = 1.0f;
            input = eKeyInput.D;
        }
        else
        {
            velX = 0.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            velZ = -1.0f;
            input = eKeyInput.S;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velX = -1.0f;
            input = eKeyInput.A;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            input = eKeyInput.SPACE;

            jumpInput++;
        }
        else
        {
            jumpInput = 0;

            if (jumpState == eJumpState.UP)
                jumpState = eJumpState.DOWN;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = dashSpeed;
            input = eKeyInput.SHIFT;
        }
        else
        {
            speed = walkSpeed;
        }

        return input != eKeyInput.NONE;
    }

    private void FixedUpdate()
    {
        // 速度制限
        if (rb.velocity.magnitude > limitSpeed)
        {
            rb.velocity = rb.velocity.normalized * limitSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpState = eJumpState.NONE;
        }
    }
}