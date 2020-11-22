using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Reticle reticle;
    public GameObject client;
    public GameObject player;
    public TextMeshProUGUI text;
    public Text nameT;
    public GameObject swapButton;

    private void Update() {
        swapButton.SetActive(client.GetComponent<ClientMovement>().seat != null);
    }

    public void Print(List<string> characs, int startMatch, int actualMatch, string name) {

        nameT.text = name;
        text.text += "Before: " + startMatch + " Now: " + actualMatch + " \n \n";

        foreach (var charac in characs) {
            text.text += charac;
            text.text += " \n";
        }

    }

    public void Clear() {
        text.text = "";
    }

    public void Swap() {
        Debug.Log("Swap");
        player.GetComponent<PlayerMovement>().GetFollowed(client.GetComponent<ClientMovement>());
        gameObject.SetActive(false);
        reticle.OnOffReticle();
        Clear();
    }

    public void Ok() {
        Debug.Log("OK");
        gameObject.SetActive(false);
        reticle.OnOffReticle();
        Clear();
    }

}
