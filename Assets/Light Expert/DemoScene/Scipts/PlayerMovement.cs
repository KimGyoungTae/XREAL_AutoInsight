using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Example Script - Not part of the actual LightMaster Libary
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controll;
    public float speed = 10f;

    private void Awake() {
        LightMaster.LightMasterConsole.SendWarning("Hey! If you like the Package, think about reviewing it!");
        LightMaster.LightMasterConsole.SendWarning("If you have any questions, write an email (look into the documentation)");
        LightMaster.LightMasterConsole.SendWarning("For changing Prefix and Colors of Debug.Log messages, select Main Camera, check out Light Manager, and press Console Variables");
    }

    private void Update() {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");

        //calculate the movement based on axis and speed
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controll.Move(move * speed * Time.deltaTime); // use character  controller to move
    }
}
