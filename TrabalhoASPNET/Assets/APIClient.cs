using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIClient : MonoBehaviour
{
	public Text Name;
	public Text Age;
	public Text Level;


	const string baseUrl = "http://localhost:50451/API";

	// Use this for initialization
	void Start ()
	{
		//StartCoroutine(PostClasseModeloApiAsync());
		StartCoroutine(GetItensApiAsync());

	}

	private IEnumerator PostClasseModeloApiAsync()
	{
		WWWForm form = new WWWForm();

		form.AddField("Nome", "ClasseModeloFromUnity 2");
		form.AddField("Descricao", "ClasseModelo enviado por POST para Unity3d (2)");
		form.AddField("DanoMaximo", "50");
		form.AddField("Raridade", "9");
		form.AddField("TipoClasseModeloID", "1");

		using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Class1", form))
		{
			// obsoleto (Unity 2017.1)
			yield return request.Send();

			// (Unity 2017.2)
			//yield return request.SendWebRequest();


			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log("Envio do ClasseModelo efetuado com sucesso");
			}

		}
	}

	IEnumerator GetItensApiAsync()
	{
		UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Class1");

		// obsoleto (Unity 2017.1)
		yield return request.Send();

		// (Unity 2017.2)
		//yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError)
		{
			Debug.Log(request.error);
		}
		else
		{
			string response = request.downloadHandler.text;
			Debug.Log(response);

			//byte[] bytes = request.downloadHandler.data;

			ClasseModelo[] itens = JsonHelper.getJsonArray<ClasseModelo>(response);

			foreach (ClasseModelo i in itens)
			{
				ImprimirClasseModelo(i);
			}

		}
	}

	private void ImprimirClasseModelo(ClasseModelo i)
	{
		Debug.Log("======= Dados Objeto ==========");

		Debug.Log("ID: " + i.ID);
		Debug.Log("Name: " + i.Name);
		Debug.Log("Age: " + i.Age);
		Debug.Log("Level: " + i.Level);

		Name.text = "NAME : " + i.Name;
		Age.text = "AGE : " + i.Age.ToString();
		Level.text = "LEVEL : " + i.Level.ToString();
	}
}