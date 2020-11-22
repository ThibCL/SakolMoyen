using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public Reticle reticle;
    public GameObject tablesGroup;
    public GameObject clientsGroup;

    public System.Tuple<List<string>, List<string>>[] setups = {
        System.Tuple.Create(new List<string> { "Sport","Fashion" }, new List<string> { "Art","TV","Money" }),
        System.Tuple.Create( new List<string> { "Drug","Sexe","Money","Alcool" },  new List<string> { "Sexe" }),
        System.Tuple.Create( new List<string> { "Fashion","Art","Drug" },  new List<string> { "Money","Sport" }),
        System.Tuple.Create( new List<string> { "TV","Money" },  new List<string> { "Fashion","Art","Drug" }),
        System.Tuple.Create( new List<string> { "Art","Fashion" },  new List<string> { "Sexe","Alcool" })
    };

    private void Start() {
        var clients = clientsGroup.GetComponentsInChildren<ClientMovement>();
        var tables = tablesGroup.GetComponentsInChildren<Table>();

        for (var i = 0; i < setups.Length; i++) {
            var c1 = clients[2 * i];
            var c2 = clients[2 * i + 1];

            c1.characteristics = setups[i].Item1;
            c2.characteristics = setups[i].Item2;

            var chairs = tables[i].GetComponentsInChildren<Seat>();

            chairs[0].date = chairs[1];
            chairs[0].GetSeat(c1.gameObject);
            c1.matchStart = c1.actualMatch;


            chairs[1].date = chairs[0];
            chairs[1].GetSeat(c2.gameObject);
            c2.matchStart = c2.actualMatch;

        }

    }

    public void Play() {
        reticle.OnOffReticle();
        gameObject.SetActive(false);
    }
}
