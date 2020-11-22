using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seat : MonoBehaviour {
    public GameObject player;
    public Transform seat;
    public GameObject clientSeated;
    public Seat date;

    /* private void Start() {
         if (clientSeated) {
             GetSeat(clientSeated);
             var cl = clientSeated.GetComponent<ClientMovement>();
             cl.matchStart = cl.actualMatch;
         }
     }*/

    private int NbCommun(List<string> l1, List<string> l2) {

        var res = 0;
        foreach (var elem1 in l1) {
            if (l2.Contains(elem1)) {
                res += 1;
            }
        }

        return res;

    }

    public void ComputeMatch() {

        var dateClientSeated = date.GetComponent<Seat>().clientSeated;
        var movClientSeated = clientSeated.GetComponent<ClientMovement>();
        if (dateClientSeated) {
            var movDateClientSeated = dateClientSeated.GetComponent<ClientMovement>();

            var commun = NbCommun(movClientSeated.characteristics, movDateClientSeated.characteristics);
            movClientSeated.actualMatch = commun;
            movDateClientSeated.actualMatch = commun;
        } else {
            movClientSeated.actualMatch = 0;
        }

    }

    public void GetSeat(GameObject client) {
        if (clientSeated) {
            clientSeated.GetComponent<ClientMovement>().seat = null;
        }

        clientSeated = client;
        var mov = clientSeated.GetComponent<ClientMovement>();
        mov.seat = this.gameObject;
        clientSeated.transform.position = seat.position;
        ComputeMatch();
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
