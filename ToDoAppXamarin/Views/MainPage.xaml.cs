using ToDoAppXamarin.Model;
using Xamarin.Forms;
using System;
using ToDoAppXamarin.Views;
using static Android.Telephony.CarrierConfigManager;

namespace ToDoAppXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            tasksListView.ItemsSource = await App.Database.GetTasksAsync();
        }

        async void OnTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TaskPage
                {
                    BindingContext = e.SelectedItem as TaskItem
                });
            }
        }

        async void OnAddTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskPage
            {
                BindingContext = new TaskItem()
            });
        }
    }
}
