using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientMovement : MonoBehaviour {
    public Transform player;
    public NavMeshAgent agent;
    public float waitDistance;

    public bool follow = false;

    void Update() {
        if (follow) {
            var waitPos = Vector3.ClampMagnitude(player.position - transform.position, waitDistance);
            agent.SetDestination(player.position - waitPos);
        }
    }

    private void OnMouseDown() {
        Debug.Log("Click");
        follow = !follow;
    }
}
