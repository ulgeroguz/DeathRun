//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class abc : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//		if (Input.GetKeyDown(KeyCode.X))
//		{

//			if (muzzlePrefab != null)
//			{
//				var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
//				//	Vector3 newDirection = Vector3.RotateTowards(transform.forward, dest.position, 5, 0.0f);
//				muzzleVFX.transform.forward = dest.position + offset;

//				var ps = muzzleVFX.GetComponent<ParticleSystem>();
//				if (ps != null)
//					Destroy(muzzleVFX, ps.main.duration);
//				else
//				{
//					var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
//					Destroy(muzzleVFX, psChild.main.duration);
//				}
//			}
//		}
//	}
//}
