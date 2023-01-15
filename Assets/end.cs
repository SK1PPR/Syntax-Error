using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    public int count = 3, sum = 10;
    public GameObject check1, check2, check3, check4;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(check1.activeSelf)
        {
            count --;
            check1.SetActive(true);
            sum -= 1;
        }
        if(check2.activeSelf)
        {
            count --;
            check2.SetActive(true);
            sum -= 2;
        }

        if(check3.activeSelf)
        {
            count --;
            check3.SetActive(true);
            sum-= 3;

        }if(check4.activeSelf)
        {
            count --;
            check4.SetActive(true);
            sum -= 4;
        }
        if(count == 0)
        {
            if(sum == 1){
                SceneManager.LoadScene("winner1");
            }
                
            
            if(sum == 2){
                SceneManager.LoadScene("winner2");
        
             
            }
            if(sum == 3){
                
                SceneManager.LoadScene("winner3");
        
                
            }
            if(sum == 4){
                SceneManager.LoadScene("winner4");
        
                
            }
        }
    }
}
//