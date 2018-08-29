using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class atrapalo : MonoBehaviour {
    public int numero_tiro,numero,pokemon_restantes;
    public string pokemon_nombre;
    public Button pokemon1, pokemon2, pokemon3;
    public Image pokeball1, pokeball2, pokeball3, pokeball4, pokeball5, pokeball6;
    public List<string> pokemons = new List<string>();
   

    // Use this for initialization
    void Start () {
        numero_tiro = 0;
        pokemon_restantes = 10;
        pokemons.Add("squirtle");
        pokemons.Add("tauros");
        pokemons.Add("charmander");
        pokemons.Add("beedrill");
        pokemons.Add("bulbasaur");
        pokemons.Add("onix");
        pokemons.Add("butterfree");
        pokemons.Add("caterpie");
        pokemons.Add("muk");
        pokemons.Add("bellsprout");
        pokemons.Add("caterpie");


        pokemon1 = GameObject.Find("Pokemon_1").GetComponent<Button>();
        pokemon2 = GameObject.Find("Pokemon_2").GetComponent<Button>();
        pokemon3 = GameObject.Find("Pokemon_3").GetComponent<Button>();

        numero = Random.Range(0, pokemon_restantes);
        Debug.Log(numero);
        pokemon1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/"+pokemons[numero]);
        pokemons.RemoveAt(numero);
        pokemon_restantes--;
      

        numero = Random.Range(0, pokemon_restantes);
        pokemon2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + pokemons[numero]);
        pokemons.RemoveAt(numero);
        pokemon_restantes--;


        numero = Random.Range(0, pokemon_restantes);
        pokemon3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + pokemons[numero]);
        pokemons.RemoveAt(numero);
        pokemon_restantes--;



    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnClick()
    {
        numero_tiro += 1;

    }




    public void OnClickPokemon(Image pokeball)
    {

        if (pokeball.name.Contains(numero_tiro.ToString()))
        {
            pokemon_nombre = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name;
            pokemon_nombre = "Sprites/" + pokemon_nombre + "_face";
            pokeball.sprite = Resources.Load<Sprite>(pokemon_nombre);

            if (pokemon_restantes >= 0)
            {

                numero = Random.Range(0, pokemon_restantes);
                switch(EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name)
                {
                    case "Pokemon_1":
                        pokemon1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + pokemons[numero]);
                        break;
                    case "Pokemon_2":
                        pokemon2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + pokemons[numero]);
                        break;
                    case "Pokemon_3":
                        pokemon3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + pokemons[numero]);
                        break;
                }
                pokemons.RemoveAt(numero);

                pokemon_restantes--;
            }
        }
              
    }


    public void OnClickOut(Image pokeball)
    {

 

        if ( pokeball.name.Contains(numero_tiro.ToString()))
       {
            pokeball.sprite = Resources.Load<Sprite>("Sprites/pokeball_bn");
       }




    }




}
