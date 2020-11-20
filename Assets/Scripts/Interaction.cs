using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {
    public float clickDistance = 5;

    private void OnMouseDown() {
        var player = GameObject.Find("Player");
        var dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < clickDistance) {
            Debug.Log("Click");
        }
    }
}
