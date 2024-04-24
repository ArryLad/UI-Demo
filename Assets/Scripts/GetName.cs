using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GetName : MonoBehaviour
{
    private TextMeshProUGUI tabName;

    // Start is called before the first frame update
    private void Start()
    {
        // Find the parent object ('Tab')
        Transform parent = transform.parent;
 
        if (parent != null)
        {
            // Get the TextMeshPro component attached to this object
            tabName = GetComponent<TextMeshProUGUI>();

            // Set the text of the TextMeshPro component to the name of the parent object
            tabName.text = parent.gameObject.name;
        }
        else
        {
            Debug.LogError("No parent object found for " + gameObject.name);
        }
    }
}


