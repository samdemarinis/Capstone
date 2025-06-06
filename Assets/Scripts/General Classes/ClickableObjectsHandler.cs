using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickableObjectsHandler : MonoBehaviour
{ 
    public GeneralObject myObject;
    // Start is called before the first frame update
    public void Start()
    {
        GameObject displayObj = GameObject.FindGameObjectWithTag("DisplayText");
        TextMeshProUGUI tmp = displayObj.GetComponent<TextMeshProUGUI>();
        Color originalColor = tmp.color;
        originalColor.a = 0f; // Set alpha to 0
        tmp.color = originalColor;
        //panel.gameObject.SetActive(false);
    }
    public void OnMouseDown()
    {
        GameObject displayObj = GameObject.FindGameObjectWithTag("DisplayText");
        TextMeshProUGUI tmp = displayObj.GetComponent<TextMeshProUGUI>();
        Color originalColor = tmp.color;
        originalColor.a = 1f; 
        tmp.color = originalColor;

        StartCoroutine(HideTextAfterDelay(3f,tmp));
        //panel.gameObject.SetActive(true);
        tmp.text = myObject.name;
        if (myObject.inKnowledgeCheck){
            myObject.knowledgeLevel++;
            myObject.interaction_count++;
            myObject.inKnowledgeCheck = false;
        }
        else if (myObject.interaction_count == 1)
        {
            myObject.knowledgeLevel = 1;
            myObject.interaction_count++;
        }

        else if (myObject.interaction_count == 5)
        {
            if (!myObject.character_for_KC.kc_list.Contains(myObject))
            {
                myObject.character_for_KC.kc_list.Add(myObject);
            }

        }
        else if (myObject.interaction_count == 13)
        {

            if (!myObject.character_for_KC.kc_list.Contains(myObject))
            {
                myObject.character_for_KC.kc_list.Add(myObject);
            }

        }
        else
        {
            myObject.interaction_count++;
        }
    }
    public IEnumerator HideTextAfterDelay(float delay, TextMeshProUGUI tmp)
    {
        yield return new WaitForSeconds(delay);
        Color color = tmp.color;
        color.a = 0f;
        tmp.color = color;
    }
}
            



