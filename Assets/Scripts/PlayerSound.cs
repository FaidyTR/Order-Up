using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private Player player;
    private float footstepTimer;
    private float maxFootstepTime = .1f;
    private void Update()
    {
        footstepTimer += Time.deltaTime;
        if (footstepTimer > maxFootstepTime)
        {
            footstepTimer = 0f;
            if (player.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);
            }
        }
    }
}

