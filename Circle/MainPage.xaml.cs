namespace Circle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Handle Entry change
        private void OnRadiusEntryChanged(object sender, TextChangedEventArgs e)
        {
            string text = RadiusEntry.Text ?? "";

            // allow only digits and decimal point
            text = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            if (text != RadiusEntry.Text)
                RadiusEntry.Text = text;

            double radius = text.Length > 0 ? double.Parse(text) : 0;

            // Restriction: max radius = 15
            if (radius > 15)
            {
                ErrorLabel.Text = "Error: Radius cannot be more than 15.";
                CircumferenceLabel.Text = "Circumference: -";
                AreaLabel.Text = "Area: -";
                VolumeLabel.Text = "Volume: -";
                Circle.Instance.Radius = 0;
                CircleView.Invalidate();
                return; // stop here
            }
            else
            {
                ErrorLabel.Text = ""; // clear error if valid
            }

            if (radius >= RadiusSlider.Minimum && radius <= RadiusSlider.Maximum)
                RadiusSlider.Value = radius;

            CalculateAndDisplay(radius);
        }



        // Handle Button click
        private void OnRadiusButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                double radius = double.Parse(button.Text);  // buttons always have valid numbers
                RadiusEntry.Text = radius.ToString();
                RadiusSlider.Value = radius;
                CalculateAndDisplay(radius);
            }
        }

        // Handle Slider change
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double radius = Math.Round(e.NewValue); // round slider value
            RadiusEntry.Text = radius.ToString();
            CalculateAndDisplay(radius);
        }

        // Calculation logic
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
