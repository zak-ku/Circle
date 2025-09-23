namespace Circle
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRadiusEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(RadiusEntry.Text, out double radius))
            {
                if (radius >= RadiusSlider.Minimum && radius <= RadiusSlider.Maximum)
                    RadiusSlider.Value = radius;

                CalculateAndDisplay(radius);
            }
        }

        private void OnRadiusButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button && double.TryParse(button.Text, out double radius))
            {
                RadiusEntry.Text = radius.ToString();
                RadiusSlider.Value = radius;
                CalculateAndDisplay(radius);
            }
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double radius = Math.Round(e.NewValue);
            RadiusEntry.Text = radius.ToString();
            CalculateAndDisplay(radius);
        }

        private void CalculateAndDisplay(double radius)
        {
            double circumference = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);
            double volume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

            CircumferenceLabel.Text = $"Circumference: {circumference:F2}";
            AreaLabel.Text = $"Area: {area:F2}";
            VolumeLabel.Text = $"Volume: {volume:F2}";

            // Update circle
            Circle.Instance.Radius = radius;
            CircleView.Invalidate();
        }
    }
}
