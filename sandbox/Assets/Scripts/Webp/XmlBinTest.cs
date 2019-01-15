using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;


namespace CookApps {

	public class XmlBinTest : MonoBehaviour {

		//--------------------------------------------------------------------------------//
        //-----------------------------------FIELD----------------------------------------//
        //--------------------------------------------------------------------------------//
        //------------------- Inspector ------------------//
        public Object xmlbin;
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
            
            //FileStream fs = new FileStream ("Assets/unpacked/axe.xml.bin", FileMode.Open);
            
            //BinaryReader br = new BinaryReader(fs);
            byte[] bytes = File.ReadAllBytes ("Assets/unpacked/axe.xml.bin");
            Debug.Log (bytes.Length);
            string str = System.Text.Encoding.Default.GetString(bytes);
            Debug.Log (str.Length);

            //--------------------------

            XmlDocument doc = new XmlDocument();
            string data = System.Text.Encoding.UTF8.GetString(bytes);

            doc.LoadXml(data);

            Debug.Log (doc);


		}   
		


        //───────────────────────────────────────────────────────────────────────────────────────
		
	}

}