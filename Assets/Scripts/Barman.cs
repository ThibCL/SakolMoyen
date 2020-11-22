using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barman : MonoBehaviour {
    public BarmanMenu barmanMenu;
    public PlayerMovement player;


    private void OnMouseDown() {
        if (!barmanMenu.gameObject.activeSelf && !player.client) {
            Debug.Log("The barman is listening");
            barmanMenu.notYet.GetComponentInChildren<Text>().text = "Not Yet";
            barmanMenu.yes.SetActive(true);
            barmanMenu.gameObject.SetActive(true);
            barmanMenu.reticle.OnOffReticle();
        } else if (!barmanMenu.gameObject.activeSelf) {
            barmanMenu.yes.SetActive(false);
            barmanMenu.text.text = "You have to find a seat for the clien first";
            barmanMenu.notYet.GetComponentInChildren<Text>().text = "Ok";
            barmanMenu.gameObject.SetActive(true);
            barmanMenu.reticle.OnOffReticle();
        }

    }

}
