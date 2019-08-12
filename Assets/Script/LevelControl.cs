using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public Button level02But, level03But, level04But, level05But;
    public int levelPassed;
    // Start is called before the first frame update
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02But.interactable = false;
        level03But.interactable = false;
        level04But.interactable = false;
        level05But.interactable = false;

        switch(levelPassed)
        {
            case 1:
                level02But.interactable = true;
                level03But.interactable = false;
                level04But.interactable = false;
                level05But.interactable = false;
                break;
            case 2:
                level02But.interactable = true;
                level03But.interactable = true;
                level04But.interactable = false;
                level05But.interactable = false;
                break;
            case 3:
                level02But.interactable = true;
                level03But.interactable = true;
                level04But.interactable = true;
                level05But.interactable = false;
                break;

            case 4:
                level02But.interactable = true;
                level03But.interactable = true;
                level04But.interactable = true;
                level05But.interactable = true;
                break;
        }
    }

    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void resetPlayerPrefs()
    {
        level02But.interactable = false;
        level03But.interactable = false;
        level04But.interactable = false;
        level05But.interactable = false;
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
