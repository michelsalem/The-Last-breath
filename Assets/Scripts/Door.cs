using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractiveObject
{
    [SerializeField]
    private float yPostionOffset= 1f;
    [SerializeField]
    private bool savePostion= false;
    [SerializeField]
    private string SceneName;
    public override void action()
    {
        if (savePostion)
        {
            PlayerPrefs.SetInt(PlayerConstns.RESTART_POSITION_AVALAIBLE,1);
         PlayerPrefs.SetFloat(PlayerConstns.X_RESTART_POSITION, gameObject.transform.position.x);
        PlayerPrefs.SetFloat(PlayerConstns.Y_RESTART_POSITION, gameObject.transform.position.y- yPostionOffset);   
        }
        

        SceneManager.LoadScene(SceneName);
       
    }
  
    }



