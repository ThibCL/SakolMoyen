using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarmanMenu : MonoBehaviour {

    public Reticle reticle;
    public GameObject clientsGroup;
    public TextMeshProUGUI text;
    public GameObject yes;
    public GameObject notYet;

    public void Yes() {
        int satisfied = 0;
        int notSatisfied = 0;

        var clients = clientsGroup.GetComponentsInChildren<ClientMovement>();
        foreach (var client in clients) {
            if (client.actualMatch > client.matchStart) {
                satisfied += 1;
            } else if (client.actualMatch < client.matchStart) {
                notSatisfied += 1;
            }
        }

        text.text = satisfied + " clients benifited from this change \n" + notSatisfied + " clients lost from this change";
        yes.SetActive(false);
        notYet.SetActive(false);
    }

    public void NotYet() {
        gameObject.SetActive(false);
        reticle.OnOffReticle();
    }
}
