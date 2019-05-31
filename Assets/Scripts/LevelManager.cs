using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level levelPrefab;
    // private List<Level> levels;

    private Level currentLevel;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Level firstLevel = AddLevel();
        // firstLevel.AddObject().ScheduleSpawn(10);
        SceneManager.LoadScene("PercussionScene", LoadSceneMode.Single);
        Invoke("SwitchScene", 3);
    }

    void SwitchScene() {
        
        Debug.Log(SceneManager.GetActiveScene().name);
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        // go = Instantiate(go, transform.position, Quaternion.identity);
        // go.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartLevel(Level level) {
        if (currentLevel != null) {
            currentLevel.EndLevel();
        }

        currentLevel = level;
        level.BeginLevel();
    }

    Level AddLevel() {
        Debug.Log("level created");
        Level level = Instantiate(levelPrefab, transform.position, Quaternion.identity);
        level.gameObject.SetActive(false);
        Debug.Log("level inactive");
        level.transform.parent = this.transform;
        return level;
    }
    

    public Level CurrentLevel {
        get {
            return currentLevel;
        }

        set {
            currentLevel = value;
        }
    }

    
}
