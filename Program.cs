using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
    class MainClass
    {
        public static void Main()
        {
            List<string> c = Comments(comments);
            int money = UIF.PromptInt(c[4]);
            if (money >= 50)
                Console.WriteLine(c[5]);
            else
                Console.WriteLine(c[6]);
            Player p = new Player(money);
            string z = "y";
            while (z == "y")
            {
                string betting = UIF.PromptLine("Would you like to bet?");
                p.betting = betting;
                if (betting == "betting")
                {
                    int bet = UIF.PromptLine(c[7]);
                    p.bet = bet;
                }
                string outcome = Play();
                if (outcome == c[1])
                {
                    Console.WriteLine("OMG");
                    p.score += 1;
                    p.money += prop.bet;
                }
                else if (outcome == c[2])
                    //p.money -= prop.bet;
                    Console.WriteLine("OMG");
                if (p.score > p.highScore)
                    p.highScore += 1;
                z = UIF.PromptLine(c[8]);
            }
        }
        //play a game of blackjack, print out the player and dealer's hand and sum after each hit, print whether the player
        //wins, loses or ties.
        static string Play()
        {
            int playerSum = 0;//sum of all the players cards 
            int dealerSum = 0;//sum of all the dealers cards
            int[] usedCards = new int[13]; //number cards of each number used
            List<string> runOut = new List<string>(); //numbers for which all 4 cards have been used
            List<string> hand = new List<string>(); //all the players cards
            List<string> dealerHand = new List<string>();//all the dealers cards
            string game = "running";//tells whether the game is running or to quit out
            playerSum = AddCard(hand, playerSum, usedCards, runOut);
            playerSum = AddCard(hand, playerSum, usedCards, runOut);
            dealerSum = AddCard(dealerHand, dealerSum, usedCards, runOut);//
            dealerSum = AddCard(dealerHand, dealerSum, usedCards, runOut);
            Display(hand, dealerHand, playerSum, dealerSum);
            while ((playerSum < 21) && (dealerSum < 21) && (game == "running"))
            {
                string move = UIF.PromptLine("Enter h for hit or s and then enter for stay");
                if ((move == "h") || (playerSum == 0))
                {
                    playerSum = AddCard(hand, playerSum, usedCards, runOut);
                    dealerSum = AddCard(dealerHand, dealerSum, usedCards, runOut);
                    Display(hand, dealerHand, playerSum, dealerSum);
                }
                else
                {
                    Outcome(playerSum, dealerSum, game);
                    game = "done";
                }
            }
            if ((playerSum >= 21) || (dealerSum >= 21))
                return Outcome(playerSum, dealerSum, game);
        }
        //prints out the player and the dealer's hands and sums.
        static void Display(List<string> hand, List<string> dealerHand, int playerSum, int dealerSum)
        {
            Console.Write("Dealer: " + dealerHand[0]);
            for (int i = 1; i < dealerHand.Count; i++)
                Console.Write(", ?");
            Console.WriteLine(" - ?");
            Console.Write("Player: " + hand[0]);
            for (int i = 1; i < hand.Count; i++)
                Console.Write(", " + hand[i]);
            Console.WriteLine(" - " + playerSum);
        }
        //adds a card to a hand and returns the sum of all the cards in the hand.
        static int AddCard(List<string> hand, int sum, int[] usedCards, List<string> runOut)
        {
            int c = 0;
            string card = "lol";
            int i = 0;
            while (i == 0)
            {
                Random rand = new Random();
                c = rand.Next(13);
                int d = c + 1;
                card = d + " ";
                card = card.Trim();
                // Console.WriteLine ("card = '" + card + "'");
                if (card.Equals("11"))
                    card = "J";
                else if (card.Equals("12"))
                    card = "Q";
                else if (card.Equals("13"))
                    card = "K";
                else if (card.Equals("1"))
                    card = "A";
                // Console.WriteLine ("card = '" + card + "'");
                if (runOut.Contains(card) == false)
                {
                    hand.Add(card);
                    i = 1;
                }
            }
            if (c == 0)
            {
                if (sum < 11)
                    sum += 11;
            }
            else
            {
                sum += c;
                sum += 1;
            }
            usedCards[c] += 1;
            if (usedCards[c] == 4)
                runOut.Add(card);
            if (sum > 21)
            {
                int aces = CheckAces(hand);
                for (int z = 0; z < aces; z++)
                {
                    if (sum > 21)
                        sum -= 10;
                }
            }
            return sum;
        }
        //prints out whether the player wins, loses or ties.
        static void Outcome(int playerSum, int dealerSum, string game)
        {
            if (playerSum > dealerSum)
                Console.WriteLine(c[1]);
            else if (playerSum < dealerSum)
                Console.WriteLine(c[2]);
            else
                Console.WriteLine(c[3]);
            game = "done";
        }
        //returns the number of aces (A) in a hand.
        static int CheckAces(List<string> hand)
        {
            int aces = 0;
            foreach (string s in hand)
            {
                if (s.Equals("A"))
                    aces += 1;
            }
            return aces;
        }

        static List<string> Comments(string file)
        {
            List<string> comments = new List<string>();
            var reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                comments.Add(reader.ReadLine);
            }
        }
    }
}