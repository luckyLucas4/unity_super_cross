using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickHandlerBlåMotorcykel : MonoBehaviour
{
    //initialiserar variablerna orginal, trick, trick2 och temp

    //De tre första variablerna är public för att de ska kunna användas i Unity
    public Sprite orginal;
    public Sprite trick;
    public Sprite trick2;
    //Variablen "temp" är private eftersom den bara ska användas inom denna kod och inte inom Unity
    private Sprite temp;



    //Använder denna för initiering
    void Start()
    {
        temp = orginal; //När spelet laddas ut ska temp vara lika med original.  
                        //Original är bunden till spriten där hunden sitter still.
                        //Det hela gör så att den vanliga spriten används(den bild där hunden sitter still).
    }

    // Detta uppdateras varje frame/bild
    void Update()
    {

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.K))
        {
            temp = trick; //Om "Z", "Space" eller "K" trycks ner ändras temp till att vara lika med trick
                          //Då byts den sprite där gubben sitter still ut mot den sprite där gubben gör det första tricket 
        }
        else if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.L))
        {
            temp = trick2; //Om "X", "Space" eller "L" trycks ner ändras temp till att vara lika med trick
                           //Då byts den sprite där gubben sitter still ut mot den sprite där gubben gör det andra tricket
        }
        else //Om ingen av knapparna ovan trycks ner sker det nedan
        {
            temp = orginal; //Denna rad gör så att den vanliga spriten där gubben sitter still visas
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = temp;
    }
}