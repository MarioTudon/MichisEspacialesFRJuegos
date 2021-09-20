//Este scrip se pone en cada GameObject en el UI que corresponda a un personaje
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    //Variable bool que determina si el personaje esta bloqueado o desbloqueado
    public bool isLocked;
    //Boton para comprar el personaje
    public GameObject botonComprar;

    private void Start()
    {
        botonComprar.SetActive(isLocked);
    }
}
