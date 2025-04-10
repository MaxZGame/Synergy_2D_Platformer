using UnityEngine;
using Unity.Cinemachine;

public class PlayerFollowCamera : MonoBehaviour
{
    private void Start()
    {
        CinemachineCamera virtualCamera = GetComponent<CinemachineCamera>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
    }
}