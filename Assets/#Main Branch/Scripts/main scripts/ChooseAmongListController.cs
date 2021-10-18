using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAmongListController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TMPro.TextMeshProUGUI> all = new List<TMPro.TextMeshProUGUI>();
    public TMPro.TextMeshProUGUI currentChosen;
        public Color chosenColor, normalColor;
 
    public void Choose(Button caller )
    {
        if(caller.GetComponent<TMPro.TextMeshProUGUI>())
        if(all.Contains( caller.GetComponent<TMPro.TextMeshProUGUI>()))
        {
                if(currentChosen)
                currentChosen.color=normalColor;
                foreach (TMPro.TextMeshProUGUI t in all)
                { 
                    t.color = normalColor;
                }
                    currentChosen = caller.GetComponent<TMPro.TextMeshProUGUI>();
                currentChosen.color = chosenColor;
        }
    }

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        foreach(TMPro.TextMeshProUGUI t in all)
        {
            if(t.GetComponent<Button>())
            {
                //t.GetComponent<Button>().onClick.AddListener(TaskOnClick);
                t.GetComponent<Button>().onClick.AddListener(delegate { Choose(t.GetComponent<Button>()); });
            }

        }
       
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

}
