using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;

    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;

    public GameObject client;

    public GameObject reticle;

    void Update() {
        if (reticle.activeSelf) {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void GetFollowed(ClientMovement obj) {
        if (client) {
            Debug.Log("client");
            client.GetComponent<ClientMovement>().FollowUnfollow();
            obj.seat.GetComponent<Seat>().GetSeat(client);
        } else {
            Debug.Log("no Client");
            obj.seat.GetComponent<Seat>().clientSeated = null;
            obj.seat.GetComponent<Seat>().date.ComputeMatch();
            obj.seat = null;

        }


        client = obj.gameObject;
        client.GetComponent<ClientMovement>().FollowUnfollow();
    }
}
