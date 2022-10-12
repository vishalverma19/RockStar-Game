using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myscoreText;
    private int scoreNum;
    public GameObject completeLevelUI;
    public GameObject scoreUI;

    // var gos : GameObject[];
    // gos = GameObject.FindGameObjectsWithTag("Collectables");
    private int collectablesCount;
    void Awake(){
        collectablesCount=GameObject.FindGameObjectsWithTag("Collectables").Length;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreNum=0;
        myscoreText.text=""+scoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Collectables){
        if(Collectables.tag=="Collectables"){
            collectablesCount-=1;
            scoreNum+=1;
            Destroy(Collectables.gameObject);
            myscoreText.text=""+scoreNum;
            if(collectablesCount==0){
                CompleteLevel();
                DestroyWithTag("Player");
            }
        }
    }

    public void CompleteLevel(){
        completeLevelUI.SetActive(true);
        scoreUI.SetActive(false);
    }

    void DestroyWithTag (string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy (oneObject);
    }
}
