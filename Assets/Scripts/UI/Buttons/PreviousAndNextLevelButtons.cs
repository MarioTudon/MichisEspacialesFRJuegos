//Este script se coloca en el UIManager

using TMPro;
using UnityEngine;

public class PreviousAndNextLevelButtons : MonoBehaviour
{
    public TextMeshProUGUI stateName;
    //Variable que contiene el GameObject del selector (Objeto que no pertenece al Canvas)
    public GameObject selector;
    //Script que contiene el GameObject selector donde se guarda la lista de los estados(niveles)
    [SerializeField] private LevelSelector levelSelector;

    //Funcion que se asigna al boton para moverse al estado siguiente
    public void MoveToNextLevel()
    {
        //Se cancela la animacion del currently level para que se termine el loop ping pong
        LeanTween.cancel(levelSelector.currentlyLevel);
        //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //El currently level se iguala al nivel anterior o al primer nivel segun corresponda la condicion
        levelSelector.currentlyLevel = levelSelector.nextLevel == null ? levelSelector.firstLevel : levelSelector.nextLevel;
        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
        //Se asignan los niveles anterior y siguiente
        levelSelector.SetPreviousAndNextLevels();
        //Muestra el nombre del estado seleccionado
        stateName.GetComponent<TextMeshProUGUI>().text = levelSelector.currentlyLevel.name;
    }

    //Funcion que se asigna al boton para moverse al estado anterior
    public void MoveToPreviousLevel()
    {
        //Se cancela la animacion del currently level para que se termine el loop ping pong
        LeanTween.cancel(levelSelector.currentlyLevel);
        //Se anima el currently level haciendo que regrese a su escala original (1, 1, 1)
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one, 0.3f);
        //El currently level se iguala al nivel anterior o al ultimo nivel segun corresponda la condicion
        levelSelector.currentlyLevel = levelSelector.previousLevel == null ? levelSelector.lastLevel : levelSelector.previousLevel;
        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        levelSelector.currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
        //Se asignan los niveles anterior y siguiente
        levelSelector.SetPreviousAndNextLevels();
        //Muestra el nombre del estado seleccionado
        stateName.GetComponent<TextMeshProUGUI>().text = levelSelector.currentlyLevel.name;
    }
}
