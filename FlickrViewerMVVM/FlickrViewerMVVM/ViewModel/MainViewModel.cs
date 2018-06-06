using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using FlickrViewerMVVM.Model;
using System.Collections.ObjectModel;
using System;
using System.Windows.Media.Imaging;

namespace FlickrViewerMVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// attributes
        /// </summary>
        private const string KEY = "99a1de0dbb595e0ca01247ae06b72671";
        WebClient flickrClient = new WebClient();
        Task<string> flickrTask = null;

        /// <summary>
        /// properties
        /// </summary>
        string tag, flickrImage;
        FlickrResults selectedImage, x = new FlickrResults();
        ObservableCollection<FlickrResults> flickrImages;
        
        public string Tag
        {
            get { return tag; }
            set { tag = value; RaisePropertyChanged("Tag"); }
        }

        public ObservableCollection<FlickrResults> FlickrList
        {
            get { return flickrImages; }
            set { flickrImages = value; RaisePropertyChanged("FlickrList"); }
        }
        public FlickrResults SelectedImage
        {
            get { return selectedImage; }
            //calls the GetFlickrImage method when selected
            set { selectedImage = value;  RaisePropertyChanged("SelectedImage"); GetFlickrImage(); }
        }

        public string FlickrImage
        {
            get { return flickrImage; }
            set { flickrImage = value; RaisePropertyChanged("FlickrImage"); }
        }
        
        public ICommand Search { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            flickrImages = new ObservableCollection<FlickrResults>();
            Search = new RelayCommand(SeachMethod);
        }

        /// <summary>
        /// Method is called when the search button is selected
        /// Searches all images related to the tag inserted by user
        /// </summary>
        private async void SeachMethod()
        {
            if (flickrTask != null && flickrTask.Status != TaskStatus.RanToCompletion)
            {
                var result = MessageBox.Show("Cancel the current Flickr search?", "Are you sure?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                    return;
                else
                    flickrClient.CancelAsync(); // cancel current search
            } // end if
            else
            {
                var flickrURL = string.Format("https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&tags={1}&tag_mode=all&per_page=500&privacy_filter=1"
             , KEY, Tag.Replace(" ", ","));

                FlickrList.Clear(); // clear imagesListBox
                FlickrImage = null; // clear pictureBox
                x.Title = "Loading...";
                FlickrList.Add(x); // display Loading...

                try
                {
                    flickrTask = flickrClient.DownloadStringTaskAsync(flickrURL);
                    XDocument flickrXML = XDocument.Parse(await flickrTask);
                    var flickrPhotos =
                        (from photo in flickrXML.Descendants("photo")
                         let id = photo.Attribute("id").Value
                         let title = photo.Attribute("title").Value
                         let secret = photo.Attribute("secret").Value
                         let server = photo.Attribute("server").Value
                         let farm = photo.Attribute("farm").Value
                         select new FlickrResults
                         {
                             Title = title,
                             URL = string.Format("https://farm{0}.staticflickr.com/{1}/{2}_{3}.jpg", farm, server, id, secret)
                         }).ToList();
                    if (flickrPhotos.Any())
                    {
                        FlickrList.Clear(); // clear imagesListBox
                        FlickrList = new ObservableCollection<FlickrResults>(flickrPhotos);
                    }
                    else // no matches were found
                    {
                        FlickrList.Clear(); // clear imagesListBox
                        x.Title = "No matches";
                        FlickrList.Add(x);
                    }
                } // end try
                catch (WebException)
                {
                    // check whether Task failed
                    if (flickrTask.Status == TaskStatus.Faulted)
                        MessageBox.Show("Unable to get results from Flickr");
                    FlickrList.Clear(); // clear imagesListBox
                    x.Title = "Error occurred";
                    FlickrList.Add(x);
                } // end catch
            } // end else
        } // end SearchMethod

        /// <summary>
        /// Gets the selected image URL and sends it back to the FlickrImage property to display the image
        /// </summary>
        private void GetFlickrImage()
        {
            int i = FlickrList.IndexOf(SelectedImage);
            if (i <= FlickrList.Count)
                FlickrImage = selectedImage.URL;
        } // end GetFlickrImage
    }
}