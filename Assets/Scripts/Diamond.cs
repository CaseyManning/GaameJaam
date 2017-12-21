using System;
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class Diamond : MonoBehaviour
	{
		public Diamond ()
		{
		}
		Material m_Material;

		void Start()
		{
			//Fetch the Material from the Renderer of the GameObject
			m_Material = GetComponent<Renderer>().material;
		}
		/*void OnCollisionEnter2D (Collision2D col)
		{
			if(col.gameObject.name == "Player")
			{
				//m_Material.color = Color.red;
				//Destroy(col.gameObject);
				Destroy (this.gameObject);
				//just a test
			}
		}*/
	}
}

