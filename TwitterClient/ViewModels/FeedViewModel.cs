using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClient.ViewModels
{
    [Export(typeof(FeedViewModel))]
    public class FeedViewModel : BindableBase
    {
    }
}
