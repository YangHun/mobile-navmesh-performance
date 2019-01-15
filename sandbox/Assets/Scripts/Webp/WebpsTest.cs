using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebP;
using System.IO;

namespace CookApps {

	public class WebpsTest : MonoBehaviour {

		//--------------------------------------------------------------------------------//
        //-----------------------------------FIELD----------------------------------------//
        //--------------------------------------------------------------------------------//
        //------------------- Inspector ------------------//

        [SerializeField]
        protected Texture2D texture;

        [SerializeField]
        protected Object textasset;

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
            
            texture = LoadWebp();

		}
		
        public Texture2D LoadWebp () {
            
            Texture2D result = null;
            byte[] bytes = File.ReadAllBytes ("Assets/unpacked/base.webp");

            //byte[] bytes = textasset.bytes;

            Error _error;
            result = Texture2DExt.CreateTexture2DFromWebP(bytes, true, true, out _error);

            if (_error == Error.Success){
                GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f, 0.5f));

                return result;
            }
            else {
                return null;
            }
            
        }

        //───────────────────────────────────────────────────────────────────────────────────────
		
	}

}