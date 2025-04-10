using UnityEngine;

public class Koshelek : MonoBehaviour
{
    private GameObject player;
    private PlayerInfo playerInfo;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInfo = player.GetComponent<PlayerInfo>();
    }
}
