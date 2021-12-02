using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    enum eJumpState
    {
        NONE = -1,

        UP,
        DOWN,

        STATE_NUM,
    }


    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Camera cam;

    private Vector3 moveVec;
    private float speed;

    private const float walkSpeed = 2.0f;
    private const float dashSpeed = 5.0f;
    private const float limitWalkSpeed = 10.0f;
    private const float limitWDashSpeed = 15.0f;

    private const float jumpForce= 10.0f;
    private const int limitJump = 50;

    private int jumpInput;

    private bool input;
    private eJumpState jumpState;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cam.transform.forward);

        // プレイヤー入力受付
        PlayerInput();

        // プレイヤー回転更新
        PlayerRotate();

        // プレイヤー移動更新
        PlayerMove();

        // プレイヤー空中挙動更新
        PlayerJump();
    }

    /// <summary>
    /// プレイヤーの移動を行う関数
    /// </summary>
    private void PlayerMove()
    {
        // 移動入力が無い場合スキップ
        if (moveVec.x == 0
            && moveVec.z == 0)
            return;

        // プレイヤーを動かす
        //rb.AddForce(transform.forward * speed);
        rb.velocity += transform.forward * speed;
    }

    /// <summary>
    /// プレイヤーの回転を行う関数
    /// </summary>
    private void PlayerRotate()
    {
        Vector3 dir = Vector3.zero;

        // 前
        if (moveVec.z > 0)
        {
            dir += cam.transform.forward;
        }
        // 右
        if (moveVec.x > 0)
        {
            dir += cam.transform.right;
        }
        // 後
        if (moveVec.z < 0)
        {
            dir -= cam.transform.forward;
        }
        // 左
        if (moveVec.x < 0)
        {
            dir -= cam.transform.right;
        }

        // カメラの傾きによるズレを修正
        dir.y = 0.0f;

        // 移動入力が無い場合スキップ
        if (moveVec.x == 0
            && moveVec.z == 0)
            return;

        // 滑らかに向きを変える
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir.normalized), 0.05f);
    }

    /// <summary>
    /// プレイヤーのジャンプを行う関数
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
            //rb.velocity += transform.up * jumpForce;
        }
    }

    /// <summary>
    /// プレイヤーの入力を管理する関数
    /// </summary>
    /// <returns></returns>
    private bool PlayerInput()
    {
        // 初期化
        input = false;

        if (Input.GetKey(KeyCode.W))
        {
            moveVec.z = 1.0f;
            input = true;
        }
        else
        {
            moveVec.z = 0.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVec.x = 1.0f;
            input = true;
        }
        else
        {
            moveVec.x = 0.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVec.z = -1.0f;
            input = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVec.x = -1.0f;
            input = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jumpInput++;
            input = true;
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
            input = true;
        }
        else
        {
            speed = walkSpeed;
        }

        return input;
    }

    private void FixedUpdate()
    {
        // 速度制限
        //if (rb.velocity.magnitude > limitSpeed)
        //{
        //    rb.velocity = rb.velocity.normalized * limitSpeed;
        //}

        // XZ平面上での速度を計算
        float magXZ = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z);

        // 速度超過していた場合
        if (magXZ > limitWalkSpeed)
        {
            // 正規化処理をX,Zそれぞれ行う
            float velX = rb.velocity.x / magXZ * limitWalkSpeed;
            float velZ = rb.velocity.z / magXZ * limitWalkSpeed;

            // Y以外の速度を調整
            rb.velocity = new Vector3(velX, rb.velocity.y, velZ);
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