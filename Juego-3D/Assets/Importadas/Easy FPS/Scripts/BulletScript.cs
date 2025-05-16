using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

	public int danio = 25;
	/*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/
	void Update () {
		Debug.Log("Bullet Update");

        if (Physics.Raycast(transform.position, transform.forward,out hit, maxDistance, ~ignoreLayer)){
			if(decalHitWall){
                string hitTag = hit.transform.tag;
                if (hit.transform.tag == "LevelPart"){
					Debug.Log("Hit LevelPart");
                    Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
				if(hit.transform.tag == "Dummie"){
					Debug.Log("Hit Dummie");
                    Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Zombie zombie = hit.transform.GetComponent<Zombie>();
                    if (zombie != null)
                    {
                        zombie.RecibirDanio(danio);
                    }
                    Destroy(gameObject);
				}
				else
				{
					Debug.Log("Hit something else");
                }
			}		
			Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}

}
