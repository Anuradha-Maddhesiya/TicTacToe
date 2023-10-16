using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int whoseTurn; // 0 = x, 1 = O
    public int turnCount; //count the number of turn played
    public GameObject[] turnIcons; //display whose turn it is
    public Sprite[] playIcons; // 0 = x icon, 1 = O icon
    public Button[] tictactoeSpaces;
    public int[] markedSpaces; //ID's which space was marked by which player
    public TextMeshProUGUI winner_txt;
    public GameObject[] winnerLines;
    public GameObject winnerPanel;
    public int xPlayerScore;
    public int oPlayerScore;
    public TextMeshProUGUI xPlayerScoreText;
    public TextMeshProUGUI oPlayerScoreText;
    public Button xPlayerButton;
    public Button oPlayerButton;

    private void Start()
    {
        GameSetup();
    }
    void GameSetup()
    {
        whoseTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i = 0; i < tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable = true;
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;

        }
        for(int i = 0;i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }
    }

    public void TicTacToeButton(int whichNumber)
    {
        xPlayerButton.interactable = false;
        oPlayerButton.interactable = false;
        tictactoeSpaces[whichNumber].image.sprite = playIcons[whoseTurn];
        tictactoeSpaces[whichNumber].interactable = false;

        markedSpaces[whichNumber] = whoseTurn + 1;
        turnCount++;
        if(turnCount > 4)
        {
            WinnerCheck();
        }
        if (whoseTurn == 0)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }
    void WinnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[0] + markedSpaces[4] + markedSpaces[6];

        var solutions = new int[] {s1, s2, s3, s4, s5, s6, s7,s8};
        for(int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3*(whoseTurn + 1))
            {
                WinnerDisplay(i);
                return;
            }
        }
    }

    void WinnerDisplay(int indexIn)
    {
        winnerPanel.SetActive(true);
        if(whoseTurn == 0)
        {
            xPlayerScore++;
            xPlayerScoreText.text = xPlayerScore.ToString();
            winner_txt.text = "Player X Wins!";
        }
        else if(whoseTurn == 1)
        {
            oPlayerScore++;
            oPlayerScoreText.text = oPlayerScore.ToString();
            winner_txt.text = "Player O Wins!";
        }
        winnerLines[indexIn].SetActive(true);
    }

    public void Rematch()
    {
        GameSetup();
        for(int i = 0; i < winnerLines.Length ; i++)
        {
            winnerLines[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
        xPlayerButton.interactable = true;
        oPlayerButton.interactable = true;
    }
    public void Restart()
    {
        Rematch();
        xPlayerScore = 0;
        oPlayerScore = 0;
        xPlayerScoreText.text = "0";
        oPlayerScoreText.text = "0";
    }

    public void SwitchPlayer(int whichPlayer)
    {
        if(whichPlayer == 0)
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
        else if (whichPlayer == 1)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
    }
}
