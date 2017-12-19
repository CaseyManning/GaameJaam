using System;
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class Diamond : MonoBehaviour
	{
		//everythings radius is 0.5 i think... so 
		public Diamond ()
		{
		}

		void OnCollisionEnter2D (Collision2D col)
		{
			if(col.gameObject.name == "Player")
			{
				Destroy(col.gameObject);
			}
		}
	}
}

