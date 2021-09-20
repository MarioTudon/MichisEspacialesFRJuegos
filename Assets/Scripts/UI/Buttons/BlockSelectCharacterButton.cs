//Este script se coloca en el boton de seleccionar personaje
using UnityEngine.UI;
using UnityEngine;

public class BlockSelectCharacterButton : MonoBehaviour
{
    //Componente SwipeMenu del contenedor de personajes
    public SwipeMenu contenedorDePersonajes;
    private Button selectButton;

    private void Start()
    {
        selectButton = GetComponent<Button>();
    }

    public void BlockButton()
    {
        selectButton.interactable = !contenedorDePersonajes.currentlySelection.GetComponent<CharacterStatus>().isLocked;
    }
}
