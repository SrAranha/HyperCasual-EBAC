using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Level")]
    public Transform levelContainer;
    [Tooltip("The amount of middle pieces to the level. Start and End pieces will always be added on start/end of level.")]
    public int piecesAmount;
    [Header("Level Colors")]
    public List<LevelColors> levelColors;
    public LevelColors currentLevelColor;
    [Header("Pieces")]
    public List<LevelPiece> startPiecesList;
    public List<LevelPiece> middlePiecesList;
    public List<LevelPiece> endPiecesList;

    private LevelPiece lastPiece;
    [SerializeField] private List<LevelPiece> currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ResetLevel();
        }
    }
    private void ChooseColor()
    {
        currentLevelColor = levelColors[Random.Range(0, levelColors.Count)];
    }
    private void CreateLevel()
    {
        ChooseColor();
        for (int i = 0; i <= piecesAmount; i++)
        {
            if (i == 0)
            {
                CreatePiece(startPiecesList);
            }
            if (i == piecesAmount)
            {
                CreatePiece(endPiecesList);
            }
            else
            {
                CreatePiece(middlePiecesList);
            }
        }
    }
    private void ResetLevel()
    {
        foreach (LevelPiece piece in currentLevel)
        {
            Destroy(piece.gameObject);
        }
        currentLevel.Clear();
        lastPiece = null;
        CreateLevel();
    }
    private void CreatePiece(List<LevelPiece> list)
    {
        var _currentPiece = Instantiate(GetRandomPiece(list), levelContainer);
        _currentPiece.transform.localPosition = Vector3.zero;
        _currentPiece.SetColor(currentLevelColor.planeColor, currentLevelColor.obstacleColor);
        if (lastPiece != null)
        {
            _currentPiece.transform.position = lastPiece.endPoint.transform.position;
        }
        currentLevel.Add(_currentPiece);
        lastPiece = _currentPiece;
    }
    private LevelPiece GetRandomPiece(List<LevelPiece> list)
    {
        LevelPiece currentPiece = list[Random.Range(0, list.Count)];
        return currentPiece;
    }
}

[System.Serializable]
public class LevelColors
{
    public Color planeColor = Color.white;
    public Color obstacleColor = Color.red;
}