using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LightMaster;
// Example Script - Not part of the actual LightMaster Libary
public class PlayerLook : MonoBehaviour {
    public float Sensitivity = 100;
    public Transform Player; // trasform of the player
    public Transform PlayerGlasses; // transform of the players head/glassses/eyes
    float xRot = 0;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked; // lock/hide cursor
    }

    private bool Active = true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // allows the player/user to activate the mouse in play mode
            Active = !Active;

        if(!Active)
            return;

        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        //set the players rotation and turn him around Y-Axis
        Player.Rotate(Vector3.up * mouseX);
        // set the glasses rotation.x
        PlayerGlasses.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}
