using Android.Runtime;
using Android.Text;
using Android.Views.InputMethods;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SearchView = Android.Support.V7.Widget.SearchView;
using DemoChat.Droid.CustomRenderers;
using DemoChat.Views.Controls;
using Android.Content;
using System.ComponentModel;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace DemoChat.Droid.CustomRenderers
{
    class SearchPageRenderer : PageRenderer
    {
        private SearchView _searchView;
        //Hashtable MenuPages = new Hashtable();
        HashSet<string> MenuPages = new HashSet<string>();

        private  bool isLoaded = false;
        readonly Context context;
        public SearchPageRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            AddSearchToToolBar();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            
            if (e.PropertyName == "ShowSearch" && !isLoaded)
            {
               // MenuPages.Add(sender.GetType().Name);
                Device.BeginInvokeOnMainThread(() => {
                    AddSearchToToolBar();
                });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_searchView != null)
            {
                _searchView.QueryTextChange += SearchView_QueryTextChange;
                _searchView.QueryTextSubmit += SearchView_QueryTextSubmit;
            }
            //var maintoolbar = (CrossCurrentActivity.Current?.Activity as MainActivity)?.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            var maintoolbar = MainActivity.ToolBar;
            maintoolbar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
            base.Dispose(disposing);
        }

        private void AddSearchToToolBar()   
        {
            var maintoolbar = MainActivity.ToolBar;
            //var maintoolbar = MainActivity.GetToolbar();
            //var maintoolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            if (maintoolbar == null || Element == null)
            {
                return;
            }
            isLoaded = true;
            maintoolbar.Title = Element.Title;
            maintoolbar.InflateMenu(Resource.Menu.mainmenu);

            _searchView = maintoolbar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            if (_searchView == null)
            {
                return;
            }

            _searchView.QueryTextChange += SearchView_QueryTextChange;
            _searchView.QueryTextSubmit += SearchView_QueryTextSubmit;
            _searchView.QueryHint = (Element as SearchPage)?.SearchPlaceHolderText;
            _searchView.ImeOptions = (int)ImeAction.Search;
            _searchView.InputType = (int)InputTypes.TextVariationNormal;
            _searchView.MaxWidth = int.MaxValue;
        }

        private void SearchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (!(Element is SearchPage searchPage))
            {
                return;
            }
            searchPage.SearchText = e.Query;
            searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

        private void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (!(Element is SearchPage searchPage))
            {
                return;
            }
            searchPage.SearchText = e?.NewText;
        }
    }
}