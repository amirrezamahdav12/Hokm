using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public DeckManager deckManager;
    public TrickManager trickManager;

    public int currentPlayer = 0;
    public int hakemID = 0;
    public suit hokm;

    public int[] teamScores = new int[2]; // تیم 0: بازیکن 0 و 2 — تیم 1: بازیکن 1 و 3

    void Start()
    {
        InitPlayers();
        StartNewRound();
    }

    void InitPlayers()
    {
        players.Clear();
        for (int i = 0; i < 4; i++)
        {
            players.Add(new Player(i));
        }
    }

    void StartNewRound()
    {
        Debug.Log("🔄 شروع دست جدید");

        deckManager = new DeckManager();
        deckManager.DealCards(players);

        hakemID = Random.Range(0, 4); // انتخاب حاکم تصادفی
        hokm = players[hakemID].Hand[0].Suit; // فعلاً حکم = اولین کارت حاکم
        Debug.Log($"👑 حاکم: بازیکن {hakemID} | حکم: {hokm}");

        currentPlayer = hakemID;
        trickManager = new TrickManager(hokm);

        PlayNextTurn();
    }

    void PlayNextTurn()
    {
        if (trickManager.CardsPlayed.Count == 4)
        {
            int winnerID = trickManager.GetWinnerPlayerID();
            Debug.Log($"🏆 دست رو برد بازیکن {winnerID}");
            teamScores[winnerID % 2]++;
            trickManager.Reset();
            currentPlayer = winnerID;

            CheckEndOfGame();
        }

        // بازی کردن کارت بعدی
        Player player = players[currentPlayer];
        Card playedCard = player.PlayCard(trickManager.CardsPlayed.Count == 0 ? null : trickManager.CardsPlayed[0], hokm);
        Debug.Log($"🎮 بازیکن {player.ID} بازی کرد: {playedCard}");
        trickManager.AddPlay(player.ID, playedCard);

        // نوبت بعدی
        currentPlayer = (currentPlayer + 1) % 4;
        Invoke(nameof(PlayNextTurn), 1f); // تاخیر 1 ثانیه برای نمایش
    }

    void CheckEndOfGame()
    {
        if (teamScores[0] >= 7 || teamScores[1] >= 7)
        {
            Debug.Log($"🎉 تیم {(teamScores[0] >= 7 ? "0" : "1")} برنده شد!");
            CancelInvoke();
        }
    }
}