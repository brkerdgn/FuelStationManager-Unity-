using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public FloatingJoystick FloatingJoystick;
    public Rigidbody rb;
    public Animator anim;

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * FloatingJoystick.Vertical + Vector3.right * FloatingJoystick.Horizontal;
        rb.velocity = direction * speed * Time.deltaTime;

            if (FloatingJoystick.Horizontal != 0 || FloatingJoystick.Vertical != 0)
            {
            anim.SetBool("isRunning", true);
            transform.rotation = Quaternion.LookRotation(rb.velocity); 
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
    }
       
}

