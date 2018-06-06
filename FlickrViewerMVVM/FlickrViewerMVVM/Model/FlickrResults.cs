using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrViewerMVVM.Model
{
    public class FlickrResults : ObservableObject
    {
        public string Title { get; set; }
        public string URL { get; set; }
    }
}