using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackjackGameLogic : MonoBehaviour
{
    public Deck deck;
    public CurrencySystem currencySystem;
    public Text playerScoreText;
    public Text dealerScoreText;
    public Text resultText;
    public InputField betInputField;
    public bool CheckGameEndStaus;
    private List<Card> playerHand;
    private List<Card> dealerHand;
    private int currentBet;
    private bool DoubleDownWin = false, DoubleDownWin21 = false;

    void Start()
    {
        playerHand = new List<Card>();
        dealerHand = new List<Card>();
        deck.InitializeDeck();
        DealInitialCards();
    }

    void DealInitialCards()
    {
        playerHand.Add(deck.DealCard());
        playerHand.Add(deck.DealCard());
        dealerHand.Add(deck.DealCard());
        dealerHand.Add(deck.DealCard());
        UpdateScores();
    }

   

    public void Hit()
    {
        playerHand.Add(deck.DealCard());
        UpdateScores();
        if (CalculateScore(playerHand) > 21)
        {
            resultText.text = "Player Busts! Dealer Wins!";
        }
    }

    public void DoubleDown()
    {
        playerHand.Add(deck.DealCard());
        UpdateScores();
        if (CalculateScore(playerHand) > 21)
        {
            resultText.text = "Player Busts! Dealer Wins!";
        }
        else if (CalculateScore(playerHand) == 21)
        {
            DoubleDownWin21 = true;
            DetermineWinner();
        }
        else
        {
            DoubleDownWin = true;
            DetermineWinner();
        }
    }

    public void Split()
    {
        playerHand.Add(deck.DealCard());
        UpdateScores();
        if (CalculateScore(playerHand) > 21)
        {
            resultText.text = "Player Busts! Dealer Wins!";
        }
    }

    public void Stand()
    {
        while (CalculateScore(dealerHand) < 17)
        {
            dealerHand.Add(deck.DealCard());
        }
        UpdateScores();
        DetermineWinner();
    }

    void UpdateScores()
    {
        playerScoreText.text = "Player: " + CalculateScore(playerHand);
        dealerScoreText.text = "Dealer: " + CalculateScore(dealerHand);
    }

    int CalculateScore(List<Card> hand)
    {
        int score = 0;
        int numberOfAces = 0;
        foreach (Card card in hand)
        {
            int value = card.Value;
            if (value > 10) value = 10; 
            score += value;
            if (value == 1) numberOfAces++;
        }
        while (score <= 11 && numberOfAces > 0)
        {
            score += 10; 
            numberOfAces--;
        }
        return score;
    }

    void DetermineWinner()
    {
        int playerScore = CalculateScore(playerHand);
        int dealerScore = CalculateScore(dealerHand);

        if (dealerScore > 21)
        {
            resultText.text = "Dealer Busts! Player Wins!";
            //currencySystem.AddCurrency(currentBet * 2);
        }
        else if (playerScore > dealerScore)
        {
            resultText.text = "Player Wins!";
            //currencySystem.AddCurrency(currentBet * 2);
        }
        else if (playerScore < dealerScore)
        {
            resultText.text = "Dealer Wins!";
        }
        else if (DoubleDownWin == true)
        {
            resultText.text = "Player Wins! Double Down!";
            //currencySystem.AddCurrency(currentBet * 4);
            DoubleDownWin = false;
        }
        else if (DoubleDownWin21 == true)
        {
            resultText.text = "Player Wins! Double Down! Perfect 21!";
            //currencySystem.AddCurrency(currentBet * 5);
            DoubleDownWin21 = false;
        }
        else
        {
            resultText.text = "Push!";
            //currencySystem.AddCurrency(currentBet);
        }
        CheckGameEndStaus = true;
    }
    public void retstartgame()
    {
        if (CheckGameEndStaus == true)
        {
            CheckGameEndStaus = false;
            playerHand.Clear();
            dealerHand.Clear();
            playerScoreText.text = "Player: 0";
            dealerScoreText.text = "Dealer: " + CalculateScore(dealerHand);
            resultText.text = "";
            betInputField.text = "";
            //placeBetButton.interactable = true;
        }
    }
}

