using FlipNLearn.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.Storage;
using Windows.Storage.Streams;

namespace FlipNLearn.Models
{
    class JsonFunc
    {
        public static string jsonFileName = "FlipNLearn.json";

        public static void AddSet(Set set)
        {
            if (!ViewModel.instance.Sets.Any(s => s.Name == set.Name))
            {
                ViewModel.instance.Sets.Add(set);
                Serialize();
            }
        }

        public static void DeleteSet()
        {
            if (ViewModel.instance.SelectedSet.Decks != null)
            {
                foreach (Deck d in ViewModel.instance.SelectedSet.Decks.ToList())
                {
                    ViewModel.instance.SelectedDeck = d;
                    if (ViewModel.instance.SelectedDeck.Cards != null)
                    {
                        foreach (Card c in d.Cards.ToList())
                        {
                            ViewModel.instance.SelectedCard = c;
                            ViewModel.instance.SelectedDeck.Cards.Remove(ViewModel.instance.SelectedCard);
                        }
                    }
                    ViewModel.instance.SelectedSet.Decks.Remove(ViewModel.instance.SelectedDeck);
                }
            }
            ViewModel.instance.Sets.Remove(ViewModel.instance.SelectedSet);

            Serialize();
        }

        public static void AddDeck(Deck deck)
        {
            if (!ViewModel.instance.SelectedSet.Decks.Any(d => d.Name == deck.Name))
            {
                ViewModel.instance.SelectedSet.Decks.Add(deck);
                Serialize();
            }
        }

        public static void DeleteDeck()
        {
            if (ViewModel.instance.SelectedDeck.Cards != null)
            {
                foreach (Card c in ViewModel.instance.SelectedDeck.Cards.ToList())
                {
                    ViewModel.instance.SelectedCard = c;
                    ViewModel.instance.SelectedDeck.Cards.Remove(ViewModel.instance.SelectedCard);
                }
            }
            ViewModel.instance.SelectedSet.Decks.Remove(ViewModel.instance.SelectedDeck);

            Serialize();
        }

        public static void AddCard(Card card)
        {
                ViewModel.instance.SelectedDeck.Cards.Add(card);
                Serialize();
        }

        public static void DeleteCard()
        {
            ViewModel.instance.SelectedDeck.Cards.Remove(ViewModel.instance.SelectedCard);

            Serialize();
        }
        
        async public static void Serialize()
        {
            // Serialize our Product class into a string
            // Changed to serialze the List
            string jsonContents = JsonConvert.SerializeObject(ViewModel.instance.Sets);
            System.Diagnostics.Debug.WriteLine(ViewModel.instance.Sets.Last().Name);

            // Get the app data folder and create or replace the file we are storing the JSON in.
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.CreateFileAsync(jsonFileName, CreationCollisionOption.ReplaceExisting);

            // Open the file...
            using (IRandomAccessStream textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                // write the JSON string!
                using (DataWriter textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(jsonContents);
                    await textWriter.StoreAsync();
                }
            }
        }

        async public static void Deserialize()
        {
            System.Diagnostics.Debug.WriteLine("DESERIALIZING!");

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                // Getting JSON from file if it exists, or file not found exception if it does not
                StorageFile textFile = await localFolder.GetFileAsync(jsonFileName);

                using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
                {
                    // Read text stream 
                    using (DataReader textReader = new DataReader(textStream))
                    {
                        //get size
                        uint textLength = (uint)textStream.Size;
                        await textReader.LoadAsync(textLength);
                        // read it
                        string jsonContents = textReader.ReadString(textLength);
                        System.Diagnostics.Debug.WriteLine(jsonContents);
                        // deserialize back to our products!
                        var result = JsonConvert.DeserializeObject<IList<Set>>(jsonContents);
                        foreach (Set set in result)
                        {
                            ViewModel.instance.Sets.Add(set);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[JSON RETRIEVAL FAILED]");
            }
        }


    }
}
