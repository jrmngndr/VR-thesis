using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //rewrite input system
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = ScenarioData.playerController.transform.right * x + ScenarioData.playerController.transform.forward * z;
        ScenarioData.playerController.Move(ScenarioData.playerSpeed * Time.deltaTime * direction);
    }
}
