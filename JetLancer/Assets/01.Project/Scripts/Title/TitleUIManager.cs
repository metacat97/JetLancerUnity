using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TitleUIManager : MonoBehaviour
{
    public Text[] buttonText;
    public Transform BtnSprite;
    private int test;
    void Start()
    {
        test = 0;
        Vector3 destination = buttonText[test].transform.position;
        BtnSprite.transform.position = Vector3.MoveTowards(BtnSprite.transform.position, destination, 1);
    }

   
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");

        //(yInput > 0) //(Input.GetKeyDown(KeyCode.W))
        //BtnSprite.transform.Translate(new Vector3 (0f,-buttonText[test].transform.position.y));
        //(yInput < 0)//(Input.GetKeyDown(KeyCode.S))
        //BtnSprite.transform.Translate(new Vector3(0f, buttonText[test].transform.position.y));
        //buttonText[0].transform.position

        Vector3 destination = buttonText[test].transform.position;

        if (Input.GetKeyDown(KeyCode.S) && test >= 0 && test < 2)
        {
            test += 1;
            destination = buttonText[test].transform.position;
            BtnSprite.transform.position = Vector3.MoveTowards(BtnSprite.transform.position, destination, 1);
            Debug.Log(test);
        }
        if (Input.GetKeyDown(KeyCode.W) && test <= 2&& test >0)
        {
            test -= 1;
            destination = buttonText[test].transform.position;
            BtnSprite.transform.position = Vector3.MoveTowards(BtnSprite.transform.position, destination, 1);
            Debug.Log(test);
        }
        if (Input.GetKeyDown(KeyCode.Return)  && test == 0)
        {
            SceneManager.LoadScene("CharacterSelect");
        }
        else if (Input.GetKeyDown(KeyCode.Return)  && test == 2)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    } 
}
