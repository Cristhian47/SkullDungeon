using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    private GameObject _clickCheck;

    private void Awake()
    {
        _clickCheck = transform.GetChild(0).gameObject;
    }

    public void DoEffect(Vector3 effectPosition)
    {
        _clickCheck.transform.position = effectPosition;
    }
}
