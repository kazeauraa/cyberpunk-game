using UnityEngine;

public class OnTookHitVibration : MonoBehaviour
{
    [SerializeField] private Life life;

    private void OnEnable()
    {
        if (life != null)
        {
            life.OnTookHit += Vibrate;
        }
    }

    private void OnDisable()
    {
        if (life != null)
        {
            life.OnTookHit -= Vibrate;
        }
    }

    private void Vibrate(int damage)
    {
		#if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
		#endif
    }
}