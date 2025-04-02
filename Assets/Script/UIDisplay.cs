using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI VidadoPersonagem;
    public PlayerData playerData;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VidadoPersonagem.text = "Vida: " + playerData.Health;
            
    }
}
