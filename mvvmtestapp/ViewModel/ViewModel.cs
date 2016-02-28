using System;
using System.Windows;
using System.Collections.ObjectModel;
using mvvmtestapp.Model;
using Windows.UI.Popups;

namespace MVVMTestApp.ViewModelNamespace
{
    public class ViewModel
    {
        public ObservableCollection<Accomplishment> Accomplishments { get; set; }


        public void GetAccomplishments()
        {
            if (Windows.Storage.ApplicationData.Current.LocalSettings.Values.Count > 0)
            {
                GetSavedAccomplishments();
            }
            else
            {
                GetDefaultAccomplishments();
            }
        }

        public async void SaveAccomplishments()
        {
            //new stuff kek
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings;

            foreach (Accomplishment a in Accomplishments)
            {
                if (settings.Values.ContainsKey(a.Name))
                {
                    settings.Values[a.Name] = a;
                }
                else
                {
                    settings.Values.Add(a.Name, a.GetCopy());
                }
            }

            //universal app new stuff lel
            var dialog = new MessageDialog("Finished saving accomplishments");
            await dialog.ShowAsync();
        }


        public void GetDefaultAccomplishments()
        {
            ObservableCollection<Accomplishment> a = new ObservableCollection<Accomplishment>();

            // Items to collect
            a.Add(new Accomplishment() { Name = "Potions", Type = "Item" });
            a.Add(new Accomplishment() { Name = "Coins", Type = "Item" });
            a.Add(new Accomplishment() { Name = "Hearts", Type = "Item" });
            a.Add(new Accomplishment() { Name = "Swords", Type = "Item" });
            a.Add(new Accomplishment() { Name = "Shields", Type = "Item" });

            // Levels to complete
            a.Add(new Accomplishment() { Name = "Level 1", Type = "Level" });
            a.Add(new Accomplishment() { Name = "Level 2", Type = "Level" });
            a.Add(new Accomplishment() { Name = "Level 3", Type = "Level" });

            Accomplishments = a;
            //MessageBox.Show("Got accomplishments from default");
        }


        public void GetSavedAccomplishments()
        {
            ObservableCollection<Accomplishment> a = new ObservableCollection<Accomplishment>();

            foreach (Object o in Windows.Storage.ApplicationData.Current.LocalSettings.Values)
            {
                a.Add((Accomplishment)o);
            }

            Accomplishments = a;
            //MessageBox.Show("Got accomplishments from storage");
        }
    }
}