namespace RestaurantPosMAUI.Controls;

public partial class CurrentDateTimeControl : ContentView,IDisposable
{
	private readonly PeriodicTimer _timer;
	public CurrentDateTimeControl()
	{
		InitializeComponent();

        dayTimelbl.Text = DateTime.Now.ToString("dddd , hh:mm:ss tt");
        datelbl.Text = DateTime.Now.ToString("MMM dd, yyyy");

		_timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

		UpdateTimer();
	}

	private async void UpdateTimer()
	{
		while( await _timer.WaitForNextTickAsync()){
            dayTimelbl.Text = DateTime.Now.ToString("dddd , hh:mm:ss tt");
            datelbl.Text = DateTime.Now.ToString("MMM dd, yyyy");
        }
	}

	public void Dispose() => _timer.Dispose();
	
}