using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {


        public static GameController instance; 
        
        public int enemyCount;

        public GameObject panel;

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            
            
            
        }
        
        public void EnemyDead()
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount == 1)
            {
                //fim
                Debug.Log("FIM!");
                panel.SetActive((true));
            }
        }


        public void ResetOnClick()
        {
            SceneManager.LoadScene(0);
        }
        
        
        
        
    }
}