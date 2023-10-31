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

            Debug.Log("UpArrow = "+Up_Arrow+" , DownArrow = "+Down_Arrow + " , LeftArrow = " + Left_Arrow + " , RightArrow = " +Right_Arrow);
            Up_Arrow = false; Down_Arrow = false; Left_Arrow = false; Right_Arrow = false;
    }
       
    /*{ 
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            cycling_forward = false;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                idle_handle_rotate_left = true;
                playerAnim.SetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.ResetTrigger("cycle_idle");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                idle_handle_rotate_right = true;
                playerAnim.SetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.ResetTrigger("cycle_idle");
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_left");
                playerAnim.SetTrigger("cycle_idle");
                idle_handle_rotate_left = false;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAnim.ResetTrigger("cycle_idle_handle_rotate_right");
                playerAnim.SetTrigger("cycle_idle");
                idle_handle_rotate_right = false;
            }
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            cycling_forward = true;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                cycling_forward = false;
                cycling_left = true;
                playerAnim.SetTrigger("cycling_left");
                *//*playerAnim.ResetTrigger("cycling_forward");*//*

            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                cycling_forward = false;
                cycling_right = true;
                playerAnim.SetTrigger("cycling_right");
               *//* playerAnim.ResetTrigger("cycling_forward");*//*
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAnim.ResetTrigger("cycling_left");
                playerAnim.SetTrigger("cycling_forward");
                cycling_left = false;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAnim.ResetTrigger("cycling_right");
                playerAnim.SetTrigger("cycling_forward");
                cycling_right = false;
            }
        }

        if (cycling_forward == true)
        {
            playerAnim.SetTrigger("cycling_forward");
            playerAnim.ResetTrigger("cycle_idle");
        }
        if (cycling_forward == false && idle_handle_rotate_left == false && idle_handle_rotate_right == false)
        {
            playerAnim.ResetTrigger("cycling_forward");
            playerAnim.SetTrigger("cycle_idle");
            Debug.Log("idle jackpot");
        }
       
    }*/
}
