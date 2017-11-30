using AnimationScanPlan.ViewModels;

namespace AnimationScanPlan.View
{
    //public enum SomeView
    //{
    //    View1,
    //    View2
    //}

    //public class MainWindowModel : BindableBase
    //{
    //    private SomeView _someView;
    //    private DelegateCommand _view1Command;
    //    private DelegateCommand _view2Command;

    //    public SomeView SomeView
    //    {
    //        get { return _someView; }
    //        set { _someView = value; OnPropertyChanged();}
    //    }

    //    public DelegateCommand View1Command => _view1Command ?? (_view1Command = new DelegateCommand(View1Action));
    //    public DelegateCommand View2Command => _view2Command ?? (_view2Command = new DelegateCommand(View2Action));

    //    private void View2Action()
    //    {
    //        SomeView = SomeView.View2;
    //    }

    //    private void View1Action()
    //    {
    //        SomeView = SomeView.View1;
    //    }
    //}
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            //DataContext = new MainWindowViewModel();
        }
    }
}
