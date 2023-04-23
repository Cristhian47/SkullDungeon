using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    private GameObject _clickParticles;
    private ParticleSystem _clickParticlesSystem;
    private Ray _currentRay;
    private RaycastHit _rayData;

    private void Awake()
    {
        _clickParticles = transform.GetChild(0).gameObject;
        _clickParticlesSystem = _clickParticles.GetComponent<ParticleSystem>();
    }

    public void DoEffect(Vector3 effectPosition)
    {
        _clickParticles.transform.position = effectPosition;
        _clickParticlesSystem.Stop();
        _clickParticlesSystem.Play();
    }
}
