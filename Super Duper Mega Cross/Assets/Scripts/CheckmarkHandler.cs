using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckmarkHandler : MonoBehaviour {

    // Bilden som ska ändras
    public Image checkmark;

	// Om väljaren har klickats ska bilden visas, annars görs den osynlig
	void Update () {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            checkmark.enabled = true;
        }
        else
        {
            checkmark.enabled = false;
        }
		
	}
}
