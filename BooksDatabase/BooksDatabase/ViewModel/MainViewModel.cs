using GalaSoft.MvvmLight;
using System.Linq;

namespace BooksDatabase.ViewModel
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
        string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                RaisePropertyChanged("text");
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            BooksEntities dbcontext = new BooksEntities();

            //Get a list of all the titles and the authors who wrote them.
            //Sort the result by title.
            var allTitles =
                from author in dbcontext.Authors
                from book in author.Titles
                orderby book.Title1
                select new { author.FirstName, author.LastName, book.Title1 };

            Text += "Titles and Authors:";

            // display titles and author
            foreach (var element in allTitles)
            {
                Text += "\r\n\t" + element.Title1 + "\t" + element.FirstName + "\t" + element.LastName;
            } // end foreach

            //Get a list of all the titles and the authors who wrote them.
            //Sort the result by title.
            //For each title sort the authors alphabetically by last name, then first name.
            var allTitlesLF =
                from author in dbcontext.Authors
                from book in author.Titles
                orderby book.Title1, author.LastName, author.FirstName
                select new { author.FirstName, author.LastName, book.Title1 };

            Text += "\r\n\r\nAuthors and titles with authors sorted for each title:";

            // display titles and author
            foreach (var element in allTitlesLF)
            {
                Text += "\r\n\t" + element.Title1 + "\t" + element.LastName + "\t" + element.FirstName;
            } // end foreach

            //Get a list of all the authors grouped by title, sorted by title
            //for a given title sort the author names alphabetically by last name first then first name.
            var authorsByTitle =
                           from author in dbcontext.Authors
                           from book in author.Titles
                           group new { author.FirstName, author.LastName } by book.Title1 into bookGroup
                           orderby bookGroup.Key
                           select bookGroup;

            Text += "\r\n\r\nTitles grouped by author:";

            // display titles written by each author, grouped by titles
            foreach (var title in authorsByTitle)
            {
                // display titles's name
                Text += "\r\n\t" + title.Key + ":";

                // display authors
                foreach (var author in title.OrderBy(name => name.LastName + name.FirstName))
                {
                    Text += "\r\n\t\t" + author.FirstName + " " + author.LastName;
                } // end inner foreach
            } // end outer foreach

            this.RaisePropertyChanged(() => this.Text);
        }
    }
}