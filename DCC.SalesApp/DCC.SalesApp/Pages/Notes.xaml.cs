
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DCC.SalesApp.Models;
using DevExpress.Mobile.DataGrid.Theme;
using DevExpress.Mobile.DataGrid;

namespace DCC.SalesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notes : ContentPage
    {
        Int32 _selectedId = -1;
        public Notes()
        {
            InitializeComponent();
            Notes_view.grdNotes.AutoFilterPanelHeight = 30;
            Notes_view.grdNotes.RowTap += GrdNotes_RowTap;
            loading();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _selectedId = -1;
        }
        protected  void loading()
        {
            try
            {
                Theme.ApplyGridTheme();
                List<NotesInfo> oNotesList = App.Database.GetNotes().ToList();
                Notes_view.grdNotes.ItemsSource = oNotesList;
                ThemeManager.RefreshTheme();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void GrdNotes_RowTap(object sender, RowTapEventArgs e)
        {
            NotesInfo obj = new NotesInfo();
            obj = Notes_view.grdNotes.SelectedDataObject as NotesInfo;
            if (_selectedId != obj.ID)
            {
                _selectedId = obj.ID;
                this.Navigation.PushAsync(new NotesDetail(_selectedId) { Title = obj.ActivityName });
            }
        }

        public void BtnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new NoteNew() { Title ="Add New Note"});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}