using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ClickEffect _clickEffect;
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _interactUIText;

    public static GameManager Instance;

    public PlayerController GetPlayer() => _player;

    private void Awake()
    {
        Instance = this;
    }

    public void CreateClickEffect(Vector3 effectPosition)
    {
        _clickEffect.DoEffect(effectPosition);
    }

    public void OpenInteractText(bool state)
    {
        _interactUIText.SetActive(state);
    }
}
