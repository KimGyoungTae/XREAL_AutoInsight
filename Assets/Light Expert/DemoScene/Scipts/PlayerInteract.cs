using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LightMaster;
// Example Script - Not part of the actual LightMaster Libary
public class PlayerInteract : MonoBehaviour {
    /**
     * This is an example how you can use LightSwitches, LightActions, or self written Scripts
     * There are plenty other ways to do something like this.
     */

    public Text CursorText; // text of the cursor (the + sign in the middle of the screen)
    public float maxInteractDistance;
    bool interactableInRange;

    private void Update() {
        RaycastHit r;

        // shoots a ray forward, to check if the player looks at something
        if(Physics.Raycast(transform.position, transform.forward, out r, maxInteractDistance)) {
            //if the hitted transform has a LightAction
            if(r.transform.TryGetComponent(out LightAction la)) {
                //if the hit. tr. DOESNT have a LightSwitchController
                if(!r.transform.TryGetComponent(out LightSwitchController lsc)) {
                    interactableInRange = true;
                    if(Input.GetKeyDown(KeyCode.E)) { // if Player presses 'E'
                        la.PerformAction(); // perform the action
                    }
                }
            }

            //if the hitted transform has a LightSwitchController
            if(r.transform.TryGetComponent(out LightSwitchController lightSwitch)) {
                interactableInRange = true;
                if(Input.GetKeyDown(KeyCode.E)) {
                    lightSwitch.ToggleSwitch(); // toggle the switch
                }
            }

            //if the hitted transform has a ClosetController
            if(r.transform.TryGetComponent(out ClosetController cc)) {
                interactableInRange = true;
                if(Input.GetKeyDown(KeyCode.E)) {
                    cc.InteractWithCloset(); // interact with the closet
                }
            }

        } 
        if(interactableInRange) { // if the player looks at a interactable object
            CursorText.color = Color.green; //change color to green
            interactableInRange = false;
        } else {
            CursorText.color = Color.black; // set color to black (normal)
        }
    }
}
