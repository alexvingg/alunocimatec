﻿using AlunoCimatec.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AlunoCimatec
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cursos : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        IAsyncAction ass;


        public Cursos()
        {
            this.InitializeComponent();

            StatusBarProgressIndicator progressbar = StatusBar.GetForCurrentView().ProgressIndicator;
            ass = progressbar.ShowAsync();

            List<Model.Disciplinas> listDs = this.getListDisciplinas();
            List<Model.Curso> lisCur = this.getListCursos();
            lisCur[0].Disciplinas = listDs;
            lisCur[1].Disciplinas = listDs;

            GridView.ItemsSource = lisCur;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        private List<Model.Curso> getListCursos()
        {
            List<Model.Curso> lista = new List<Model.Curso>();
            for (int i = 0; i < 2; i++)
            {
                Model.Curso curso = new Model.Curso();
                curso.Nome = "Curso " + i;
                lista.Add(curso);
            }

            return lista;
        }

        private List<Model.Disciplinas> getListDisciplinas()
        {
            List<Model.Disciplinas> lista = new List<Model.Disciplinas>();
            for (int i = 0; i < 5; i++)
            {
                Model.Disciplinas di = new Model.Disciplinas();
                di.Nome = "Materia " + i;
                di.Professor = "Professor " + i;
                di.Imagens = this.getListaImagemDisciplina();
                lista.Add(di);
            }

            return lista;
        }

        private List<Model.ImagemDisciplina> getListaImagemDisciplina()
        {
            List<Model.ImagemDisciplina> lista = new List<Model.ImagemDisciplina>();

            for (int i = 1; i < 5; i++)
            {
                Model.ImagemDisciplina di = new Model.ImagemDisciplina();
                di.Descricao = "Imagem " + i;
                di.Image = new BitmapImage(new Uri(this.BaseUri, "Assets/Images/FotoAula" + i + ".jpg"));
                lista.Add(di);
            }

            return lista;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Model.Curso curso = e.ClickedItem as Model.Curso;

            this.Frame.Navigate(typeof(Principal), curso);
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
