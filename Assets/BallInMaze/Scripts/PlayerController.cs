using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Values")]
    float originalSpeed;
    [SerializeField] float Speed = 1f;
    float boostTimeLeft = 0f;
    [SerializeField] float JumpPower = 1f;
    [SerializeField] float JumpResetTime = 1f;

    float Score = 0f;

    // Controls
    bool CanJump = true;

    // Inputs
    float inHorizontal;
    float inVertical;

    [Header("References")]
    Rigidbody rb;
    [SerializeField] TMP_Text ScoreText;

    private void Start()
    {
        originalSpeed = Speed;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        inHorizontal = Input.GetAxis("Horizontal");
        inVertical = Input.GetAxis("Vertical");

        if (CanJump && Input.GetKeyDown(KeyCode.Space)) Jump();

        Move();
    }

    #region Movement

    void Jump()
    {
        CanJump = false;
        rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        Invoke("ResetJump", JumpResetTime);
    }

    void ResetJump()
    {
        CanJump = true;
    }

    public void UpgradeJump()
    {
        JumpPower += 1f;
    }

    void Move()
    {
        boostTimeLeft -= Time.deltaTime;
        if (boostTimeLeft <= 0f) ResetSpeed();

        rb.AddForce(new Vector3(inHorizontal, 0f, inVertical) * Speed, ForceMode.Force);
    }

    // Activates speed boost for set amount of time
    public void SpeedBoost(float multiplier, float time)
    {
        Speed *= multiplier;    // Is this op? Yes. Does it matter for this small scale game w/o too many OP things? no.
        boostTimeLeft = time;
    }

    void ResetSpeed()
    {
        boostTimeLeft = 0f;
        Speed = originalSpeed;
    }

    #endregion

    public void CollectCoin(float value)
    {
        Score += value;
        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        ScoreText.text = "Score: " + Score;
    }
}
