using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCycleAnimationController2 : MonoBehaviour
{
    [Header("Player Type")]
    [SerializeField] private string PlayerType;

    [Header("Player Aimator")]
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Rigidbody playerRigid;

    [Header("Character Rigs")]
    [SerializeField] private GameObject rig2;
    [SerializeField] private GameObject rig3;
    // Update is called once per frame
    void Update()
    {
        if (playerAnim != null)
        {
            if (PlayerType == "NAI")
            {
                if (Bike_controller.currentForwardSpeed == 0f)
                {
                    playerAnim.SetTrigger("cycle_idle");
                    playerAnim.ResetTrigger("cycle_moving_forward");
                    rig2.GetComponent<Rig>().weight = Mathf.MoveTowards(rig2.GetComponent<Rig>().weight, 0f, 2 * Time.deltaTime);
                    rig3.GetComponent<Rig>().weight = Mathf.MoveTowards(rig3.GetComponent<Rig>().weight, 1f, 2 * Time.deltaTime);
                }
                else
                {
                    playerAnim.ResetTrigger("cycle_idle");
                    playerAnim.SetTrigger("cycle_moving_forward");
                    rig2.GetComponent<Rig>().weight = Mathf.MoveTowards(rig2.GetComponent<Rig>().weight, 1f, 2 * Time.deltaTime);
                    rig3.GetComponent<Rig>().weight = Mathf.MoveTowards(rig3.GetComponent<Rig>().weight, 0f, 2 * Time.deltaTime);
                }
            }
            else
            {
                if (AI_Bike_controller3.currentForwardSpeed == 0f)
                {
                    playerAnim.SetTrigger("cycle_idle");
                    playerAnim.ResetTrigger("cycle_moving_forward");
                    rig2.GetComponent<Rig>().weight = Mathf.MoveTowards(rig2.GetComponent<Rig>().weight, 0f, 2 * Time.deltaTime);
                    rig3.GetComponent<Rig>().weight = Mathf.MoveTowards(rig3.GetComponent<Rig>().weight, 1f, 2 * Time.deltaTime);
                }
                else
                {
                    playerAnim.ResetTrigger("cycle_idle");
                    playerAnim.SetTrigger("cycle_moving_forward");
                    rig2.GetComponent<Rig>().weight = Mathf.MoveTowards(rig2.GetComponent<Rig>().weight, 1f, 2 * Time.deltaTime);
                    rig3.GetComponent<Rig>().weight = Mathf.MoveTowards(rig3.GetComponent<Rig>().weight, 0f, 2 * Time.deltaTime);
                }
            }
        }
    }
}
