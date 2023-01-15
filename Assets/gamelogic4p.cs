using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gamelogic4p : MonoBehaviour
{
    public int count =3;
    public void decrement()
    {
        count--;
    }

    private void Start(){
    }
    private void Update()
    {
        if(count<=0){
            SceneManager.LoadScene("winner1");
        }
    }
    
}
    