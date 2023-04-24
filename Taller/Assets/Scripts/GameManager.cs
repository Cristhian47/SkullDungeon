using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ClickEffect _clickEffect;
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _interactUIText;

    public static GameManager Instance;

    //Obtiene referencia del jugador
    public PlayerController GetPlayer() => _player;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CloseGame();
    }

    //Si presiona la tecla de espacio, cierra el juego.
    private void CloseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //Ubica el efecto del click en una posición especifica
    public void CreateClickEffect(Vector3 effectPosition)
    {
        _clickEffect.DoEffect(effectPosition);
    }

    //Activa el texto de interaccion cuando entra en el area de deteccion
    public void OpenInteractText(bool state)
    {
        _interactUIText.SetActive(state);
    }
}
