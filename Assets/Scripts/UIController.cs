using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    

    [SerializeField] Player player;

    [SerializeField]
    private Image[] lifeImages;

    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private Button restartBtn;


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    private void Start()
    {
        ToggleRestartButton(false);

        player._OnPlayerScoreChanged += ActualizarScore;
        player._OnPlayerHit += ActualizarVidas;
        player._OnPlayerDied += MuerteJugador;
        
       
        
      
    }

    private void ToggleRestartButton(bool val)
    {
        if (restartBtn != null)
        {
            restartBtn.gameObject.SetActive(val);
        }
    }

    private void ActualizarVidas(int _vidas)
    {
        if (scoreLabel || lifeImages == null)
        {
            if (_vidas <= 0)
            {
                scoreLabel.text = "Game over";
            }

            for (int i = 0; i < lifeImages.Length; i++)
            {
                lifeImages[i].enabled = i < _vidas;
            }
        }

        
    }
    private void ActualizarScore(int _score)
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = _score.ToString();
        }
        
    }
    
    private void MuerteJugador()
    {
        ToggleRestartButton(true);
    }
}