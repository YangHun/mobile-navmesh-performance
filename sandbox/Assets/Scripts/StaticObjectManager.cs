using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjectManager : MonoBehaviour {

    //--------------------------------------------------------------------------------//
    //-----------------------------------FIELD----------------------------------------//
    //--------------------------------------------------------------------------------//
    //------------------- Inspector ------------------//
    [SerializeField]
    Texture2D targetTexture;

    //------------------- public ------------------//


    //------------------- protected ------------------//


    //------------------- private ------------------//


    //--------------------------------------------------------------------------------//
    //------------------------------------PROPERTY------------------------------------//
    //--------------------------------------------------------------------------------//


    //--------------------------------------------------------------------------------//
    //------------------------------------METHOD--------------------------------------//
    //--------------------------------------------------------------------------------//


    // Use this for initialization
    void Start () {
        this.gameObject.isStatic = true;

        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.isStatic = true;
        }

        StaticBatchingUtility.Combine(this.gameObject);

        StartCoroutine (DynamicChangeStatic());
    }
    

    IEnumerator DynamicChangeStatic () {

        for (int i = 0 ; i < 5; i++) {
            
            Debug.Log ("wait seconds... "+ i);
            yield return new WaitForSeconds (1.0f);           
        }

        for (int i = 0; i < transform.childCount; i++) {
            if (i%2 ==0)
                transform.GetChild(i).gameObject.SetActive(false);
        }
        

        yield return new WaitForSeconds (5.0f);
        Debug.Log ("change static objects to non-static");

        this.gameObject.isStatic = false;
        yield return null;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.isStatic = false;
            yield return null;
        }
    }


    // Update is called once per frame
    void Update () {
        
    }


    //───────────────────────────────────────────────────────────────────────────────────────
    
}
