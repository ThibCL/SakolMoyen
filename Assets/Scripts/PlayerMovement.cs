using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;

    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;

    public GameObject client;

    void Update() {

        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void GetFollowed(GameObject obj) {
        if (client) {
            client.GetComponent<ClientMovement>().FollowUnfollow();

            var tmpPos = client.transform.position;
            client.transform.position = obj.transform.position;
            obj.transform.position = tmpPos;

        }

        client = obj;
        client.GetComponent<ClientMovement>().FollowUnfollow();
    }
}
