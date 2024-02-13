using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCycleAnimationController1 : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;

    [SerializeField] private bool cycling_forward,idle_handle_rotate_left,idle_handle_rotate_right,
        cycling_left, cycling_right;
    // Update is called once per frame
    void Update()
    {
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
                /*playerAnim.ResetTrigger("cycling_forward");*/

            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                cycling_forward = false;
                cycling_right = true;
                playerAnim.SetTrigger("cycling_right");
               /* playerAnim.ResetTrigger("cycling_forward");*/
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
       
    }
}
