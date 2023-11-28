using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCycleAnimationController2 : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Rigidbody playerRigid;

    [SerializeField] private bool Up_Arrow=false,Down_Arrow = false, Left_Arrow = false, Right_Arrow = false;
    // Update is called once per frame
    void Update()
    {
        if (playerAnim != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Up_Arrow = true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Down_Arrow = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Left_Arrow = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Right_Arrow = true;
            }


            if (Up_Arrow == false && Down_Arrow == false && Left_Arrow == false && Right_Arrow == false)
            {
                playerAnim.SetTrigger("cycle_idle");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.ResetTrigger("cycling_forward");
                playerAnim.ResetTrigger("cycling_left");
                playerAnim.ResetTrigger("cycling_right");
            }
            if (Up_Arrow == false && Down_Arrow == false && Left_Arrow == false && Right_Arrow == true)
            {
                playerAnim.ResetTrigger("cycle_idle");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.SetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.ResetTrigger("cycling_forward");
                playerAnim.ResetTrigger("cycling_left");
                playerAnim.ResetTrigger("cycling_right");
            }
            if (Up_Arrow == false && Down_Arrow == false && Left_Arrow == true && Right_Arrow == false)
            {
                playerAnim.ResetTrigger("cycle_idle");
                playerAnim.SetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.ResetTrigger("cycling_forward");
                playerAnim.ResetTrigger("cycling_left");
                playerAnim.ResetTrigger("cycling_right");
            }
            
            
            if (Up_Arrow == true && Down_Arrow == false && Left_Arrow == false && Right_Arrow == false)
            {
                playerAnim.ResetTrigger("cycle_idle");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.SetTrigger("cycling_forward");
                playerAnim.ResetTrigger("cycling_left");
                playerAnim.ResetTrigger("cycling_right");
            }
            if (Up_Arrow == true && Down_Arrow == false && Left_Arrow == false && Right_Arrow == true)
            {
                playerAnim.ResetTrigger("cycle_idle");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.ResetTrigger("cycling_forward");
                playerAnim.ResetTrigger("cycling_left");
                playerAnim.SetTrigger("cycling_right");
            }
            if (Up_Arrow == true && Down_Arrow == false && Left_Arrow == true && Right_Arrow == false)
            {
                playerAnim.ResetTrigger("cycle_idle");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.ResetTrigger("cycling_forward");
                playerAnim.SetTrigger("cycling_left");
                playerAnim.ResetTrigger("cycling_right");
            }

            
        }
            Up_Arrow = false; Down_Arrow = false; Left_Arrow = false; Right_Arrow = false;
    }
}
