using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator playerAnim;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximunRunVelocity = 2.0f;
    private bool isJumping;
    private bool isGrounded;

    int VelocityZHash;
    int VelocityXHash;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();

        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }
    // Handles acceleration and deceleration
    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        // If player presses forward, increase velocity in z direction
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
            playerAnim.SetBool("isMoving", true);
        }

        // Increase velocity in left direction
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
            playerAnim.SetBool("isMoving", true);
        }

        // Increase velocity in right direction
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
            playerAnim.SetBool("isMoving", true);
        }

        // Increase velocity backward
        if (backPressed && velocityZ > -currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration;
            playerAnim.SetBool("isMoving", true);
        }

        // decrease velocityZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        // decrease velocityZ
        if (!backPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
        }

        // increase velocityX if left is not pressed and velocityX < 0
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        // decrease velocityX if right is not pressed and velocityX > 0
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }


    }

    void LockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        // reset velocityZ
        if (!forwardPressed && !backPressed && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
            playerAnim.SetBool("isMoving", false);
        }

        // reset velocityX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
            playerAnim.SetBool("isMoving", false);
        }

        // lock forward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            // round to the currentMaxVelovity if within offset
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if withing offset
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        // lock back
        if (backPressed && runPressed && velocityZ < -currentMaxVelocity)
        {
            velocityZ = -currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (backPressed && velocityZ < -currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * deceleration;
            // round to the currentMaxVelovity if within offset
            if (velocityZ < -currentMaxVelocity && velocityZ > (-currentMaxVelocity - 0.05f))
            {
                velocityZ = -currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if withing offset
        else if (backPressed && velocityZ > -currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
        {
            velocityZ = -currentMaxVelocity;
        }

        // lock left
        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            // round to the currentMaxVelovity if within offset
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }

        // lock right
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            // round to the currentMaxVelovity if within offset
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // get input
        bool forwardPressed = Input.GetKey(KeyCode.W);
        if (forwardPressed) { playerAnim.SetBool("isMoving", true); }
        bool leftPressed = Input.GetKey(KeyCode.A);
        if (leftPressed) { playerAnim.SetBool("isMoving", true); }
        bool rightPressed = Input.GetKey(KeyCode.D);
        if (rightPressed) { playerAnim.SetBool("isMoving", true); }
        bool backPressed = Input.GetKey(KeyCode.S);
        if (backPressed) { playerAnim.SetBool("isMoving", true); }
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        // set current max velocity
        float currentMaxVelocity = runPressed ? maximunRunVelocity : maximumWalkVelocity;

        // handle changes in velocity
        ChangeVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        LockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        // Set the parameters to our local variable values
        playerAnim.SetFloat(VelocityZHash, velocityZ);
        playerAnim.SetFloat(VelocityXHash, velocityX);

    }
}
