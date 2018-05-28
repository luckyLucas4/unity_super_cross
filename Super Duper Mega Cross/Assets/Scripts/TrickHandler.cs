using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickHandler : MonoBehaviour {

    //initialiserar variablerna orginal, trick, trick2 och temp
    
    //De tre första variablerna är public för att de ska kunna användas i Unity
    public Sprite orginal;
    public Sprite trick;
    public Sprite trick2;
    //Variablen "temp" är private eftersom den bara ska användas inom denna kod och inte inom Unity
    private Sprite temp;



    //Använder denna för initiering
    void Start () {
        temp = orginal; //När spelet laddas ut ska temp vara lika med original.  
                        //Original är bunden till spriten/bilden där hunden sitter still.
                        //Det hela gör så att den vanliga spriten/bilden används(den bild där hunden sitter still).
    }

    // Detta uppdateras varje frame/bild
    void Update () {

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.K))
        {
            temp = trick; //Om "Z", "Space" eller "K" trycks ner ändras temp till att vara lika med trick
                          //Då byts den sprite/bild där hunden sitter still ut mot den sprite/bild där hunden gör det första tricket 
        }
        else if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.L))
        {
            temp = trick2; //Om "X", "Space" eller "L" trycks ner ändras temp till att vara lika med trick
                           //Då byts den sprite/bild där hunden sitter still ut mot den sprite/bild där hunden gör det andra tricket

            //Trick 2 är det trick då motorcykeln blir till en banan. Jag var då tvungen att dölja hjulen då detta trick utförs.
            //Då använder jag mig av SpriteRenderer och gör så att hjulens aktivering ska vara falskt och därmed döljs hjulen
            SpriteRenderer[] wheels = gameObject.GetComponentsInChildren<SpriteRenderer>();
            wheels[1].enabled = false;
            wheels[2].enabled = false;
        }
        else //Om ingen av knapparna ovan trycks ner sker det nedan
        {
            temp = orginal;  //Denna rad gör så att den vanliga spriten/bilden där hunden sitter still återigen visas 

            //Eftersom hjulen ska visas när allt är i sin ursprungliga position använder jag mig av SpriteRenderer igen och sätter hjulens aktivering till sann
            SpriteRenderer[] ts = gameObject.GetComponentsInChildren<SpriteRenderer>();
            ts[1].enabled = true;
            ts[2].enabled = true;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = temp;
	}
}
