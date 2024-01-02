using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Example Script - Not part of the actual LightMaster Libary
public class ToggleMonitorMaterial : MonoBehaviour
{
    // mat1 = turned on material
    // mat2 = turned off material
    public Material mat1, mat2;
    public void TurnMonitorOn() {
        Material[] currentlyAssignedMaterials = GetComponent<Renderer>().materials; // get materials
        currentlyAssignedMaterials[2] = mat1; // change material
        GetComponent<Renderer>().materials = currentlyAssignedMaterials; // asign new materials
    } 
    public void TurnMonitorOff() {
        Material[] currentlyAssignedMaterials = GetComponent<Renderer>().materials;
        currentlyAssignedMaterials[2] = mat2;
        GetComponent<Renderer>().materials = currentlyAssignedMaterials;
    }
}
