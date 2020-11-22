using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientMovement : MonoBehaviour {
    public Animator anim;


    public string playerName;
    public Menu menu;
    public GameObject player;
    public NavMeshAgent agent;
    public GameObject seat;
    public float clickDistance = 10;
    public float waitDistance = 5;
    public float waitPosDist = 3;

    public List<string> characteristics;
    public int matchStart;
    public int actualMatch;

    private void Start() {
        agent.enabled = false;
        Debug.Log("Start " + anim.name);
    }

    void Update() {
        if (agent.enabled) {
            anim.SetBool("Sit", !agent.enabled);
            var waitPos = Vector3.ClampMagnitude(player.transform.position - transform.position, waitDistance);
            agent.SetDestination(player.transform.position - waitPos);
            if (agent.remainingDistance < waitPosDist) {
                anim.SetBool("Wait", true);
            } else {
                anim.SetBool("Wait", false);
            }
        } else {
            anim.SetBool("Sit", !agent.enabled);
            anim.SetInteger("Match", actualMatch - matchStart);
        }
    }

    public void FollowUnfollow() {
        agent.enabled = !agent.enabled;
    }

    private void OnMouseDown() {

        var dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < clickDistance && !menu.gameObject.activeSelf) {
            Debug.Log("Click");
            menu.Print(characteristics, matchStart, actualMatch, playerName);
            menu.gameObject.SetActive(true);
            menu.client = gameObject;
            menu.reticle.OnOffReticle();
        }
    }
}
