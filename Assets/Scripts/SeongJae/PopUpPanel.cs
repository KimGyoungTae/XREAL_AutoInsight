using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPanel : MonoBehaviour
{
    public void OpenPopUp() => gameObject.SetActive(true);
    public void ClosePopUp() => gameObject.SetActive(false);
}
