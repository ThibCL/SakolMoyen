using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public Reticle reticle;
    public GameObject tablesGroup;
    public GameObject clientsGroup;

    public System.Tuple<List<string>, List<string>>[] setups = {
        System.Tuple.Create(new List<string> { "Videogames","Drawing","Movies","Travels","Animals" }, new List<string> { "Drawing","Friends","Sports","Videogames","Books" }),
        System.Tuple.Create( new List<string> { "Foods","Animals","Travels","Friens","Drawing" },  new List<string> { "Working","Animals","Videogames","Sports","Foods" }),
        System.Tuple.Create( new List<string> { "Books","Foods","Videogames","Friends","Drawing" },  new List<string> { "Working","Movies","Friends","Videogames","Travels" }),
        System.Tuple.Create( new List<string> { "Sports","Books","Working","Foods","Drawing" },  new List<string> { "Movies","Travels","Animals","Sports","Working" }),
        System.Tuple.Create( new List<string> { "Sports","Books","Travels","Friends","Animals" },  new List<string> { "Working","Foods","Sports","Travels","Movies" })
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


            chairs[1].date = chairs[0];
            chairs[1].GetSeat(c2.gameObject);
            c1.matchStart = c1.actualMatch;
            c2.matchStart = c2.actualMatch;

        }

    }

    public void Play() {
        reticle.OnOffReticle();
        gameObject.SetActive(false);
    }
}
