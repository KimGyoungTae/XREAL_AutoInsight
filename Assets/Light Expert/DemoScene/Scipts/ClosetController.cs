using System.Collections;
using UnityEngine;
using LightMaster;

// Example Script - Not part of the actual LightMaster Libary
public class ClosetController : MonoBehaviour {
    private Animator _closetAnimator;
    public LightAction _onInteractAction;

    void Start() {
        _closetAnimator = GetComponent<Animator>();    
    }

    private bool _isOpen = false;
    private bool _canInteract = true;
    public void InteractWithCloset() {
        if(!_canInteract)
            return;

        if(_isOpen) {
            _closetAnimator.SetTrigger("CloseCloset"); // close Animation
        } else {
            _closetAnimator.SetTrigger("OpenCloset"); // open Animation
        }
        _isOpen = !_isOpen; // toggle open value

        _onInteractAction.PerformAction(); // perform the LightAction

        StartCoroutine(Timer());
    }

    //timer to wait for the animation to got played
    private IEnumerator Timer() {
        _canInteract = false;
        yield return new WaitForSeconds(1);
        _canInteract = true;
    }
}
