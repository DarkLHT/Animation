using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AnimationScanPlan.Controls
{
    public class ContentTransitionControl : ContentControl
    {
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            "Duration",
            typeof(Duration),
            typeof(ContentTransitionControl));

        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public double CurrentTop { get; set; }

        private ContentControl _current;
        private ContentControl _old;
        private double _oldTop;


        public ContentTransitionControl()
        {
            DefaultStyleKey = typeof(ContentTransitionControl);
        }

        public override void OnApplyTemplate()
        {
            _old = (ContentControl)GetTemplateChild("_old");
            _current = (ContentControl)GetTemplateChild("_current");
            base.OnApplyTemplate();
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            if (_current == null || _old == null) return;

            _current.Content = newContent;
            _old.Content = oldContent;

            var width = ActualWidth;

            Slide(new Thickness(0, _oldTop, 0, 0), new Thickness(width, _oldTop, 0, 0), _old);
            Slide(new Thickness(-width, CurrentTop, width, 0), new Thickness(0, CurrentTop, 0, 0), _current);

            _oldTop = CurrentTop;
        }

        private void Slide(Thickness from, Thickness to, DependencyObject element)
        {
            if (element == null) return;

            var slide = new ThicknessAnimation
            {
                Duration = Duration,
                From = from,
                To = to,
                DecelerationRatio = 0.9
            };

            Storyboard.SetTarget(slide, element);
            Storyboard.SetTargetProperty(slide, new PropertyPath("Margin"));

            var sb = new Storyboard();
            sb.Children.Add(slide);
            sb.Begin();
        }
    }
}
