using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CookApps {

	public class LobbyObjectPool : MonoBehaviour {

		//--------------------------------------------------------------------------------//
        //-----------------------------------FIELD----------------------------------------//
        //--------------------------------------------------------------------------------//
        //------------------- Inspector ------------------//
        [SerializeField]
        int currentLevel;

        [SerializeField]
        List <GameObject> Levels;

        

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
			for (int i = 0; i < currentLevel; i++) {
                Levels[i].SetActive (true);
                StartCoroutine(MakeStaticObjects(Levels[i].transform));
            }
		}

        private void RetrieveChildToStatic(Transform parent) {
            
            parent.gameObject.isStatic = true;

            if (parent.childCount == 0)
                return;
            else{
                for (int i = 0; i < parent.childCount; i++)
                    RetrieveChildToStatic(parent.GetChild(i));
            }

        }

        IEnumerator MakeStaticObjects (Transform root) {

            
            Animator[] _animator = root.GetComponentsInChildren<Animator>();

            foreach (Animator a in _animator) {
                a.SetTrigger("Start");
                 yield return null;
            }
            

            yield return new WaitForSeconds(5.0f);
            Debug.Log ("change non-static to static");


            RetrieveChildToStatic(root);
            yield return null;

            StaticBatchingUtility.Combine(root.gameObject);
            
            
            yield return new WaitForSeconds(5.0f);
            Debug.Log ("setactive-false to animated objects");

            foreach (Animator a in _animator) {
                a.gameObject.SetActive(false);
                yield return null;
            }


        }

		
		// Update is called once per frame
		void Update () {
			
		}


        //───────────────────────────────────────────────────────────────────────────────────────
		
	}

}