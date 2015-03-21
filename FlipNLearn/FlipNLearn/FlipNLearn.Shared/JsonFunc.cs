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

        public static void AddDeck(Deck deck)
        {
            if (!ViewModel.instance.SelectedSet.Decks.Any(d => d.Name == deck.Name))
            {
                ViewModel.instance.SelectedSet.Decks.Add(deck);
                Serialize();
            }
        }

        public static void AddCard(Card card)
        {
                ViewModel.instance.SelectedDeck.Cards.Add(card);
                Serialize();
        }
        
        async public static void Serialize()
        {
            // Serialize our Product class into a string
            // Changed to serialze the List
            string jsonContents = JsonConvert.SerializeObject(ViewModel.instance.Sets);
            //System.Diagnostics.Debug.WriteLine(jsonContents);

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

        async public static void Deserialize(ViewModel vm)
        {

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
                        //System.Diagnostics.Debug.WriteLine(jsonContents);
                        // deserialize back to our products!
                        //I only had to change this following line in this function
                        var result = JsonConvert.DeserializeObject<IList<Set>>(jsonContents);
                        foreach (Set set in result)
                        {
                            ViewModel.instance.Sets.Add(set);
                            //System.Diagnostics.Debug.WriteLine(set.Name + " / " + set.Id);
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
