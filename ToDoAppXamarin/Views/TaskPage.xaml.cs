using System;
using Xamarin.Forms;
using ToDoAppXamarin.Model;

namespace ToDoAppXamarin.Views
{
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
        }

        // Save button clicked event
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var task = (TaskItem)BindingContext;
            task.Title = titleEntry.Text;
            task.Description = descriptionEditor.Text;
            task.DueDate = dueDatePicker.Date;
            task.Priority = priorityPicker.SelectedItem?.ToString();
            task.IsCompleted = isCompletedSwitch.IsToggled;

            // Save task to the database
            await App.Database.SaveTaskAsync(task);
            await Navigation.PopAsync();
        }

        // Delete button clicked event
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var task = (TaskItem)BindingContext;

            // Delete task from the database
            await App.Database.DeleteTaskAsync(task);
            await Navigation.PopAsync();
        }
    }
}
