using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCare : MonoBehaviour
{
    public string careType;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        Transform player = other.gameObject.transform;
        bool hasCare = controller.checkCarrying();
        if (controller != null && hasCare == false)
        {
            if(careType == "seed") {
                controller.setCare("seed");
                controller.setCarrying(true);
            } else if (careType == "pickaxe"){
                controller.setCare("pickaxe");
                if(transform.name.Contains("Summer Meetup")) {
                    SetActiveAllChildren(player, false);
                    player.GetChild(2).gameObject.SetActive(true);
                    controller.setCarrying(true);
                } else if (transform.name.Contains("Party")){
                    SetActiveAllChildren(player, false);
                    player.GetChild(4).gameObject.SetActive(true);
                    controller.setCarrying(true);
                }
            } else if (careType == "waterpot"){
                controller.setCare("waterpot");
                if(transform.name.Contains("Friend Group invites")) {
                    SetActiveAllChildren(player, false);
                    player.GetChild(3).gameObject.SetActive(true);
                    controller.setCarrying(true);
                } else if (transform.name.Contains("Peer")) {
                    SetActiveAllChildren(player, false);
                    player.GetChild(1).gameObject.SetActive(true);
                    controller.setCarrying(true);
                }
            }
            Destroy(gameObject);
        }
    }
    
    private void SetActiveAllChildren(Transform transform, bool value)
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(value);

			// SetActiveAllChildren(child, value);
		}
	}
}