using Microsoft.AspNetCore.DataProtection.KeyManagement;
using RestSharp;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Deck_of_Cards_API_Lab_JT.Models
{
    public class DeckDAL
    {
        string deckId = "ns0y9gj9l2pt";

        public CreateDeck NewDeck() //create one deck and shuffle the cards.
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/shuffle/?deck_count=1";

            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();
            var response = client.GetAsync<CreateDeck>(request);
            CreateDeck d = response.Result;
            return d;
        }


        public DrawCard DrawCard(int key) //draw the defined# of cards. Limitations: shuffles card continuously, doesn't keep track of cards already drawn.
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count={key}";

            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();
            var response = client.GetAsync<DrawCard>(request);
            DrawCard dc = response.Result;
            return dc;
        }

/*        public DrawCard DrawCard5() //draw the 5 of cards.
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count=5";

            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();
            var response = client.GetAsync<DrawCard>(request);
            DrawCard dc = response.Result;
            return dc;
        }*/

    }
}
