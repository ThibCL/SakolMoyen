using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seat : MonoBehaviour {
    public GameObject player;
    public Transform seat;
    public GameObject clientSeated;

    private void Start() {
        if (clientSeated) {
            GetSeat(clientSeated);
        }
    }

    void GetSeat(GameObject client) {
        clientSeated = client;

        var mov = clientSeated.GetComponent<ClientMovement>();
        mov.seat = this.gameObject;
        clientSeated.transform.position = seat.position;
    }

    private void OnMouseDown() {
        if (!clientSeated) {
            Debug.Log("Seat");

            var client = player.GetComponent<PlayerMovement>().client;
            player.GetComponent<PlayerMovement>().client = null;

            client.GetComponent<ClientMovement>().FollowUnfollow();

            GetSeat(client);
        }
    }
}
