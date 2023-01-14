using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingToggle : MonoBehaviour
{
    public GameObject switchOn, switchOff;
    // Start is called before the first frame update
   public void OnChangeValue()
   {
          bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
          if(onoffSwitch)
          {
                switchOn.SetActive(true);
                switchOff.SetActive(false);
               
          }
          else
          {
                switchOn.SetActive(false);
                switchOff.SetActive(true);
          }
   }
}
