﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientMovement : MonoBehaviour {
    public Menu menu;
    public GameObject player;
    public NavMeshAgent agent;
    public GameObject seat;
    public float clickDistance = 10;
    public float waitDistance = 5;

    public List<string> characteristics;
    public int matchStart;
    public int actualMatch;

    private void Start() {
        agent.enabled = false;
    }

    void Update() {
        if (agent.enabled) {
            var waitPos = Vector3.ClampMagnitude(player.transform.position - transform.position, waitDistance);
            agent.SetDestination(player.transform.position - waitPos);
        }
    }

    public void FollowUnfollow() {
        agent.enabled = !agent.enabled;
    }

    private void OnMouseDown() {

        var dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < clickDistance && !menu.gameObject.activeSelf) {
            Debug.Log("Click");
            menu.Print(characteristics, matchStart, actualMatch);
            menu.gameObject.SetActive(true);
            menu.client = gameObject;
            menu.reticle.OnOffReticle();
        }
    }
}
