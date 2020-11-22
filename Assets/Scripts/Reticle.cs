using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {
    public void OnOffReticle() {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf) {
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
