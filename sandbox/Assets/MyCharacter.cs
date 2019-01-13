using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCharacter : MonoBehaviour
{

	public Text CoinText;

#region Data
	bool bSavedBefore;
	int nPurchases;
	int nCoin;
#endregion

	Rigidbody _rigidbody;

	// Use this for initialization
	void Start()
	{
		_rigidbody = GetComponentInChildren<Rigidbody>();


		if (PlayerPrefs.HasKey("IsSaved"))
		{
			nPurchases = PlayerPrefs.GetInt("nPurchases");
			nCoin = PlayerPrefs.GetInt("nCoin");
			Debug.Log(nCoin);
			transform.localScale += new Vector3(nPurchases, nPurchases, nPurchases);
			bSavedBefore = true;
		}
		else
		{
			nCoin = 5;
			nPurchases = 0;
			bSavedBefore = false;
		}

		CoinText.text = "Coin X " + nCoin;
	}

	// Update is called once per frame
	void Update()
	{
		if (_rigidbody.gameObject.transform.position.y > 200)
			_rigidbody.velocity = Physics.gravity;
	}

	public void OnClickButtonUpgrade()
	{
		if (nCoin >= 1)
		{
	
			_rigidbody.AddForce(Vector3.up * 100.0f * 9.8f);
			transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);

			nPurchases++;
			nCoin--;

			CoinText.text = "Coin X " + nCoin;

			//set data to PlayerPrefs.
			if (!bSavedBefore)
			{
				PlayerPrefs.SetInt("IsSaved", 1);
				bSavedBefore = true;
			}

			PlayerPrefs.SetInt("nPurchases", nPurchases);
			PlayerPrefs.SetInt("nCoin", nCoin);
		}
	}

	public void OnClickButtonReset()
	{
		transform.localScale = new Vector3(10f, 10f, 10f);
		nPurchases = 0;

		if (bSavedBefore)
			PlayerPrefs.SetInt("nPurchases", nPurchases);
	}

	public void OnClickButtonPurchase ()
	{
		nCoin += 10;
		CoinText.text = "Coin X " + nCoin;
		PlayerPrefs.SetInt("nCoin", nCoin);
	}
}
